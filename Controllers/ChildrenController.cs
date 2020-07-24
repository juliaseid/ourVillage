using Microsoft.AspNetCore.Mvc;
using YourVillage.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YourVillage.Controllers
{
  public class ChildrenController : Controller
  {
    private readonly YourVillageContext _db;

    public ChildrenController(YourVillageContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Child> model = _db.Children.Include(children => children.Family).ToList();
      model = model.OrderBy(c => c.Birthday).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Child child)
    {
      _db.Children.Add(child);
      _db.SaveChanges();
      return RedirectToAction("Index");
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
