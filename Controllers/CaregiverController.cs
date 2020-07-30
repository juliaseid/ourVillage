using Microsoft.AspNetCore.Mvc;
using YourVillage.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace YourVillage.Controllers
{
  [AllowAnonymous]
  public class CaregiverController : Controller
  {
    private readonly YourVillageContext _db;
    private readonly UserManager<ApplicationUser> _userManager;


    public CaregiverController(YourVillageContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Caregiver caregiver)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      caregiver.CaregiverId = currentUser.Id;
      _db.Caregivers.Add(caregiver);
      _db.SaveChanges();
      return RedirectToAction("CaregiverAccess", "Family");
    }


  }

}