using Parking.Models;
using Parking.Data;

namespace Parking.Services
{
    public class ParkingSpotService
    {
        private readonly ParkingContext _context;

        public ParkingSpotService(ParkingContext context)
        {
            _context = context;
        }

        public List<ParkingSpot> FindAll()
        {
            return _context.ParkingSpots.ToList();
        }

        public void Add(ParkingSpot parkingSpot)
        {
            _context.ParkingSpots.Add(parkingSpot);
            _context.SaveChanges();
        }

        public void Insert(ParkingSpot parkingSpot)
        {
            _context.ParkingSpots.Add(parkingSpot);
            _context.SaveChanges(); 
        }

        public void Remove(ParkingSpot parkingSpot)
        {
            try
            {
                _context.ParkingSpots.Remove(parkingSpot);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
               
                throw new Exception("Erro ao deletar vaga: " + ex.Message);
            }
        }

        public ParkingSpot FindById(int id)
        {
            return _context.ParkingSpots.FirstOrDefault(v => v.Id == id);
        }

        public void Update(ParkingSpot parkingSpot)
        {
            
            var existingSpot = _context.ParkingSpots.FirstOrDefault(v => v.Id == parkingSpot.Id);
            if (existingSpot != null)
            {
              
                existingSpot.Type = parkingSpot.Type;
                existingSpot.Occupation = parkingSpot.Occupation;
                existingSpot.Release = parkingSpot.Release;
                existingSpot.Status = parkingSpot.Status;

                
                _context.SaveChanges();
            }
        }
    }
}
