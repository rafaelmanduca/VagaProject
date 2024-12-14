using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A vaga já esta ocupada.")]
        [Display(Name = "Número da Vaga")]
        public int SpotNumber { get; set; }

        [Required(ErrorMessage = "é necessario selecionar um tipo.")]
        [Display(Name = "Tipo de Vaga")]
        public string Type { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Display(Name = "Data de Ocupação")]
        public DateTime Occupation { get; set; }

        [Display(Name = "Data de Liberação")]
        public DateTime Release { get; set; }

        
        public ParkingSpot() { }

       
        public ParkingSpot(int id, int spotNumber)
        {
            Id = id;
            SpotNumber = spotNumber;
        }


        public ParkingSpot(int id, int spotNumber, string type, bool status, DateTime occupation, DateTime release)
        {
            Id = id;
            SpotNumber = spotNumber;
            Type = type;
            Status = status;
            Occupation = occupation;
            Release = release;
        }
    }
}
