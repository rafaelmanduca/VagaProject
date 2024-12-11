using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
using Vaga.Controllers;

namespace Estacionamento.Data
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options) : base(options)
        {

        }

        public DbSet<VagaEstacionamento> Vagas { get; set; }


       
    }



    

}
