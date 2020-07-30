using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;




namespace YourVillage.Controllers
{
  [AllowAnonymous]
  public class HomeController : Controller
  {
    [HttpGet()]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("info")]
    public ActionResult Info()
    {
      return View();
    }
  }
}
