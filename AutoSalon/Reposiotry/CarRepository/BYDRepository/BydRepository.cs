using AutoSalon.Data;
using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.Models.Cars.BYD;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CarRepository.BYDRepository
{
    public class BydRepository : IBydRepository
    {
        private readonly AppDbContext _dbContext;
        public BydRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BYDcars?> CreateAsync(BYDcars BYDcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcars.Where(x => x.Id.Equals(BYDcars.Id) && !x.IsDeleted && x.Color.Equals(BYDcars.Color) && x.CompanyId.Equals(BYDcars.CompanyId) && x.Name.Contains(BYDcars.Name)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<BYDTranslation>();
                    foreach (var item in BYDcars.Translations)
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
                    await _dbContext.AddAsync(BYDcars, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return BYDcars;
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

        public async Task<IEnumerable<BYDcars>> GetAllByd(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcars.Where(x => x.IsDeleted.Equals(false)).ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<BydResponse>> GetAllBydByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<BYDcars> result = await(_dbContext.BYDcars.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var bydResponceList = new List<BydResponse>();
                foreach (var item in result)
                {
                    var bydResponce = new BydResponse();
                    bydResponce.Id = item.Id;
                    bydResponce.Code = item.Code;
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
        public async Task<IPagedList<BYDcars>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.BYDcars.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<BydResponse>> GetAllBydList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.BYDcars
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new BydResponse()
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
                throw new Exception(ex.Message + "BYDRepository  GetAllBYDList");
            }
        }

        public Task<BYDcars?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BYDcars?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcars.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync(cancellationToken);
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

        public async Task<BYDcars> UpdateBydAsync(BYDcars BYDcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcars.Where(x => x.Id.Equals(BYDcars.Id) && !x.IsDeleted && x.Color.Equals(BYDcars.Color) && x.CompanyId.Equals(BYDcars.CompanyId) && x.Name.Contains(BYDcars.Name)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.BYDcars.AddAsync(BYDcars, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return BYDcars;
                }
                else
                {
                    _dbContext.BYDcars.Update(BYDcars);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return BYDcars;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }

        public async Task<bool> Delete(BYDcars BYDcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.BYDcars.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(BYDcars.Id), cancellationToken);
                BYDcars.IsDeleted = true;
                await _dbContext.BYDcars.AddAsync(BYDcars, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return BYDcars.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }
    }
}
