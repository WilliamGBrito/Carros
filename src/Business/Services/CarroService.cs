using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services
{
    public class CarroService : BaseService, ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository, INotificador notificador) : base(notificador)
        {
            _carroRepository = carroRepository;
        }

        public async Task Adicionar(Carro carro)
        {
            if (!ExecutarValidacao(new CarroValidation(), carro)) return;

            var carroExistente = _carroRepository.ObterPorId(carro.Id);

            if (carroExistente != null)
            {
                Notificar("Já existe um carro com o ID informado!");
                return;
            }

            await _carroRepository.Adicionar(carro);
        }

        public async Task Atualizar(Carro carro)
        {
            if (!ExecutarValidacao(new CarroValidation(), carro)) return;

            await _carroRepository.Atualizar(carro);
        }

        public async Task Remover(int id)
        {
            await _carroRepository.Remover(id);
        }

        public void Dispose()
        {
            _carroRepository.Dispose();
        }
    }
}
