using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.Models.Companys.Chevrolet;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.ChevroletCompanyRepository
{
    public interface IChevroletCompanyRepository
    {
        Task<IEnumerable<ChevroletCompanyResponce>> GetAllChevroletcompanysByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<Chevroletcompanys?> GetById(long id, CancellationToken cancellationToken = default);
        Task<Chevroletcompanys?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<Chevroletcompanys>> GetAllChevroletcompanys(CancellationToken cancellationToken = default);
        Task<List<ChevroletCompanyResponce>> GetAllChevroletcompanysList(string culture, CancellationToken cancellationToken = default);
        Task<Chevroletcompanys?> CreateAsync(Chevroletcompanys Chevroletcompanys, CancellationToken cancellationToken = default);
        Task<Chevroletcompanys> UpdateChevroletcompanysAsync(Chevroletcompanys Chevroletcompanys, CancellationToken cancellationToken = default);
    }
}
