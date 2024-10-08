using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.BYD;
using AutoSalonAPI.Mapper.CompanyMapper.BydCompanyMapper;
using AutoSalonAPI.Reposiotry.CompanyRepository.BydCompanyRepository;

namespace AutoSalonAPI.Service.CompanyService
{
    public class BydCompanyService
    {
        private readonly IBydCompanyRepository _bydCompanyRepository;
        public BydCompanyService(IBydCompanyRepository bydCompanyRepository)
        {
            this._bydCompanyRepository = bydCompanyRepository;
        }
        public async Task<BydCompanyDtos> CreateAsync(BydCompanyDtos BydCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (BydCompanyDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = BydCompanyDtos.ToEntity();
                    entity.Code = BydCompanyDtos.Code.Trim() ?? string.Empty;
                    entity.CompanyName = BydCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    entity.CompanyBreand = BydCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    entity.Country = BydCompanyDtos.Country.Trim() ?? string.Empty;

                    entity.Translations = new List<BYDTranslationCompany>();
                    entity.Translations = BydCompanyDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _bydCompanyRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<BydCompanyDtos> UpdateAsync(BydCompanyDtos BydCompanyDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bydCompanyRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.CompanyName = BydCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    result.CompanyBreand = BydCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    result.Country = BydCompanyDtos.Country.Trim() ?? string.Empty;
                    result.Code = BydCompanyDtos.Code.Trim();
                    result.Translations = BydCompanyDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _bydCompanyRepository.UpdateBYDcompanysAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BydCompanyDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bydCompanyRepository.GetAllBYDcompanys(cancellationToken);

                return result.Select(s => new BydCompanyDtos()
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
        public async Task<Boolean> Delete(BydCompanyDtos BydCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _bydCompanyRepository.GetById(BydCompanyDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = BydCompanyDtos.ToEntity();
                    return await _bydCompanyRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<BydCompanyResponce>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bydCompanyRepository.GetAllBYDcompanysByCultureAsync(language, cancellationToken: cancellationToken);
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
