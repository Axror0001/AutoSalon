using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.Models.Companys.BMW;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.BmwCompanyRepository
{
    public interface IBmwCompanyRepository
    {
        Task<IEnumerable<BmwCompanyResponce>> GetAllBMWcompanysByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<BMWcompanys?> GetById(long id, CancellationToken cancellationToken = default);
        Task<BMWcompanys?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<BMWcompanys>> GetAllBMWcompanys(CancellationToken cancellationToken = default);
        Task<List<BmwCompanyResponce>> GetAllBMWcompanysList(string culture, CancellationToken cancellationToken = default);
        Task<BMWcompanys?> CreateAsync(BMWcompanys bmwcompanys, CancellationToken cancellationToken = default);
        Task<BMWcompanys> UpdateBMWcompanysAsync(BMWcompanys bmwcompanys, CancellationToken cancellationToken = default);
    }
}
