using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.Toyoto;
using AutoSalonAPI.Mapper.CompanyMapper.ToyotoCompanyMapper;
using AutoSalonAPI.Reposiotry.CompanyRepository.ToyotoCompanyRepository;

namespace AutoSalonAPI.Service.CompanyService
{
    public class ToyotoCompanyService
    {
        private readonly IToyotoCompanyRepository _toyotoCompanyRepository;
        public ToyotoCompanyService(IToyotoCompanyRepository toyotoCompanyRepository)
        {
            this._toyotoCompanyRepository = toyotoCompanyRepository;
        }
        public async Task<ToyotoCompanyDtos> CreateAsync(ToyotoCompanyDtos ToyotoCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (ToyotoCompanyDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = ToyotoCompanyDtos.ToEntity();
                    entity.Code = ToyotoCompanyDtos.Code.Trim() ?? string.Empty;
                    entity.CompanyName = ToyotoCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    entity.CompanyBreand = ToyotoCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    entity.Country = ToyotoCompanyDtos.Country.Trim() ?? string.Empty;

                    entity.Translations = new List<ToyotoTranslationCompany>();
                    entity.Translations = ToyotoCompanyDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _toyotoCompanyRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<ToyotoCompanyDtos> UpdateAsync(ToyotoCompanyDtos ToyotoCompanyDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _toyotoCompanyRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.CompanyName = ToyotoCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    result.CompanyBreand = ToyotoCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    result.Country = ToyotoCompanyDtos.Country.Trim() ?? string.Empty;
                    result.Code = ToyotoCompanyDtos.Code.Trim();
                    result.Translations = ToyotoCompanyDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _toyotoCompanyRepository.UpdateToyotocompanysAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ToyotoCompanyDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _toyotoCompanyRepository.GetAllToyotocompanys(cancellationToken);

                return result.Select(s => new ToyotoCompanyDtos()
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
        public async Task<Boolean> Delete(ToyotoCompanyDtos ToyotoCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _toyotoCompanyRepository.GetById(ToyotoCompanyDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = ToyotoCompanyDtos.ToEntity();
                    return await _toyotoCompanyRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ToyotoCompanyResponce>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _toyotoCompanyRepository.GetAllToyotocompanysByCultureAsync(language, cancellationToken: cancellationToken);
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
