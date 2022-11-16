using System.Threading.Tasks;
using DogAPI.Context;
using DogAPI.Repository.Interfaces;

namespace DogAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AtendimentoRepository _atendimentoRepo;
        private CachorroRepository _cachorroRepo;
        private ClienteRepository _clienteRepo;
        private VeterinarioRepository _veterinarioRepo;
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAtendimentoRepository AtendimentoRepository
        {
            get
            {
                return _atendimentoRepo = _atendimentoRepo ?? new AtendimentoRepository(_context);
            }
        }

        public ICachorroRepository CachorroRepository
        {
            get
            {
                return _cachorroRepo = _cachorroRepo ?? new CachorroRepository(_context);

            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context);

            }
        }

        public IVeterinarioRepository VeterinarioRepository
        {
            get
            {
                return _veterinarioRepo = _veterinarioRepo ?? new VeterinarioRepository(_context);

            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}