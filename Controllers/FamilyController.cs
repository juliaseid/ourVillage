using Microsoft.AspNetCore.Mvc;
using YourVillage.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
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
      List<Family> userFamilies = new List<Family>();
      var parentFamilies = (_db.Families.Where(entry => (entry.ParentId == currentUser.Id))).ToList();
      if (parentFamilies != null)
      {
        userFamilies = parentFamilies;
      }
      else
      {
        var caregiver = _db.Caregivers.FirstOrDefault(entry => entry.CaregiverId == currentUser.Id);
        var caregiverFamilies = caregiver.GetFamilyIds();
        userFamilies = (_db.Families.Where(entry => (caregiverFamilies.Contains(entry.FamilyId)))).ToList();
      }
      ViewBag.Children = new List<Child>();
      foreach (Family family in userFamilies)
      {
        var child = (_db.Children.Where(entry => entry.FamilyId == family.FamilyId)).ToList();
        ViewBag.Children = child;
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
      return View(thisFamily);
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
