using ApiCarros.ViewModels;
using AutoMapper;
using Business.Models;

namespace ApiCarros.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Carro, CarroViewModel>().ReverseMap();
        }
    }
}
