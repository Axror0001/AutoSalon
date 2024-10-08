using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.Models.Companys.BYD;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.BydCompanyRepository
{
    public class BydCompanyRepository : IBydCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public BydCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BYDcompanys?> CreateAsync(BYDcompanys BYDcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcompanys.Where(x => x.Id.Equals(BYDcompanys.Id) && !x.IsDeleted
                && x.CompanyBreand.Equals(BYDcompanys.CompanyBreand)
                && x.CompanyName.Equals(BYDcompanys.CompanyName)
                && x.Country.Equals(BYDcompanys.Country)
                && x.CompanyDirector.Contains(BYDcompanys.CompanyDirector)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<BYDTranslationCompany>();
                    foreach (var item in BYDcompanys.Translations)
                    {
                        var oldTranslation = await translation.FirstOrDefaultAsync(x => x.Id == item.Id, cancellationToken);
                        if (oldTranslation != null)
                        {
                            oldTranslation.FullTitle = item.FullTitle.Trim();
                            oldTranslation.ShortTitle = item.ShortTitle.Trim();
                        }
                        else
                        {
                            oldTranslation.bydId = item.Id;
                            await translation.AddAsync(item, cancellationToken);
                        }
                    }
                    await _dbContext.AddAsync(BYDcompanys, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return BYDcompanys;
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

        public async Task<bool> Delete(BYDcompanys bydcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcompanys.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(bydcompanys.Id));
                bydcompanys.IsDeleted = true;
                await _dbContext.BYDcompanys.AddAsync(bydcompanys);
                await _dbContext.SaveChangesAsync();
                return bydcompanys.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }

        public async Task<IEnumerable<BYDcompanys>> GetAllBYDcompanys(CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.BYDcompanys.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<BydCompanyResponce>> GetAllBYDcompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<BYDcompanys> result = await(_dbContext.BYDcompanys.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var bydResponceList = new List<BydCompanyResponce>();
                foreach (var item in result)
                {
                    var bydResponce = new BydCompanyResponce();
                    bydResponce.Id = item.Id;
                    bydResponce.Code = item.Code;
                    bydResponce.IsDeleted = item.IsDeleted;
                    bydResponce.CompanyBreand = item.CompanyBreand;
                    bydResponce.CompanyName = item.CompanyName;
                    bydResponce.Country = item.Country;
                    bydResponce.Title = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translations.FirstOrDefault()?.FullTitle ?? string.Empty;
                    bydResponce.ShortTitle = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translations.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    bydResponceList.Add(bydResponce);
                }
                return bydResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }
        public async Task<IPagedList<BYDcompanys>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.BYDcompanys.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<BydCompanyResponce>> GetAllBYDcompanysList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.BYDcompanys
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new BydCompanyResponce()
                {
                    Id = s.Id,
                    Code = s.Code,
                    CompanyName = s.CompanyName,
                    CompanyBreand = s.CompanyBreand,
                    Country = s.Country,
                    Title = s.Translations.FirstOrDefault(t => t.LanguageCode == culture).FullTitle ?? s.Translations.FirstOrDefault().FullTitle ?? string.Empty,
                    ShortTitle = s.Translations.FirstOrDefault(t => t.LanguageCode == culture).ShortTitle ?? s.Translations.FirstOrDefault().ShortTitle ?? string.Empty,
                });
                return await result.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository  GetAllBMWList");
            }
        }

        public Task<BYDcompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BYDcompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcompanys.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync();
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

        public async Task<BYDcompanys> UpdateBYDcompanysAsync(BYDcompanys BYDcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcompanys.Where(x => x.Id.Equals(BYDcompanys.Id) && !x.IsDeleted && x.CompanyName.Equals(BYDcompanys.CompanyName) && x.CompanyBreand.Equals(BYDcompanys.CompanyBreand) && x.Country.Contains(BYDcompanys.Country)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.BYDcompanys.AddAsync(BYDcompanys, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return BYDcompanys;
                }
                else
                {
                    _dbContext.BYDcompanys.Update(BYDcompanys);
                    await _dbContext.SaveChangesAsync();
                    return BYDcompanys;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
