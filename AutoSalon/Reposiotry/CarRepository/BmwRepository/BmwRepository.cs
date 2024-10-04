using AutoSalon.Data;
using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.Models.Cars.BMW;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AutoSalonAPI.Reposiotry.CarRepository.BmwRepository
{
    public class BmwRepository : IBmwRepository
    {
        private readonly AppDbContext _dbContext;
        public BmwRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BMWcars?> CreateAsync(BMWcars bmwcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcars.Where(x => x.Id.Equals(bmwcars.Id) && !x.IsDeleted && x.Color.Equals(bmwcars.Color) && x.CompanyId.Equals(bmwcars.CompanyId) && x.Name.Contains(bmwcars.Name)).ToListAsync();
                if(result is null)
                {
                    var translation = _dbContext.Set<BMWTranslation>();
                    foreach(var item in bmwcars.Translations)
                    {
                        var oldTranslation = await translation.FirstOrDefaultAsync(x => x.Id == item.Id, cancellationToken);
                        if(oldTranslation != null)
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
                    await _dbContext.AddAsync(bmwcars, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return bmwcars;
                }
                else
                {
                    throw new Exception("this Cars Already Exist table");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not Found this object" + ex.Message);
            }
        }
        public async Task<BMWcars> UpdateBmwAsync(BMWcars bmwcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcars.Where(x => x.Id.Equals(bmwcars.Id) && !x.IsDeleted && x.Color.Equals(bmwcars.Color) && x.CompanyId.Equals(bmwcars.CompanyId) && x.Name.Contains(bmwcars.Name)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.BMWcars.AddAsync(bmwcars, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return bmwcars;
                }
                else
                {
                     _dbContext.BMWcars.Update(bmwcars);
                    await _dbContext.SaveChangesAsync();
                    return bmwcars;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }

        public async Task<IEnumerable<BMWcars>> GetAllBmw(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcars.Where(x => x.IsDeleted.Equals(false)).ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BmwResponse>> GetAllBmwByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<BMWcars> result = await (_dbContext.BMWcars.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var bmwResponceList = new List<BmwResponse>();
                foreach (var item in result)
                {
                    var bmwResponce = new BmwResponse();
                    bmwResponce.Id = item.Id;
                    bmwResponce.Code = item.Code;
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
        public async Task<IPagedList<BMWcars>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.BMWcars.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<BmwResponse>> GetAllBmwList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.BMWcars
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new BmwResponse()
                {
                    Id = s.Id,
                    Code = s.Code,
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

        public Task<BMWcars?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BMWcars?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcars.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync();
                if(result is null || result.Count == 0)
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

        public async Task<bool> Delete(BMWcars bmwcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BMWcars.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(bmwcars.Id));
                bmwcars.IsDeleted = true;
                await _dbContext.BMWcars.AddAsync(bmwcars);
                await _dbContext.SaveChangesAsync();
                return bmwcars.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }
    }
}
