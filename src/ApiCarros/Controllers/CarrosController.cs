using System.Net;
using ApiCarros.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarros.Controllers
{
    [Route("api/[controller]")]
    public class CarrosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICarroRepository _carroRepository;
        private readonly ICarroService _carroService;
        public CarrosController(IMapper mapper, ICarroRepository carroRepository, ICarroService carroService, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _carroRepository = carroRepository;
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<IEnumerable<CarroViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarroViewModel>> ObterPorId(int id)
        {
            var carro = await ObterCarro(id);

            if (carro == null) return NotFound();

            return carro;
        }

        [HttpPost]
        public async Task<ActionResult<CarroViewModel>> Adicionar(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var carro = _mapper.Map<Carro>(carroViewModel);

            await _carroService.Adicionar(carro);

            return CustomResponse(HttpStatusCode.Created, carro);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CarroViewModel>> Atualizar(int id, CarroViewModel carroViewModel)
        {
            if (id != carroViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var carroAtualizado = _mapper.Map<Carro>(carroViewModel);

            await _carroService.Atualizar(carroAtualizado);

            return CustomResponse(HttpStatusCode.OK, carroAtualizado);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarroViewModel>> Excluir(int id)
        {
            await _carroService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<CarroViewModel> ObterCarro(int id)
        {
            return _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));
        }
    }
}
