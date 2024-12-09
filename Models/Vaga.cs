namespace Estacionamento.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        
        public int NumeroVaga { get; set; }
  
        public string Tipo { get; set; }

        public Boolean Status { get; set; }

        public DateTime Ocupacao { get; set; }

        public DateTime Liberacao { get; set; }



        public Vaga()
        {

        }

        public Vaga(int id, int numeroVaga, string tipo, bool status, DateTime ocupacao, DateTime liberacao)
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
