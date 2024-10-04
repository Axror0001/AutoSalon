using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.Models.Cars.BMW;

namespace AutoSalonAPI.Reposiotry.CarRepository.BmwRepository
{
    public interface IBmwRepository
    {
        Task<IEnumerable<BmwResponse>> GetAllBmwByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<BMWcars?> GetById(long id, CancellationToken cancellationToken = default);
        Task<BMWcars?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<BMWcars>> GetAllBmw(CancellationToken cancellationToken = default);
        Task<List<BmwResponse>> GetAllBmwList(string culture, CancellationToken cancellationToken = default);
        Task<BMWcars?> CreateAsync(BMWcars bmwcars, CancellationToken cancellationToken = default);
        Task<BMWcars> UpdateBmwAsync(BMWcars bmwcars, CancellationToken cancellationToken = default);
        Task<Boolean> Delete(BMWcars bmwcars, CancellationToken cancellationToken = default);
    }
}
