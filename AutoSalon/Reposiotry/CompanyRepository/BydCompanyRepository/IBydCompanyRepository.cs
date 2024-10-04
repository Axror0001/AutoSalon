using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.Models.Companys.BYD;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.BydCompanyRepository
{
    public interface IBydCompanyRepository
    {
        Task<IEnumerable<BydCompanyResponce>> GetAllBYDcompanysByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<BYDcompanys?> GetById(long id, CancellationToken cancellationToken = default);
        Task<BYDcompanys?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<BYDcompanys>> GetAllBYDcompanys(CancellationToken cancellationToken = default);
        Task<List<BydCompanyResponce>> GetAllBYDcompanysList(string culture, CancellationToken cancellationToken = default);
        Task<BYDcompanys?> CreateAsync(BYDcompanys BYDcompanys, CancellationToken cancellationToken = default);
        Task<BYDcompanys> UpdateBYDcompanysAsync(BYDcompanys BYDcompanys, CancellationToken cancellationToken = default);
    }
}
