using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.Chevrolet;
using AutoSalonAPI.Mapper.CarMapper.ChevroletMapper;
using AutoSalonAPI.Reposiotry.CarRepository.ChevroletRepository;

namespace AutoSalonAPI.Service.CarService
{
    public class ChevroletService
    {
        private readonly IChevroletRepository _chevroletRepository;
        public ChevroletService(IChevroletRepository chevroletRepository)
        {
            this._chevroletRepository = chevroletRepository;
        }
        public async Task<ChevroletDtos> CreateAsync(ChevroletDtos chevroletDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (chevroletDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = chevroletDtos.ToEntity();
                    entity.Code = chevroletDtos.Code.Trim() ?? string.Empty;
                    entity.Name = chevroletDtos.Name.Trim() ?? string.Empty;
                    entity.Color = chevroletDtos.Color.Trim() ?? string.Empty;

                    entity.Translations = new List<ChevroletTranslation>();
                    entity.Translations = chevroletDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _chevroletRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<ChevroletDtos> UpdateAsync(ChevroletDtos ChevroletDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _chevroletRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.Color = ChevroletDtos.Color.Trim();
                    result.Name = ChevroletDtos.Name.Trim();
                    result.Code = ChevroletDtos.Code.Trim();
                    result.Translations = ChevroletDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _chevroletRepository.UpdateChevroletAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ChevroletDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _chevroletRepository.GetAllChevrolet(cancellationToken);

                return result.Select(s => new ChevroletDtos()
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
        public async Task<Boolean> Delete(ChevroletDtos ChevroletDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _chevroletRepository.GetById(ChevroletDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = ChevroletDtos.ToEntity();
                    return await _chevroletRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ChevroletResponse>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _chevroletRepository.GetAllChevroletByCultureAsync(language, cancellationToken: cancellationToken);
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
