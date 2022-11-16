using System.Threading.Tasks;

namespace DogAPI.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAtendimentoRepository AtendimentoRepository { get; }
        ICachorroRepository CachorroRepository {get; }
        IClienteRepository ClienteRepository { get; }
        IVeterinarioRepository VeterinarioRepository { get; }
        Task Commit();
    }
}