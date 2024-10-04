using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.Models.Cars.BYD;

namespace AutoSalonAPI.Reposiotry.CarRepository.BYDRepository
{
    public interface IBydRepository
    {
        Task<IEnumerable<BydResponse>> GetAllBydByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<BYDcars?> GetById(long id, CancellationToken cancellationToken = default);
        Task<BYDcars?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<BYDcars>> GetAllByd(CancellationToken cancellationToken = default);
        Task<List<BydResponse>> GetAllBydList(string culture, CancellationToken cancellationToken = default);
        Task<BYDcars?> CreateAsync(BYDcars BYDcars, CancellationToken cancellationToken = default);
        Task<BYDcars> UpdateBydAsync(BYDcars BYDcars, CancellationToken cancellationToken = default);
        Task<Boolean> Delete(BYDcars BYDcars, CancellationToken cancellationToken= default);
    }
}
