using AutoMapper;
using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.BYD;
using AutoSalonAPI.Profile.CompanyProfile.BydCompanyProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CompanyMapper.BydCompanyMapper
{
    public static class BydCompanyMapper
    {
        private static readonly IMapper _mapper;
        static BydCompanyMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<BydCompanyProfile>()).CreateMapper();
        }

        public static PaginationModel<BydCompanyResponce> ToPagedListDto(this List<BYDcompanys>? options, int page, int limit, int total)
        {
            IEnumerable<BydCompanyResponce>? sourceList = _mapper.Map<List<BYDcompanys>, List<BydCompanyResponce>>(options);

            return new PaginationModel<BydCompanyResponce>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static BYDTranslationCompany ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, BYDTranslationCompany>(translation);

        public static BYDTranslationCompany ToEntityMapper(this TranslationDto translation, BYDTranslationCompany destionation)
            => _mapper.Map(translation, destionation);


        public static BydCompanyDtos ToModel(this BYDcompanys options)
            => _mapper.Map<BydCompanyDtos>(options);

        public static BYDcompanys ToEntity(this BydCompanyDtos optionsDTO)
            => _mapper.Map<BydCompanyDtos, BYDcompanys>(optionsDTO);
    }
}
