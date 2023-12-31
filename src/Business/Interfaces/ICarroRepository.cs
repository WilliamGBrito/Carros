﻿using Business.Models;

namespace Business.Interfaces
{
    public interface ICarroRepository : IRepository<Carro>
    {
        Task<Carro> ObterModelo(string modelo);
    }
}
