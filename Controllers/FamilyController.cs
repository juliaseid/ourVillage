using Microsoft.AspNetCore.Mvc;
using YourVillage.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using YourVillage.Authorization;

namespace YourVillage.Controllers
{

  [Authorize]
  public class FamilyController : Controller
  {
    private readonly YourVillageContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuthorizationService _authService;
    public FamilyController(YourVillageContext db, UserManager<ApplicationUser> userManager, IAuthorizationService authService)
    {
      _db = db;
      _userManager = userManager;
      _authService = authService;

    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userFamilies = (_db.Families.Where(entry => (entry.ParentId == currentUser.Id))).ToList();

      if ((_db.Caregivers.Select(entry => entry.CaregiverId == currentUser.Id)) != null)
      {
        var careFamilies = (_db.Families.Where(entry => (entry.CaregiverIds.Contains(currentUser.Id)))).ToList();
        ViewBag.CaregiverFamilies = careFamilies;
      }

      ViewBag.Children = new List<Child>();
      foreach (Family family in userFamilies)
      {
        var child = (_db.Children.Where(entry => entry.FamilyId == family.FamilyId)).ToList();
        ViewBag.Children = child;
      }

      foreach (Family family in userFamilies)
      {
        var babysitters = _db.Families
        .Include(fam => fam.Caregivers)
        .ThenInclude(join => join.Caregiver)
        .FirstOrDefault(fam => fam.FamilyId == family.FamilyId);
      }
      return View(userFamilies);
    }



    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Family family)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      family.ParentId = currentUser.Id;
      _db.Families.Add(family);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public async Task<ActionResult> Details(int id)
    {
      Family thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      var isAuthorized = await _authService.AuthorizeAsync(User, thisFamily, YourVillageOperations.Read);
      if (!isAuthorized.Succeeded)
      {
        return Forbid();
      }
      var babysitters = _db.Families
      .Include(fam => fam.Caregivers)
      .ThenInclude(join => join.Caregiver)
      .FirstOrDefault(fam => fam.FamilyId == id);
      return View(thisFamily);
    }

    public async Task<ActionResult> AddCaregiver(int id)
    {
      Family thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      var isAuthorized = await _authService.AuthorizeAsync(User, thisFamily, YourVillageOperations.Update);
      if (!isAuthorized.Succeeded)
      {
        return Forbid();
      }
      return View(thisFamily);
    }

    [AllowAnonymous]
    public ActionResult CaregiverAccess()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> CaregiverAccess(string profile, int code)
    {
      Family thisFamily = _db.Families.FirstOrDefault(family => family.ProfileName == profile);
      var isAuthorized = await _authService.AuthorizeAsync(User, thisFamily, YourVillageOperations.Access);
      if (!isAuthorized.Succeeded)
      {
        return Forbid();
      }
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      if (_db.Caregivers.Where(c => (c.CaregiverId == currentUser.Id)) == null)
      {
        Caregiver caregiver = new Caregiver { CaregiverId = currentUser.Id };
        _db.Caregivers.Add(caregiver);
        _db.SaveChanges();
      }

      CaregiverFamily thisCaregiver = _db.CaregiverFamilies.FirstOrDefault(caregiver => caregiver.CaregiverId == currentUser.Id);
      if (thisFamily.SecretCode == code)
      {
        _db.CaregiverFamilies.Add(new CaregiverFamily() { CaregiverId = currentUser.Id, FamilyId = thisFamily.FamilyId });
      }
      else
      {
        return View();
      }
      _db.Entry(thisFamily).Collection(f => f.Caregivers).IsModified = true;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      return View(thisFamily);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Family family)
    {
      var isAuthorized = await _authService.AuthorizeAsync(User, family, YourVillageOperations.Update);
      if (!isAuthorized.Succeeded)
      {
        return Forbid();
      }
      _db.Entry(family).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      return View(thisFamily);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      var thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      var isAuthorized = await _authService.AuthorizeAsync(User, thisFamily, YourVillageOperations.Delete);
      if (!isAuthorized.Succeeded)
      {
        return Forbid();
      }
      _db.Families.Remove(thisFamily);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
