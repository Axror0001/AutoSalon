using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.Models.Companys.BYD;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.BydCompanyRepository
{
    public class BydCompanyRepository : IBydCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public BydCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<BYDcompanys?> CreateAsync(BYDcompanys BYDcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BYDcompanys bydcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BYDcompanys>> GetAllBYDcompanys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BydCompanyResponce>> GetAllBYDcompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<BydCompanyResponce>> GetAllBYDcompanysList(string culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BYDcompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BYDcompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsername(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BYDcompanys> UpdateBYDcompanysAsync(BYDcompanys BYDcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
