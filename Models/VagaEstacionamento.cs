using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Models
{
    public class VagaEstacionamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da vaga é obrigatório.")]
        public int NumeroVaga { get; set; }

        [Required(ErrorMessage = "O tipo de vaga é obrigatório.")]
        public string Tipo { get; set; }

        public Boolean Status { get; set; }

        public DateTime Ocupacao { get; set; }

        public DateTime Liberacao { get; set; }



        public VagaEstacionamento() { }

        public VagaEstacionamento(int id,int numeroVaga)
        {
            Id = id;
            NumeroVaga = numeroVaga;
        }

        public VagaEstacionamento(int id, int numeroVaga, string tipo, bool status, DateTime ocupacao, DateTime liberacao)
        {
            Id = id;
            NumeroVaga = numeroVaga;
            Tipo = tipo;
            Status = status;
            Ocupacao = ocupacao;
            Liberacao = liberacao;
        }

       

    }



   
  

}
