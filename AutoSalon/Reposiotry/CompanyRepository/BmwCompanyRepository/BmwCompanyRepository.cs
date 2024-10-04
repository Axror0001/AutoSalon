using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.Models.Companys.BMW;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.BmwCompanyRepository
{
    public class BmwCompanyRepository : IBmwCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public BmwCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<BMWcompanys?> CreateAsync(BMWcompanys bmwcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BMWcompanys bydcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BMWcompanys>> GetAllBMWcompanys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BmwCompanyResponce>> GetAllBMWcompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<BmwCompanyResponce>> GetAllBMWcompanysList(string culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BMWcompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BMWcompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsername(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BMWcompanys> UpdateBMWcompanysAsync(BMWcompanys bmwcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
