using EmberAndVine.Data;
using EmberAndVine.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmberAndVine.Controllers;

public class ReservationsController(AppDbContext db, ILogger<ReservationsController> logger) : Controller
{
    [HttpGet]
    public IActionResult Create() => View(new Reservation
    {
        Date = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
        Guests = 2,
        TimeSlot = "19:00"
    });

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("FullName,Email,Phone,Date,TimeSlot,Guests,SpecialRequests")] Reservation model)
    {
        if (model.Date < DateOnly.FromDateTime(DateTime.Today))
        {
            ModelState.AddModelError(nameof(model.Date), "Please choose today or a later date.");
        }

        if (!ModelState.IsValid) return View(model);

        try
        {
            model.CreatedAtUtc = DateTime.UtcNow;
            db.Reservations.Add(model);
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Could not save reservation");
            ModelState.AddModelError(string.Empty,
                "We couldn't save your reservation because the database isn't reachable. " +
                "Check the connection string in appsettings.json and run Update-Database.");
            return View(model);
        }

        TempData["Name"] = model.FullName;
        TempData["When"] = $"{model.Date:dddd, d MMMM yyyy} at {model.TimeSlot}";
        TempData["Guests"] = model.Guests;
        return RedirectToAction(nameof(Success));
    }

    public IActionResult Success()
    {
        if (TempData["Name"] is null) return RedirectToAction(nameof(Create));
        return View();
    }
}
