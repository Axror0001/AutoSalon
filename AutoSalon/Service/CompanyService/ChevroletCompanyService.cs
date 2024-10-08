using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.Chevrolet;
using AutoSalonAPI.Mapper.CompanyMapper.ChevroletCompanyMapper;
using AutoSalonAPI.Reposiotry.CompanyRepository.ChevroletCompanyRepository;

namespace AutoSalonAPI.Service.CompanyService
{
    public class ChevroletCompanyService
    {
        private readonly IChevroletCompanyRepository _chevroletCompanyRepository;
        public ChevroletCompanyService(IChevroletCompanyRepository chevroletCompanyRepository)
        {
            this._chevroletCompanyRepository = chevroletCompanyRepository;
        }
        public async Task<ChevroletCompanyDtos> CreateAsync(ChevroletCompanyDtos ChevroletCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (ChevroletCompanyDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = ChevroletCompanyDtos.ToEntity();
                    entity.Code = ChevroletCompanyDtos.Code.Trim() ?? string.Empty;
                    entity.CompanyName = ChevroletCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    entity.CompanyBreand = ChevroletCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    entity.Country = ChevroletCompanyDtos.Country.Trim() ?? string.Empty;

                    entity.Translation = new List<ChevroletTranslationCompany>();
                    entity.Translation = ChevroletCompanyDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translation)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _chevroletCompanyRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<ChevroletCompanyDtos> UpdateAsync(ChevroletCompanyDtos ChevroletCompanyDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _chevroletCompanyRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.CompanyName = ChevroletCompanyDtos.CompanyName.Trim() ?? string.Empty;
                    result.CompanyBreand = ChevroletCompanyDtos.CompanyBreand.Trim() ?? string.Empty;
                    result.Country = ChevroletCompanyDtos.Country.Trim() ?? string.Empty;
                    result.Code = ChevroletCompanyDtos.Code.Trim();
                    result.Translation = ChevroletCompanyDtos.Translations.Select(x => x.ToEntityMapper(result.Translation.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _chevroletCompanyRepository.UpdateChevroletcompanysAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ChevroletCompanyDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _chevroletCompanyRepository.GetAllChevroletcompanys(cancellationToken);

                return result.Select(s => new ChevroletCompanyDtos()
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
                    Translations = s.Translation.Select(a => new TranslationDto()
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
        public async Task<Boolean> Delete(ChevroletCompanyDtos ChevroletCompanyDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _chevroletCompanyRepository.GetById(ChevroletCompanyDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = ChevroletCompanyDtos.ToEntity();
                    return await _chevroletCompanyRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ChevroletCompanyResponce>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _chevroletCompanyRepository.GetAllChevroletcompanysByCultureAsync(language, cancellationToken: cancellationToken);
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
