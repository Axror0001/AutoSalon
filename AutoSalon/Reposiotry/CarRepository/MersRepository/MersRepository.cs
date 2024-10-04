using AutoSalon.Data;
using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.Models.Cars.MersedensBens;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CarRepository.MersRepository
{
    public class MersRepository : IMersRepository
    {
        private readonly AppDbContext _dbContext;
        public MersRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<MersedensBenscars?> CreateAsync(MersedensBenscars mersedens, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscars.Where(x => x.Id.Equals(mersedens.Id) && !x.IsDeleted && x.Color.Equals(mersedens.Color) && x.CompanyId.Equals(mersedens.CompanyId) && x.Name.Contains(mersedens.Name)).ToListAsync(cancellationToken);
                if (result is null)
                {
                    var translation = _dbContext.Set<MersTranslation>();
                    foreach (var item in mersedens.Translations)
                    {
                        var oldTranslation = await translation.FirstOrDefaultAsync(x => x.Id == item.Id, cancellationToken);
                        if (oldTranslation != null)
                        {
                            oldTranslation.FullTitle = item.FullTitle.Trim();
                            oldTranslation.ShortTitle = item.ShortTitle.Trim();
                        }
                        else
                        {
                            oldTranslation.MersId = item.Id;
                            await translation.AddAsync(item, cancellationToken);
                        }
                    }
                    await _dbContext.AddAsync(mersedens, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return mersedens;
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

        public async Task<bool> Delete(MersedensBenscars mersedens, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscars.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(mersedens.Id), cancellationToken);
                mersedens.IsDeleted = true;
                await _dbContext.MersedensBenscars.AddAsync(mersedens, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return mersedens.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Repository/Delete");
            }
        }

        public async Task<IEnumerable<MersReponse>> GetAllMersByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<MersedensBenscars> result = await(_dbContext.MersedensBenscars.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var MersResponceList = new List<MersReponse>();
                foreach (var item in result)
                {
                    var MersResponce = new MersReponse();
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

        public async Task<IEnumerable<MersedensBenscars>> GetAllMerss(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscars.Where(x => x.IsDeleted.Equals(false)).ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<IPagedList<MersedensBenscars>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.MersedensBenscars.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<MersReponse>> GetAllMerssList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.MersedensBenscars
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new MersReponse()
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

        public Task<MersedensBenscars?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<MersedensBenscars?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscars.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync(cancellationToken);
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

        public async Task<MersedensBenscars> UpdateMersAsync(MersedensBenscars mersedens, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscars.Where(x => x.Id.Equals(mersedens.Id) && !x.IsDeleted && x.Color.Equals(mersedens.Color) && x.CompanyId.Equals(mersedens.CompanyId) && x.Name.Contains(mersedens.Name)).ToListAsync(cancellationToken);
                if (result is null)
                {
                    await _dbContext.MersedensBenscars.AddAsync(mersedens, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return mersedens;
                }
                else
                {
                    _dbContext.MersedensBenscars.Update(mersedens);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return mersedens;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
