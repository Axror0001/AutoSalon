using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.Models.Companys.Toyoto;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.ToyotoCompanyRepository
{
    public class ToyotoCompanyRepository : IToyotoCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public ToyotoCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Toyotocompanys?> CreateAsync(Toyotocompanys toyotoCompany, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocompanys.Where(x => x.Id.Equals(toyotoCompany.Id) && !x.IsDeleted
                && x.CompanyBreand.Equals(toyotoCompany.CompanyBreand)
                && x.CompanyName.Equals(toyotoCompany.CompanyName)
                && x.Country.Equals(toyotoCompany.Country)
                && x.CompanyDirector.Contains(toyotoCompany.CompanyDirector)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<ToyotoTranslationCompany>();
                    foreach (var item in toyotoCompany.Translations)
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
                    await _dbContext.AddAsync(toyotoCompany, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return toyotoCompany;
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

        public async Task<bool> Delete(Toyotocompanys toyotoCompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocompanys.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(toyotoCompanys.Id));
                toyotoCompanys.IsDeleted = true;
                await _dbContext.Toyotocompanys.AddAsync(toyotoCompanys);
                await _dbContext.SaveChangesAsync();
                return toyotoCompanys.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }

        public async Task<IEnumerable<Toyotocompanys>> GetAllToyotocompanys(CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Toyotocompanys.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<ToyotoCompanyResponce>> GetAllToyotocompanysByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Toyotocompanys> result = await(_dbContext.Toyotocompanys.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var toyotoCompanyResponceList = new List<ToyotoCompanyResponce>();
                foreach (var item in result)
                {
                    var toyotoCompanyResponce = new ToyotoCompanyResponce();
                    toyotoCompanyResponce.Id = item.Id;
                    toyotoCompanyResponce.Code = item.Code;
                    toyotoCompanyResponce.IsDeleted = item.IsDeleted;
                    toyotoCompanyResponce.CompanyBreand = item.CompanyBreand;
                    toyotoCompanyResponce.CompanyName = item.CompanyName;
                    toyotoCompanyResponce.Country = item.Country;
                    toyotoCompanyResponce.Title = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translations.FirstOrDefault()?.FullTitle ?? string.Empty;
                    toyotoCompanyResponce.ShortTitle = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translations.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    toyotoCompanyResponceList.Add(toyotoCompanyResponce);
                }
                return toyotoCompanyResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }
        public async Task<IPagedList<Toyotocompanys>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.Toyotocompanys.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<ToyotoCompanyResponce>> GetAllToyotocompanysList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.Toyotocompanys
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new ToyotoCompanyResponce()
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

        public Task<Toyotocompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Toyotocompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocompanys.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync();
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

        public async Task<Toyotocompanys> UpdateToyotocompanysAsync(Toyotocompanys toyotoCompany, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Toyotocompanys.Where(x => x.Id.Equals(toyotoCompany.Id) && !x.IsDeleted && x.CompanyName.Equals(toyotoCompany.CompanyName) && x.CompanyBreand.Equals(toyotoCompany.CompanyBreand) && x.Country.Contains(toyotoCompany.Country)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.Toyotocompanys.AddAsync(toyotoCompany, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return toyotoCompany;
                }
                else
                {
                    _dbContext.Toyotocompanys.Update(toyotoCompany);
                    await _dbContext.SaveChangesAsync();
                    return toyotoCompany;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
