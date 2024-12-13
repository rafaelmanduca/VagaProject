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

        public void Remove(VagaEstacionamento vaga)
        {
            try
            {
                _context.Vagas.Remove(vaga);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Opcional: logar o erro para depuração
                throw new Exception("Erro ao remover a vaga: " + ex.Message);
            }
        }

        public VagaEstacionamento FindById(int id)
        {
            return _context.Vagas.FirstOrDefault(v => v.Id == id);
        }

        public void Update(VagaEstacionamento vaga)
        {
            // Verifica se a vaga existe
            var vagaExistente = _context.Vagas.FirstOrDefault(v => v.Id == vaga.Id);
            if (vagaExistente != null)
            {
                // Atualiza os dados da vaga
                vagaExistente.Tipo = vaga.Tipo;
                vagaExistente.Ocupacao = vaga.Ocupacao;
                vagaExistente.Liberacao = vaga.Liberacao;
                vagaExistente.Status = vaga.Status;

                // Salva as alterações no banco de dados
                _context.SaveChanges();
            }
        }




    }
}
