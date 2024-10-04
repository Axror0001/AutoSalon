using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.Models.Companys.MersedensBens;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.MersCompanyRepository
{
    public class MersCompanyRepository : IMersCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public MersCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<MersedensBenscompanys?> CreateAsync(MersedensBenscompanys mersCompany, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(MersedensBenscompanys merscompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MersedensBenscompanys>> GetAllMersCompany(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MersCompanyResponce>> GetAllMersCompanyByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<MersCompanyResponce>> GetAllMersCompanyList(string culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MersedensBenscompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MersedensBenscompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsername(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MersedensBenscompanys> UpdateMersCompanyAsync(MersedensBenscompanys mersCompany, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
