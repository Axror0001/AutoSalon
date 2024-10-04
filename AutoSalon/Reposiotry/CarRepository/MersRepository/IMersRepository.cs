using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.Models.Cars.Chevrolet;
using AutoSalon.Models.Cars.MersedensBens;

namespace AutoSalonAPI.Reposiotry.CarRepository.MersRepository
{
    public interface IMersRepository
    {
        Task<IEnumerable<MersReponse>> GetAllMersByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<MersedensBenscars?> GetById(long id, CancellationToken cancellationToken = default);
        Task<MersedensBenscars?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<MersedensBenscars>> GetAllMerss(CancellationToken cancellationToken = default);
        Task<List<MersReponse>> GetAllMerssList(string culture, CancellationToken cancellationToken = default);
        Task<MersedensBenscars?> CreateAsync(MersedensBenscars mersedens, CancellationToken cancellationToken = default);
        Task<MersedensBenscars> UpdateMersAsync(MersedensBenscars mersedens, CancellationToken cancellationToken = default);
        Task<Boolean> Delete(MersedensBenscars mersedens, CancellationToken cancellationToken = default);
    }
}
