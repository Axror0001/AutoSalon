using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.MersedensBens;
using AutoSalonAPI.Mapper.CompanyMapper.MersCompanyMapper;
using AutoSalonAPI.Reposiotry.CompanyRepository.MersCompanyRepository;

namespace AutoSalonAPI.Service.CompanyService
{
    public class MersCompanyService
    {
        private readonly IMersCompanyRepository _mersCompanyRepository;
        public MersCompanyService(IMersCompanyRepository mersCompanyRepository)
        {
            this._mersCompanyRepository = mersCompanyRepository;
        }
        public async Task<MersCompanyDtos> CreateAsync(MersCompanyDtos MersCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (MersCompanyDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = MersCompanyDtos.ToEntity();
                    entity.Code = MersCompanyDtos.Code.Trim() ?? string.Empty;
                    entity.CompanyName = MersCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    entity.CompanyBreand = MersCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    entity.Country = MersCompanyDtos.Country.Trim() ?? string.Empty;

                    entity.Translations = new List<MersTranslationCompany>();
                    entity.Translations = MersCompanyDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _mersCompanyRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<MersCompanyDtos> UpdateAsync(MersCompanyDtos MersCompanyDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mersCompanyRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.CompanyName = MersCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    result.CompanyBreand = MersCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    result.Country = MersCompanyDtos.Country.Trim() ?? string.Empty;
                    result.Code = MersCompanyDtos.Code.Trim();
                    result.Translations = MersCompanyDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _mersCompanyRepository.UpdateMersCompanyAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<MersCompanyDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mersCompanyRepository.GetAllMersCompany(cancellationToken);

                return result.Select(s => new MersCompanyDtos()
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
        public async Task<Boolean> Delete(MersCompanyDtos MersCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _mersCompanyRepository.GetById(MersCompanyDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = MersCompanyDtos.ToEntity();
                    return await _mersCompanyRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<MersCompanyResponce>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mersCompanyRepository.GetAllMersCompanyByCultureAsync(language, cancellationToken: cancellationToken);
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
