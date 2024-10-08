using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.Models.Companys.BYD;
using AutoSalon.Models.Companys.Chevrolet;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.ChevroletCompanyRepository
{
    public class ChevroletRepository : IChevroletCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public ChevroletRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Chevroletcompanys?> CreateAsync(Chevroletcompanys Chevroletcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcompanys.Where(x => x.Id.Equals(Chevroletcompanys.Id) && !x.IsDeleted
                && x.CompanyBreand.Equals(Chevroletcompanys.CompanyBreand)
                && x.CompanyName.Equals(Chevroletcompanys.CompanyName)
                && x.Country.Equals(Chevroletcompanys.Country)
                && x.CompanyDirector.Contains(Chevroletcompanys.CompanyDirector)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<ChevroletTranslationCompany>();
                    foreach (var item in Chevroletcompanys.Translation)
                    {
                        var oldTranslation = await translation.FirstOrDefaultAsync(x => x.Id == item.Id, cancellationToken);
                        if (oldTranslation != null)
                        {
                            oldTranslation.FullTitle = item.FullTitle.Trim();
                            oldTranslation.ShortTitle = item.ShortTitle.Trim();
                        }
                        else
                        {
                            oldTranslation.ChevroletId = item.Id;
                            await translation.AddAsync(item, cancellationToken);
                        }
                    }
                    await _dbContext.AddAsync(Chevroletcompanys, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return Chevroletcompanys;
                }
                else
                {
                    throw new Exception("this Company Already Exist table");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not Found this object" + ex.Message);
            }
        }

        public async Task<bool> Delete(Chevroletcompanys chevroletcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcompanys.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(chevroletcompanys.Id));
                chevroletcompanys.IsDeleted = true;
                await _dbContext.Chevroletcompanys.AddAsync(chevroletcompanys);
                await _dbContext.SaveChangesAsync();
                return chevroletcompanys.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }

        public async Task<IEnumerable<Chevroletcompanys>> GetAllChevroletcompanys(CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Chevroletcompanys.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<ChevroletCompanyResponce>> GetAllChevroletcompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Chevroletcompanys> result = await(_dbContext.Chevroletcompanys.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translation.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var chevroletResponceList = new List<ChevroletCompanyResponce>();
                foreach (var item in result)
                {
                    var chevroletResponce = new ChevroletCompanyResponce();
                    chevroletResponce.Id = item.Id;
                    chevroletResponce.Code = item.Code;
                    chevroletResponce.IsDeleted = item.IsDeleted;
                    chevroletResponce.CompanyBreand = item.CompanyBreand;
                    chevroletResponce.CompanyName = item.CompanyName;
                    chevroletResponce.Country = item.Country;
                    chevroletResponce.Title = item.Translation?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translation.FirstOrDefault()?.FullTitle ?? string.Empty;
                    chevroletResponce.ShortTitle = item.Translation?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translation.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    chevroletResponceList.Add(chevroletResponce);
                }
                return chevroletResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }
        public async Task<IPagedList<Chevroletcompanys>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.Chevroletcompanys.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<ChevroletCompanyResponce>> GetAllChevroletcompanysList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.Chevroletcompanys
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translation)
                .Select(s => new ChevroletCompanyResponce()
                {
                    Id = s.Id,
                    Code = s.Code,
                    CompanyName = s.CompanyName,
                    CompanyBreand = s.CompanyBreand,
                    Country = s.Country,
                    Title = s.Translation.FirstOrDefault(t => t.LanguageCode == culture).FullTitle ?? s.Translation.FirstOrDefault().FullTitle ?? string.Empty,
                    ShortTitle = s.Translation.FirstOrDefault(t => t.LanguageCode == culture).ShortTitle ?? s.Translation.FirstOrDefault().ShortTitle ?? string.Empty,
                });
                return await result.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository  GetAllBMWList");
            }
        }

        public Task<Chevroletcompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Chevroletcompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcompanys.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translation).ToListAsync();
                if (result is null || result.Count == 0)
                {
                    return null;
                }
                else
                {
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/GetById");
            }
        }

        public Task<string> GetUsername(string guid, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Chevroletcompanys> UpdateChevroletcompanysAsync(Chevroletcompanys Chevroletcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcompanys.Where(x => x.Id.Equals(Chevroletcompanys.Id) && !x.IsDeleted && x.CompanyName.Equals(Chevroletcompanys.CompanyName) && x.CompanyBreand.Equals(Chevroletcompanys.CompanyBreand) && x.Country.Contains(Chevroletcompanys.Country)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.Chevroletcompanys.AddAsync(Chevroletcompanys, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return Chevroletcompanys;
                }
                else
                {
                    _dbContext.Chevroletcompanys.Update(Chevroletcompanys);
                    await _dbContext.SaveChangesAsync();
                    return Chevroletcompanys;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
