using Microsoft.AspNetCore.Mvc;

namespace ITCOnsultantWebsite.Controllers;

[Route("")]
public class HomeController : Controller
{
    // Homepage
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    // About page
    [Route("about")]
    public IActionResult About()
    {
        return View();
    }

    [Route("services")]
    public IActionResult Services()
    {
        return View();
    }

    [Route("contact")]
    public IActionResult Contact()
    {
        return View();
    }
}
