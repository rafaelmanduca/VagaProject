using Estacionamento.Models;
using Estacionamento.Data;

namespace Estacionamento.Services
{
    public class VagaService
    {
        private readonly EstacionamentoContext _context;

        public VagaService(EstacionamentoContext context)
        {
            _context = context;
        }

        public List<VagaEstacionamento> FindAll()
        {
            return _context.Vagas.ToList();
        }
    }
}
