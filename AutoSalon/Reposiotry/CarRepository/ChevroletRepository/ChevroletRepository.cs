using AutoSalon.Data;
using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.Models.Cars.Chevrolet;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AutoSalonAPI.Reposiotry.CarRepository.ChevroletRepository
{
    public class ChevroletRepository : IChevroletRepository
    {
        private readonly AppDbContext _dbContext;
        public ChevroletRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Chevroletcars?> CreateAsync(Chevroletcars Chevroletcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcars.Where(x => x.Id.Equals(Chevroletcars.Id) && !x.IsDeleted && x.Color.Equals(Chevroletcars.Color) && x.CompanyId.Equals(Chevroletcars.CompanyId) && x.Name.Contains(Chevroletcars.Name)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<ChevroletTranslation>();
                    foreach (var item in Chevroletcars.Translations)
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
                    await _dbContext.AddAsync(Chevroletcars, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return Chevroletcars;
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

        public async Task<bool> Delete(Chevroletcars chevroletcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcars.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(chevroletcars.Id), cancellationToken);
                chevroletcars.IsDeleted = true;
                await _dbContext.Chevroletcars.AddAsync(chevroletcars, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return chevroletcars.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Repository/Delete");
            }
        }

        public async Task<IEnumerable<Chevroletcars>> GetAllChevrolet(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcars.Where(x => x.IsDeleted.Equals(false)).ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<ChevroletResponse>> GetAllChevroletByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Chevroletcars> result = await(_dbContext.Chevroletcars.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var ChevroletResponceList = new List<ChevroletResponse>();
                foreach (var item in result)
                {
                    var ChevroletResponce = new ChevroletResponse();
                    ChevroletResponce.Id = item.Id;
                    ChevroletResponce.Code = item.Code;
                    ChevroletResponce.Title = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translations.FirstOrDefault()?.FullTitle ?? string.Empty;
                    ChevroletResponce.ShortTitle = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translations.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    ChevroletResponceList.Add(ChevroletResponce);
                }
                return ChevroletResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }
        public async Task<IPagedList<Chevroletcars>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.Chevroletcars.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<ChevroletResponse>> GetAllChevroletList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.Chevroletcars
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new ChevroletResponse()
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

        public Task<Chevroletcars?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Chevroletcars?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcars.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync(cancellationToken);
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

        public async Task<Chevroletcars> UpdateChevroletAsync(Chevroletcars chevroletcars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Chevroletcars.Where(x => x.Id.Equals(chevroletcars.Id) && !x.IsDeleted && x.Color.Equals(chevroletcars.Color) && x.CompanyId.Equals(chevroletcars.CompanyId) && x.Name.Contains(chevroletcars.Name)).ToListAsync(cancellationToken);
                if (result is null)
                {
                    await _dbContext.Chevroletcars.AddAsync(chevroletcars, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return chevroletcars;
                }
                else
                {
                    _dbContext.Chevroletcars.Update(chevroletcars);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return chevroletcars;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
