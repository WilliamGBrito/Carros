using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        protected CarroRepository(MeuDbContext db) : base(db)
        {
        }
    }
}