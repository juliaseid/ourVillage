using Microsoft.AspNetCore.Mvc;
using YourVillage.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace YourVillage.Controllers
{
  public class FamilyController : Controller
  {
    private readonly YourVillageContext _db;

    public FamilyController(YourVillageContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Family> model = _db.Families.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Family family)
    {
      _db.Families.Add(family);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Family thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      return View(thisFamily);
    }

    public ActionResult Edit(int id)
    {
      var thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      return View(thisFamily);
    }

    [HttpPost]
    public ActionResult Edit(Family family)
    {
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
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFamily = _db.Families.FirstOrDefault(family => family.FamilyId == id);
      _db.Families.Remove(thisFamily);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}