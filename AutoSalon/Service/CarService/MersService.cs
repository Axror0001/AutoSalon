using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.MersedensBens;
using AutoSalonAPI.Mapper.CarMapper.MersMapper;
using AutoSalonAPI.Reposiotry.CarRepository.MersRepository;

namespace AutoSalonAPI.Service.CarService
{
    public class MersService
    {
        private readonly IMersRepository _mersRepository;
        public MersService(IMersRepository mersRepository)
        {
            this._mersRepository = mersRepository;
        }
        public async Task<MersDtos> CreateAsync(MersDtos mersDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (mersDtos is null)
                {
                    return null;
                }
                else
                {
                    var entity = mersDtos.ToEntity();
                    entity.Code = mersDtos.Code.Trim() ?? string.Empty;
                    entity.Name = mersDtos.Name.Trim() ?? string.Empty;
                    entity.Color = mersDtos.Color.Trim() ?? string.Empty;

                    entity.Translations = new List<MersTranslation>();
                    entity.Translations = mersDtos.Translations.Select(x => x.ToEntityMapper()).ToList();
                    try
                    {
                        foreach (var item in entity.Translations)
                        {
                            item.FullTitle = item.FullTitle.Trim();
                            item.ShortTitle = item.ShortTitle.Trim();
                        }
                        var result = await _mersRepository.CreateAsync(entity, cancellationToken);
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
        public async Task<MersDtos> UpdateAsync(MersDtos MersDtos, long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mersRepository.GetById(id, cancellationToken: cancellationToken);
                if (result is null)
                {
                    return null;
                }
                else
                {
                    result.Color = MersDtos.Color.Trim();
                    result.Name = MersDtos.Name.Trim();
                    result.Code = MersDtos.Code.Trim();
                    result.Translations = MersDtos.Translations.Select(x => x.ToEntityMapper(result.Translations.FirstOrDefault(x => x.Id.Equals(id)))).ToList();
                    await _mersRepository.UpdateMersAsync(result, cancellationToken: cancellationToken);
                    return result.ToModel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<MersDtos>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mersRepository.GetAllMerss(cancellationToken);

                return result.Select(s => new MersDtos()
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
        public async Task<Boolean> Delete(MersDtos MersDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _mersRepository.GetById(MersDtos.Id, cancellationToken: cancellationToken);

                if (entity is null)
                {
                    throw new Exception("Not Found Id");
                }
                else
                {
                    entity = MersDtos.ToEntity();
                    return await _mersRepository.Delete(entity, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<MersReponse>> GetAllByLanguage(string language, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mersRepository.GetAllMersByCultureAsync(language, cancellationToken: cancellationToken);
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
