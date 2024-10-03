using AutoMapper;
using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.Chevrolet;
using AutoSalonAPI.Profile.CarProfile.ChevroletProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CarMapper.ChevroletMapper
{
    public static class ChevroletMapper
    {
        private static readonly IMapper _mapper;
        static ChevroletMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<ChevroletProfile>()).CreateMapper();
        }

        public static PaginationModel<ChevroletResponse> ToPagedListDto(this List<Chevroletcars>? options, int page, int limit, int total)
        {
            IEnumerable<ChevroletResponse>? sourceList = _mapper.Map<List<Chevroletcars>, List<ChevroletResponse>>(options);

            return new PaginationModel<ChevroletResponse>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static ChevroletTranslation ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, ChevroletTranslation>(translation);

        public static ChevroletTranslation ToEntityMapper(this TranslationDto translation, ChevroletTranslation destionation)
            => _mapper.Map(translation, destionation);


        public static ChevroletDtos ToModel(this Chevroletcars options)
            => _mapper.Map<ChevroletDtos>(options);

        public static Chevroletcars ToEntity(this ChevroletDtos optionsDTO)
            => _mapper.Map<ChevroletDtos, Chevroletcars>(optionsDTO);
    }
}
