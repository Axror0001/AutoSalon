using AutoSalon.Data;
using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.Models.Cars.Toyoto;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CarRepository.ToyotoRepository
{
    public class ToyotoRepository : IToyotoRepository
    {
        private readonly AppDbContext _dbContext;
        public ToyotoRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Toyotocars?> CreateAsync(Toyotocars toyoto, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocars.Where(x => x.Id.Equals(toyoto.Id) && !x.IsDeleted && x.Color.Equals(toyoto.Color) && x.CompanyId.Equals(toyoto.CompanyId) && x.Name.Contains(toyoto.Name)).ToListAsync(cancellationToken);
                if (result is null)
                {
                    var translation = _dbContext.Set<ToyotoTranslation>();
                    foreach (var item in toyoto.Translations)
                    {
                        var oldTranslation = await translation.FirstOrDefaultAsync(x => x.Id == item.Id, cancellationToken);
                        if (oldTranslation != null)
                        {
                            oldTranslation.FullTitle = item.FullTitle.Trim();
                            oldTranslation.ShortTitle = item.ShortTitle.Trim();
                        }
                        else
                        {
                            oldTranslation.ToyotoId = item.Id;
                            await translation.AddAsync(item, cancellationToken);
                        }
                    }
                    await _dbContext.AddAsync(toyoto, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return toyoto;
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

        public async Task<bool> Delete(Toyotocars toyotocars, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocars.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(toyotocars.Id), cancellationToken);
                toyotocars.IsDeleted = true;
                await _dbContext.Toyotocars.AddAsync(toyotocars, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return toyotocars.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Repository/Delete");
            }
        }

        public async Task<IEnumerable<ToyotoResponse>> GetAllToyotoByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Toyotocars> result = await(_dbContext.Toyotocars.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var MersResponceList = new List<ToyotoResponse>();
                foreach (var item in result)
                {
                    var MersResponce = new ToyotoResponse();
                    MersResponce.Id = item.Id;
                    MersResponce.Code = item.Code;
                    MersResponce.Title = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translations.FirstOrDefault()?.FullTitle ?? string.Empty;
                    MersResponce.ShortTitle = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translations.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    MersResponceList.Add(MersResponce);
                }
                return MersResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }

        public async Task<IEnumerable<Toyotocars>> GetAllToyotos(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocars.Where(x => x.IsDeleted.Equals(false)).ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<IPagedList<Toyotocars>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.Toyotocars.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<ToyotoResponse>> GetAllToyotosList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.Toyotocars
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new ToyotoResponse()
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

        public Task<Toyotocars?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Toyotocars?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocars.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync(cancellationToken);
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

        public async Task<Toyotocars> UpdateToyotoAsync(Toyotocars toyoto, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocars.Where(x => x.Id.Equals(toyoto.Id) && !x.IsDeleted && x.Color.Equals(toyoto.Color) && x.CompanyId.Equals(toyoto.CompanyId) && x.Name.Contains(toyoto.Name)).ToListAsync(cancellationToken);
                if (result is null)
                {
                    await _dbContext.Toyotocars.AddAsync(toyoto, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return toyoto;
                }
                else
                {
                    _dbContext.Toyotocars.Update(toyoto);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return toyoto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
