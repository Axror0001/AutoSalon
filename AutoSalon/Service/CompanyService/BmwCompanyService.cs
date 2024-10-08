using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.BMW;
using AutoSalonAPI.Mapper.CompanyMapper.BmwCompanyMapper;
using AutoSalonAPI.Reposiotry.CompanyRepository.BmwCompanyRepository;

namespace AutoSalonAPI.Service.CompanyService
{
    public class BmwCompanyService
    {
        private readonly IBmwCompanyRepository _bmwCompanyRepository;
        public BmwCompanyService(IBmwCompanyRepository bmwCompanyRepository)
        {
            this._bmwCompanyRepository = bmwCompanyRepository;
        }
        public async Task<BmwCompanyDtos> CreateAsync(BmwCompanyDtos bmwCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (bmwCompanyDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = bmwCompanyDtos.ToEntity();
                    entity.Code = bmwCompanyDtos.Code.Trim() ?? string.Empty;
                    entity.CompanyName = bmwCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    entity.CompanyBreand = bmwCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    entity.Country = bmwCompanyDtos.Country.Trim() ?? string.Empty;

                    entity.Translations = new List<BmwTranslationCompany>();
                    entity.Translations = bmwCompanyDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _bmwCompanyRepository.CreateAsync(entity, cancellationToken);
                        if (result is not null)
                        {
                            return result.ToModel();
                        }
                        else
                        {
                            throw new Exception("Jiddiy xato yuz berdi Create qilishda");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
        public async Task<BmwCompanyDtos> UpdateAsync(BmwCompanyDtos BmwCompanyDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bmwCompanyRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.CompanyName = BmwCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    result.CompanyBreand = BmwCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    result.Country = BmwCompanyDtos.Country.Trim() ?? string.Empty;
                    result.Code = BmwCompanyDtos.Code.Trim();
                    result.Translations = BmwCompanyDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _bmwCompanyRepository.UpdateBMWcompanysAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BmwCompanyDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bmwCompanyRepository.GetAllBMWcompanys(cancellationToken);

                return result.Select(s => new BmwCompanyDtos()
                {
                    Id = s.Id,
                    Code = s.Code,
                    CompanyBreand = s.CompanyBreand,
                    CompanyName = s.CompanyName,
                    Country = s.Country,
                    CreatedDate = s.CreatedDate.ToString("dd.MM.yyyy"),
                    CreatedBy = s.CreatedBy,
                    ModifiedDate = s.ModifiedDate.ToString("dd.MM.yyyy"),
                    ModifiedBy = s.ModifiedBy,
                    Translations = s.Translations.Select(a => new TranslationDto()
                    {
                        Id = a.Id,
                        FullTitle = a.FullTitle,
                        IsDeleted = a.IsDeleted,
                        LanguageCode = a.LanguageCode,
                        ShortTitle = a.ShortTitle
                    }).ToList(),
                    IsDeleted = s.IsDeleted
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<Boolean> Delete(BmwCompanyDtos BmwCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _bmwCompanyRepository.GetById(BmwCompanyDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = BmwCompanyDtos.ToEntity();
                    return await _bmwCompanyRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<BmwCompanyResponce>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bmwCompanyRepository.GetAllBMWcompanysByCultureAsync(language, cancellationToken: cancellationToken);
                return !result.Any() ? throw new Exception("BmwNotFoundDoesnd") : result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
