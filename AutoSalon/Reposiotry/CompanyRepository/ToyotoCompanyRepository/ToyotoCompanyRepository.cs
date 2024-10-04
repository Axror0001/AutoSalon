using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.Models.Companys.Toyoto;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.ToyotoCompanyRepository
{
    public class ToyotoCompanyRepository : IToyotoCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public ToyotoCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<Toyotocompanys?> CreateAsync(Toyotocompanys toyotoCompany, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Toyotocompanys toyotoCompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Toyotocompanys>> GetAllToyotocompanys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToyotoCompanyResponce>> GetAllToyotocompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToyotoCompanyResponce>> GetAllToyotocompanysList(string culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Toyotocompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Toyotocompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsername(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Toyotocompanys> UpdateToyotocompanysAsync(Toyotocompanys toyotoCompany, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
