using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.Models.Companys.BMW;
using AutoSalon.Models.Companys.MersedensBens;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.MersCompanyRepository
{
    public interface IMersCompanyRepository
    {
        Task<IEnumerable<MersCompanyResponce>> GetAllMersCompanyByCultureAsync(string language, CancellationToken cancellationToken = default);
        Task<string> GetUsername(string guid, CancellationToken cancellationToken = default);
        Task<MersedensBenscompanys?> GetById(long id, CancellationToken cancellationToken = default);
        Task<MersedensBenscompanys?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<MersedensBenscompanys>> GetAllMersCompany(CancellationToken cancellationToken = default);
        Task<List<MersCompanyResponce>> GetAllMersCompanyList(string culture, CancellationToken cancellationToken = default);
        Task<MersedensBenscompanys?> CreateAsync(MersedensBenscompanys mersCompany, CancellationToken cancellationToken = default);
        Task<MersedensBenscompanys> UpdateMersCompanyAsync(MersedensBenscompanys mersCompany, CancellationToken cancellationToken = default);
        Task<Boolean> Delete(MersedensBenscompanys merscompanys, CancellationToken cancellationToken = default);
    }
}
