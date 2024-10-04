using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.Models.Companys.Toyoto;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.ToyotoCompanyRepository
{
    public interface IToyotoCompanyRepository
    {
        Task<IEnumerable<ToyotoCompanyResponce>> GetAllToyotocompanysByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<Toyotocompanys?> GetById(long id, CancellationToken cancellationToken = default);
        Task<Toyotocompanys?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<Toyotocompanys>> GetAllToyotocompanys(CancellationToken cancellationToken = default);
        Task<List<ToyotoCompanyResponce>> GetAllToyotocompanysList(string culture, CancellationToken cancellationToken = default);
        Task<Toyotocompanys?> CreateAsync(Toyotocompanys toyotoCompany, CancellationToken cancellationToken = default);
        Task<Toyotocompanys> UpdateToyotocompanysAsync(Toyotocompanys toyotoCompany, CancellationToken cancellationToken = default);
    }
}
