using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.Models.Cars.Toyoto;

namespace AutoSalonAPI.Reposiotry.CarRepository.ToyotoRepository
{
    public interface IToyotoRepository
    {
        Task<IEnumerable<ToyotoResponse>> GetAllToyotoByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<Toyotocars?> GetById(long id, CancellationToken cancellationToken = default);
        Task<Toyotocars?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<Toyotocars>> GetAllToyotos(CancellationToken cancellationToken = default);
        Task<List<ToyotoResponse>> GetAllToyotosList(string culture, CancellationToken cancellationToken = default);
        Task<Toyotocars?> CreateAsync(Toyotocars toyoto, CancellationToken cancellationToken = default);
        Task<Toyotocars> UpdateToyotoAsync(Toyotocars toyoto, CancellationToken cancellationToken = default);
        Task<Boolean> Delete(Toyotocars toyotocars, CancellationToken cancellationToken = default);
    }
}
