using AutoMapper;
using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.BMW;
using AutoSalonAPI.Profile.CompanyProfile.BmwCompanyProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CompanyMapper.BmwCompanyMapper
{
    public static class BmwCompanyMapper
    {
        private static readonly IMapper _mapper;
        static BmwCompanyMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<BmwCompanyProfile>()).CreateMapper();
        }

        public static PaginationModel<BmwCompanyResponce> ToPagedListDto(this List<BMWcompanys>? options, int page, int limit, int total)
        {
            IEnumerable<BmwCompanyResponce>? sourceList = _mapper.Map<List<BMWcompanys>, List<BmwCompanyResponce>>(options);

            return new PaginationModel<BmwCompanyResponce>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static BmwTranslationCompany ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, BmwTranslationCompany>(translation);

        public static BmwTranslationCompany ToEntityMapper(this TranslationDto translation, BmwTranslationCompany destionation)
            => _mapper.Map(translation, destionation);


        public static BmwCompanyDtos ToModel(this BMWcompanys options)
            => _mapper.Map<BmwCompanyDtos>(options);

        public static BMWcompanys ToEntity(this BmwCompanyDtos optionsDTO)
            => _mapper.Map<BmwCompanyDtos, BMWcompanys>(optionsDTO);
    }
}
