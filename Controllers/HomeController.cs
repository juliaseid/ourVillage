using Microsoft.AspNetCore.Mvc;

namespace ourVillage.Controllers
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