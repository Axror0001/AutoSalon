using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.Toyoto;
using AutoSalonAPI.Mapper.CarMapper.ToyotoMapper;
using AutoSalonAPI.Reposiotry.CarRepository.ToyotoRepository;

namespace AutoSalonAPI.Service.CarService
{
    public class ToyotoService
    {
        private readonly IToyotoRepository _toyotoRepository;
        public ToyotoService(IToyotoRepository toyotoRepository)
        {
            this._toyotoRepository = toyotoRepository;
        }
        public async Task<ToyotoDtos> CreateAsync(ToyotoDtos toyotoDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (toyotoDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = toyotoDtos.ToEntity();
                    entity.Code = toyotoDtos.Code.Trim() ?? string.Empty;
                    entity.Name = toyotoDtos.Name.Trim() ?? string.Empty;
                    entity.Color = toyotoDtos.Color.Trim() ?? string.Empty;

                    entity.Translations = new List<ToyotoTranslation>();
                    entity.Translations = toyotoDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _toyotoRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<ToyotoDtos> UpdateAsync(ToyotoDtos ToyotoDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _toyotoRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.Color = ToyotoDtos.Color.Trim();
                    result.Name = ToyotoDtos.Name.Trim();
                    result.Code = ToyotoDtos.Code.Trim();
                    result.Translations = ToyotoDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _toyotoRepository.UpdateToyotoAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ToyotoDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _toyotoRepository.GetAllToyotos(cancellationToken);

                return result.Select(s => new ToyotoDtos()
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<Boolean> Delete(ToyotoDtos ToyotoDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _toyotoRepository.GetById(ToyotoDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = ToyotoDtos.ToEntity();
                    return await _toyotoRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ToyotoResponse>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _toyotoRepository.GetAllToyotoByCultureAsync(language, cancellationToken: cancellationToken);
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
