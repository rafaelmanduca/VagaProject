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

        public void Add(VagaEstacionamento vaga)
        {
            _context.Vagas.Add(vaga);
            _context.SaveChanges();
        }

        public void Insert(VagaEstacionamento vaga)
        {
            _context.Vagas.Add(vaga); // Adiciona a nova vaga
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }
    }
}
