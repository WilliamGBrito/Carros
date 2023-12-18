using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(MeuDbContext context) : base(context) { }

        public Task<Carro> ObterModelo(string modelo)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Modelo == modelo);
        }
    }
}