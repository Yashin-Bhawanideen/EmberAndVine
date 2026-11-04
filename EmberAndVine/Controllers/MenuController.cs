using EmberAndVine.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmberAndVine.Controllers;

public class MenuController : Controller
{
    public IActionResult Index() => View(MenuData.Items);
}
