using AutoMapper;
using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.BYD;
using AutoSalonAPI.Profile.CarProfile.BydProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CarMapper.BydMapper
{
    public static class BydMapper
    {
        private static readonly IMapper _mapper;
        static BydMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<BydProfile>()).CreateMapper();
        }

        public static PaginationModel<BydResponse> ToPagedListDto(this List<BYDcars>? options, int page, int limit, int total)
        {
            IEnumerable<BydResponse>? sourceList = _mapper.Map<List<BYDcars>, List<BydResponse>>(options);

            return new PaginationModel<BydResponse>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static BYDTranslation ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, BYDTranslation>(translation);

        public static BYDTranslation ToEntityMapper(this TranslationDto translation, BYDTranslation destionation)
            => _mapper.Map(translation, destionation);


        public static BydDtos ToModel(this BYDcars options)
            => _mapper.Map<BydDtos>(options);

        public static BYDcars ToEntity(this BydDtos optionsDTO)
            => _mapper.Map<BydDtos, BYDcars>(optionsDTO);
    }
}
