using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.Models.Companys.Chevrolet;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.ChevroletCompanyRepository
{
    public class ChevroletRepository : IChevroletCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public ChevroletRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<Chevroletcompanys?> CreateAsync(Chevroletcompanys Chevroletcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Chevroletcompanys chevroletcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chevroletcompanys>> GetAllChevroletcompanys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChevroletCompanyResponce>> GetAllChevroletcompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChevroletCompanyResponce>> GetAllChevroletcompanysList(string culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Chevroletcompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Chevroletcompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsername(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Chevroletcompanys> UpdateChevroletcompanysAsync(Chevroletcompanys Chevroletcompanys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
