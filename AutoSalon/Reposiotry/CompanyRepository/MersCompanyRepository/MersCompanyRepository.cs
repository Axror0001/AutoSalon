using AutoSalon.Data;
using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.Models.Companys.MersedensBens;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace AutoSalonAPI.Reposiotry.CompanyRepository.MersCompanyRepository
{
    public class MersCompanyRepository : IMersCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public MersCompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<MersedensBenscompanys?> CreateAsync(MersedensBenscompanys mersCompany, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscompanys.Where(x => x.Id.Equals(mersCompany.Id) && !x.IsDeleted
                && x.CompanyBreand.Equals(mersCompany.CompanyBreand)
                && x.CompanyName.Equals(mersCompany.CompanyName)
                && x.Country.Equals(mersCompany.Country)
                && x.CompanyDirector.Contains(mersCompany.CompanyDirector)).ToListAsync();
                if (result is null)
                {
                    var translation = _dbContext.Set<MersTranslationCompany>();
                    foreach (var item in mersCompany.Translations)
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
                    await _dbContext.AddAsync(mersCompany, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return mersCompany;
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

        public async Task<bool> Delete(MersedensBenscompanys merscompanys, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscompanys.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(merscompanys.Id));
                merscompanys.IsDeleted = true;
                await _dbContext.MersedensBenscompanys.AddAsync(merscompanys);
                await _dbContext.SaveChangesAsync();
                return merscompanys.IsDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWRepository/Delete");
            }
        }

        public async Task<IEnumerable<MersedensBenscompanys>> GetAllMersCompany(CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.MersedensBenscompanys.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<MersCompanyResponce>> GetAllMersCompanyByCultureAsync(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<MersedensBenscompanys> result = await(_dbContext.MersedensBenscompanys.Where(x => x.IsDeleted.Equals(false))
                .Include(x => x.Translations.Where(x => !x.IsDeleted && x.LanguageCode.Equals(language))))
                .ToListAsync(cancellationToken);
                var mersCompanyResponceList = new List<MersCompanyResponce>();
                foreach (var item in result)
                {
                    var mersCompanyResponce = new MersCompanyResponce();
                    mersCompanyResponce.Id = item.Id;
                    mersCompanyResponce.Code = item.Code;
                    mersCompanyResponce.IsDeleted = item.IsDeleted;
                    mersCompanyResponce.CompanyBreand = item.CompanyBreand;
                    mersCompanyResponce.CompanyName = item.CompanyName;
                    mersCompanyResponce.Country = item.Country;
                    mersCompanyResponce.Title = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.FullTitle ?? item.Translations.FirstOrDefault()?.FullTitle ?? string.Empty;
                    mersCompanyResponce.ShortTitle = item.Translations?.FirstOrDefault(x => x.LanguageCode.Equals(language))?.ShortTitle ?? item.Translations.FirstOrDefault()?.ShortTitle ?? string.Empty;

                    mersCompanyResponceList.Add(mersCompanyResponce);
                }
                return mersCompanyResponceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "BMWReposiotry GetAllBmwByCultureAsync");
            }
        }
        public async Task<IPagedList<MersedensBenscompanys>> FilteredByPagination(int page, int limit, string search, CancellationToken cancellationToken = default)
        {

            var positions = _dbContext.MersedensBenscompanys.AsQueryable();
            positions = positions.OrderByDescending(p => p.Id).Where(p => !p.IsDeleted);
            return positions.ToPagedList(page, limit);
        }
        public async Task<List<MersCompanyResponce>> GetAllMersCompanyList(string culture, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _dbContext.MersedensBenscompanys
                .Where(a => !a.IsDeleted)
                .Include(a => a.Translations)
                .Select(s => new MersCompanyResponce()
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

        public Task<MersedensBenscompanys?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<MersedensBenscompanys?> GetById(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscompanys.Where(x => x.Id.Equals(id) && !x.IsDeleted).Include(x => x.Translations).ToListAsync();
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

        public async Task<MersedensBenscompanys> UpdateMersCompanyAsync(MersedensBenscompanys mersCompany, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.MersedensBenscompanys.Where(x => x.Id.Equals(mersCompany.Id) && !x.IsDeleted && x.CompanyName.Equals(mersCompany.CompanyName) && x.CompanyBreand.Equals(mersCompany.CompanyBreand) && x.Country.Contains(mersCompany.Country)).ToListAsync();
                if (result is null)
                {
                    await _dbContext.MersedensBenscompanys.AddAsync(mersCompany, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return mersCompany;
                }
                else
                {
                    _dbContext.MersedensBenscompanys.Update(mersCompany);
                    await _dbContext.SaveChangesAsync();
                    return mersCompany;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Not Found thi Cars");
            }
        }
    }
}
