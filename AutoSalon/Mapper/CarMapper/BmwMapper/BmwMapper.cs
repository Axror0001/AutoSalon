using AutoMapper;
using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.BMW;
using AutoSalonAPI.Profile.CarProfile.BmwProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CarMapper.BmwMapper
{
    public static class BmwMapper
    {
        private static readonly IMapper _mapper;
        static BmwMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<BmwProfile>()).CreateMapper();
        }

        public static PaginationModel<BmwResponse> ToPagedListDto(this List<BMWcars>? options, int page, int limit, int total)
        {
            IEnumerable<BmwResponse>? sourceList = _mapper.Map<List<BMWcars>, List<BmwResponse>>(options);

            return new PaginationModel<BmwResponse>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static BMWTranslation ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, BMWTranslation>(translation);

        public static BMWTranslation ToEntityMapper(this TranslationDto translation, BMWTranslation destionation)
            => _mapper.Map(translation, destionation);


        public static BmwDTOs ToModel(this BMWcars options)
            => _mapper.Map<BmwDTOs>(options);

        public static BMWcars ToEntity(this BmwDTOs optionsDTO)
            => _mapper.Map<BmwDTOs, BMWcars>(optionsDTO);
    }
}
