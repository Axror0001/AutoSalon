using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.BYD;
using AutoSalonAPI.Mapper.CarMapper.BydMapper;
using AutoSalonAPI.Reposiotry.CarRepository.BYDRepository;

namespace AutoSalonAPI.Service.CarService
{
    public class BydService
    {
        private readonly IBydRepository _bydRepository;
        public BydService(IBydRepository bydRepository)
        {
            this._bydRepository = bydRepository;
        }
        public async Task<BydDtos> CreateAsync(BydDtos bydDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (bydDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = bydDtos.ToEntity();
                    entity.Code = bydDtos.Code.Trim() ?? string.Empty;
                    entity.Name = bydDtos.Name.Trim() ?? string.Empty;
                    entity.Color = bydDtos.Color.Trim() ?? string.Empty;

                    entity.Translations = new List<BYDTranslation>();
                    entity.Translations = bydDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _bydRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<BydDtos> UpdateAsync(BydDtos BydDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bydRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.Color = BydDtos.Color.Trim();
                    result.Name = BydDtos.Name.Trim();
                    result.Code = BydDtos.Code.Trim();
                    result.Translations = BydDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _bydRepository.UpdateBydAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BydDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bydRepository.GetAllByd(cancellationToken);

                return result.Select(s => new BydDtos()
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
        public async Task<Boolean> Delete(BydDtos BydDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _bydRepository.GetById(BydDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = BydDtos.ToEntity();
                    return await _bydRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<BydResponse>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bydRepository.GetAllBydByCultureAsync(language, cancellationToken: cancellationToken);
                return !result.Any() ? throw new Exception("Not Found Doesnt") : result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
