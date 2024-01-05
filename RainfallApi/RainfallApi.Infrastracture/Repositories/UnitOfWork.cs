using RainfallApi.Application.Interfaces;
namespace RainfallApi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRainfallRepository rainfallRepository)
        {
            Rainfall = rainfallRepository;
        }
        public IRainfallRepository Rainfall { get; }
    }
}
