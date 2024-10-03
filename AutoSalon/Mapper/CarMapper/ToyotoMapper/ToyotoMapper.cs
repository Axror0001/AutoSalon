using AutoMapper;
using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.Chevrolet;
using AutoSalon.Models.Cars.Toyoto;
using AutoSalonAPI.Profile.CarProfile.ToyotoProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CarMapper.ToyotoMapper
{
    public static class ToyotoMapper
    {
        private static readonly IMapper _mapper;
        static ToyotoMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<ToyotoProfile>()).CreateMapper();
        }

        public static PaginationModel<ToyotoResponse> ToPagedListDto(this List<Toyotocars>? options, int page, int limit, int total)
        {
            IEnumerable<ToyotoResponse>? sourceList = _mapper.Map<List<Toyotocars>, List<ToyotoResponse>>(options);

            return new PaginationModel<ToyotoResponse>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static ToyotoTranslation ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, ToyotoTranslation>(translation);

        public static ToyotoTranslation ToEntityMapper(this TranslationDto translation, ToyotoTranslation destionation)
            => _mapper.Map(translation, destionation);


        public static ToyotoDtos ToModel(this Toyotocars options)
            => _mapper.Map<ToyotoDtos>(options);

        public static Toyotocars ToEntity(this ToyotoDtos optionsDTO)
            => _mapper.Map<ToyotoDtos, Toyotocars>(optionsDTO);
    }
}
