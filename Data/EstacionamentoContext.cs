using Parking.Models;
using Microsoft.EntityFrameworkCore;
using Parking.Controllers;

namespace Parking.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {

        }

        public DbSet<ParkingSpot> ParkingSpots { get; set; }
    }
}
