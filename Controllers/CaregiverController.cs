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
  [Authorize]
  public class CaregiverController : Controller
  {
    private readonly YourVillageContext _db;
    private readonly UserManager<ApplicationUser> _userManager;


    public CaregiverController(YourVillageContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }


  }

}