namespace RainfallApi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRainfallRepository Rainfall { get; }
    }
}
