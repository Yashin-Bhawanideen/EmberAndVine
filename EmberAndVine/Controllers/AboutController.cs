using Microsoft.AspNetCore.Mvc;

namespace EmberAndVine.Controllers;

public class AboutController : Controller
{
    public IActionResult Index() => View();
}
