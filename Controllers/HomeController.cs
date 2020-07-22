using Microsoft.AspNetCore.Mvc;

namespace YourVillage.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}