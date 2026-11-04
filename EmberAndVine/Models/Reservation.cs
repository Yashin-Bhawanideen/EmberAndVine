using System.ComponentModel.DataAnnotations;

namespace EmberAndVine.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please tell us your name."), StringLength(80)]
    [Display(Name = "Full name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "We need an email to confirm your table."), EmailAddress(ErrorMessage = "That email doesn't look right.")]
    [StringLength(120)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Add a phone number in case we need to reach you."), Phone, StringLength(30)]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Choose a date.")]
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Choose a time."), StringLength(5)]
    [Display(Name = "Time")]
    public string TimeSlot { get; set; } = "19:00";

    [Range(1, 12, ErrorMessage = "We seat 1 to 12 guests online. For larger groups, call us.")]
    public int Guests { get; set; } = 2;

    [StringLength(500)]
    [Display(Name = "Anything we should know?")]
    public string? SpecialRequests { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
