using AutoSalon.Data;
using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.Models.Cars.BMW;
using AutoSalon.Models.Cars.BYD;
using AutoSalon.Models.Companys.BMW;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.BmwCompanyRepository
{
    public class BmwCompanyRepository : IBmwCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public BmwCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BMWcompanys?> CreateAsync(BMWcompanys bmwcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcompanys.Where(x => x.Id.Equals(bmwcompanys.Id) && !x.IsDeleted
                && x.CompanyBreand.Equals(bmwcompanys.CompanyBreand)
                && x.CompanyName.Equals(bmwcompanys.CompanyName)
                &&x.Country.Equals(bmwcompanys.Country)
                && x.CompanyDirector.Contains(bmwcompanys.CompanyDirector)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<BmwTranslationCompany>();
                    foreach (var item in bmwcompanys.Translations)
                    {
                        var oldTranslation = await translation.FirstOrDefaultAsync(x => x.Id == item.Id, cancellationToken);
                        if (oldTranslation != null)
                        {
                            oldTranslation.FullTitle = item.FullTitle.Trim();
                            oldTranslation.ShortTitle = item.ShortTitle.Trim();
                        }
                        else
                        {
                            oldTranslation.bmwId = item.Id;
                            await translation.AddAsync(item, cancellationToken);
                        }
                    }
                    await _dbContext.AddAsync(bmwcompanys, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return bmwcompanys;
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

        public async Task<bool> Delete(BMWcompanys bydcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcompanys.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(bydcompanys.Id));
                bydcompanys.IsDeleted = true;
                await _dbContext.BMWcompanys.AddAsync(bydcompanys);
                await _dbContext.SaveChangesAsync();
                return bydcompanys.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }

        public async Task<IEnumerable<BMWcompanys>> GetAllBMWcompanys(CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.BMWcompanys.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<BmwCompanyResponce>> GetAllBMWcompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<BMWcompanys> result = await(_dbContext.BMWcompanys.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var bmwResponceList = new List<BmwCompanyResponce>();
                foreach (var item in result)
                {
                    var bmwResponce = new BmwCompanyResponce();
                    bmwResponce.Id = item.Id;
                    bmwResponce.Code = item.Code;
                    bmwResponce.IsDeleted = item.IsDeleted;
                    bmwResponce.CompanyBreand = item.CompanyBreand;
                    bmwResponce.CompanyName = item.CompanyName;
                    bmwResponce.Country = item.Country;
                    bmwResponce.Title = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translations.FirstOrDefault()?.FullTitle ?? string.Empty;
                    bmwResponce.ShortTitle = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translations.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    bmwResponceList.Add(bmwResponce);
                }
                return bmwResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }
        public async Task<IPagedList<BMWcompanys>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.BMWcompanys.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }

        public async Task<List<BmwCompanyResponce>> GetAllBMWcompanysList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.BMWcompanys
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new BmwCompanyResponce()
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

        public Task<BMWcompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BMWcompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcompanys.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync();
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

        public async Task<BMWcompanys> UpdateBMWcompanysAsync(BMWcompanys bmwcompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcompanys.Where(x => x.Id.Equals(bmwcompanys.Id) && !x.IsDeleted && x.CompanyName.Equals(bmwcompanys.CompanyName) && x.CompanyBreand.Equals(bmwcompanys.CompanyBreand) && x.Country.Contains(bmwcompanys.Country)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.BMWcompanys.AddAsync(bmwcompanys, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return bmwcompanys;
                }
                else
                {
                    _dbContext.BMWcompanys.Update(bmwcompanys);
                    await _dbContext.SaveChangesAsync();
                    return bmwcompanys;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
