using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.Models.Cars.Chevrolet;

namespace AutoSalonAPI.Reposiotry.CarRepository.ChevroletRepository
{
    public interface IChevroletRepository
    {
        Task<IEnumerable<ChevroletResponse>> GetAllChevroletByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<Chevroletcars?> GetById(long id, CancellationToken cancellationToken = default);
        Task<Chevroletcars?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<Chevroletcars>> GetAllChevrolet(CancellationToken cancellationToken = default);
        Task<List<ChevroletResponse>> GetAllChevroletList(string culture, CancellationToken cancellationToken = default);
        Task<Chevroletcars?> CreateAsync(Chevroletcars Chevroletcars, CancellationToken cancellationToken = default);
        Task<Chevroletcars> UpdateChevroletAsync(Chevroletcars Chevroletcars, CancellationToken cancellationToken = default);
        Task<Boolean> Delete(Chevroletcars chevroletcars, CancellationToken cancellationToken = default);
    }
}
