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
      var userFamily = _db.Families.Where(entry => entry.ParentId == currentUser.Id);
      ViewBag.Children = new List<Child>();
      foreach (Family family in userFamily)
      {
        var child = (_db.Children.Where(entry => entry.FamilyId == family.FamilyId));
        ViewBag.Children.Add(child);
      }
      return View(userFamily);
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
      // ViewBag.ParentUser = currentUser;
      family.ParentId = currentUser.Id;
      var isAuthorized = await _authService.AuthorizeAsync(User, family, YourVillageOperations.Create);
      if (!isAuthorized.Succeeded)
      {
        return Forbid();
      }
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
