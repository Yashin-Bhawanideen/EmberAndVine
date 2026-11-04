using EmberAndVine.Models;
using Microsoft.EntityFrameworkCore;

namespace EmberAndVine.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Reservation> Reservations => Set<Reservation>();
}
