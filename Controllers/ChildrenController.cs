using Microsoft.AspNetCore.Mvc;
using YourVillage.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace YourVillage.Controllers
{
  [Authorize]
  public class ChildController : Controller
  {
    private readonly YourVillageContext _db;
    private readonly UserManager<ApplicationUser> _userManager;


    public ChildController(YourVillageContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    public async Task<ActionResult> Index(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFamily = _db.Families.FirstOrDefault(entry => entry.FamilyId == id);
      Console.WriteLine("thisFamily" + thisFamily.ProfileName);
      ViewBag.Family = thisFamily;
      // var model = new List<Child>();
      List<Child> children = new List<Child>();
      Console.WriteLine(children.Count);
      if (_db.Children.Select(entry => (entry.FamilyId == id)) != null)
      {
        Console.WriteLine("In conditional - there are children!");
        children = (_db.Children.Where(entry => entry.FamilyId == thisFamily.FamilyId)).ToList();
        foreach (Child c in children) { Console.WriteLine("child name: " + c.FirstName); };
        return View(children);
      }
      else
      {
        return RedirectToAction("Create");
      }

      // foreach (Child c in children)
      // {
      //   model.Add(c);
      // }

      // model = model.OrderBy(c => c.Birthday).ToList();
      // return View(children);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(int id, Child child)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFamily = _db.Families.FirstOrDefault(f => f.ParentId == currentUser.Id);
      ViewBag.Family = thisFamily;
      child.FamilyId = thisFamily.FamilyId;
      _db.Children.Add(child);
      _db.SaveChanges();
      return RedirectToAction("Index", "Family", new { id = thisFamily.FamilyId });
    }

    public ActionResult Details(int id)
    {
      Child thisChild = _db.Children.FirstOrDefault(children => children.ChildId == id);
      return View(thisChild);
    }

    public ActionResult Edit(int id)
    {
      var thisChild = _db.Children.FirstOrDefault(children => children.ChildId == id);
      return View(thisChild);
    }

    [HttpPost]
    public ActionResult Edit(Child child)
    {
      _db.Entry(child).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisChild = _db.Children.FirstOrDefault(children => children.ChildId == id);
      return View(thisChild);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisChild = _db.Children.FirstOrDefault(children => children.ChildId == id);
      _db.Children.Remove(thisChild);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
