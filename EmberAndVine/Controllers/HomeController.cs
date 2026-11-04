using EmberAndVine.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmberAndVine.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View(MenuData.Signature.ToList());

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View();
}
