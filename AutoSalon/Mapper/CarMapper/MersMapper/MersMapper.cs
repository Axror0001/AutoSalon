using AutoMapper;
using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.MersedensBens;
using AutoSalonAPI.Profile.CarProfile.MersProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CarMapper.MersMapper
{
    public static class MersMapper
    {
        private static readonly IMapper _mapper;
        static MersMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<MersProfile>()).CreateMapper();
        }

        public static PaginationModel<MersReponse> ToPagedListDto(this List<MersedensBenscars>? options, int page, int limit, int total)
        {
            IEnumerable<MersReponse>? sourceList = _mapper.Map<List<MersedensBenscars>, List<MersReponse>>(options);

            return new PaginationModel<MersReponse>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static MersTranslation ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, MersTranslation>(translation);

        public static MersTranslation ToEntityMapper(this TranslationDto translation, MersTranslation destionation)
            => _mapper.Map(translation, destionation);


        public static MersDtos ToModel(this MersedensBenscars options)
            => _mapper.Map<MersDtos>(options);

        public static MersedensBenscars ToEntity(this MersDtos optionsDTO)
            => _mapper.Map<MersDtos, MersedensBenscars>(optionsDTO);
    }
}
