using Business.Models;

namespace Business.Interfaces
{
    public interface ICarroService : IDisposable
    {
        Task Adicionar(Carro carro);
        Task Atualizar(Carro carro);
        Task Remover(int id);
    }
}
