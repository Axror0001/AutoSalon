using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.BMW;
using AutoSalonAPI.Mapper.CarMapper.BmwMapper;
using AutoSalonAPI.Reposiotry.CarRepository.BmwRepository;

namespace AutoSalonAPI.Service.CarService
{
    public class BmwService
    {
        private readonly IBmwRepository _bmwRepository;
        public BmwService(IBmwRepository bmwRepository)
        {
            _bmwRepository = bmwRepository;
        }
        public async Task<BmwDTOs> CreateAsync(BmwDTOs bmwdDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if(bmwdDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = bmwdDtos.ToEntity();
                    entity.Code = bmwdDtos.Code.Trim() ?? string.Empty;
                    entity.Name = bmwdDtos.Name.Trim() ?? string.Empty;
                    entity.Color = bmwdDtos.Color.Trim() ?? string.Empty;
                    
                    entity.Translations = new List<BMWTranslation>();
                    entity.Translations = bmwdDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach(var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _bmwRepository.CreateAsync(entity, cancellationToken);
                        if(result is not null)
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
        public async Task<BmwDTOs> UpdateAsync(BmwDTOs bmwDTOs, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bmwRepository.GetById(id, cancellationToken: cancellationToken);
                if(result is null)
                {
                    return null;
                }
                else
                {
                    result.Color = bmwDTOs.Color.Trim();
                    result.Name = bmwDTOs.Name.Trim();
                    result.Code = bmwDTOs.Code.Trim();
                    result.Translations = bmwDTOs.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _bmwRepository.UpdateBmwAsync(result, cancellationToken : cancellationToken);
                    return result.ToModel();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BmwDTOs>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bmwRepository.GetAllBmw(cancellationToken);

                return result.Select(s => new BmwDTOs()
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Color = s.Color,
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<Boolean> Delete(BmwDTOs bmwDTOs, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _bmwRepository.GetById(bmwDTOs.Id, cancellationToken : cancellationToken);
                
                if(entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = bmwDTOs.ToEntity();
                   return await _bmwRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<BmwResponse>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bmwRepository.GetAllBmwByCultureAsync(language, cancellationToken: cancellationToken);
                return !result.Any() ? throw new Exception("BmwNotFoundDoesnd") : result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}
