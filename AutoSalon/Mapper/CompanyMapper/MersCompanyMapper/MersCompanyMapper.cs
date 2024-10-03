using AutoMapper;
using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.MersedensBens;
using AutoSalonAPI.Profile.CompanyProfile.MersCompanyProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CompanyMapper.MersCompanyMapper
{
    public static class MersCompanyMapper
    {
        private static readonly IMapper _mapper;
        static MersCompanyMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<MersCompanyProfile>()).CreateMapper();
        }

        public static PaginationModel<MersCompanyResponce> ToPagedListDto(this List<MersedensBenscompanys>? options, int page, int limit, int total)
        {
            IEnumerable<MersCompanyResponce>? sourceList = _mapper.Map<List<MersedensBenscompanys>, List<MersCompanyResponce>>(options);

            return new PaginationModel<MersCompanyResponce>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static MersTranslationCompany ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, MersTranslationCompany>(translation);

        public static MersTranslationCompany ToEntityMapper(this TranslationDto translation, MersTranslationCompany destionation)
            => _mapper.Map(translation, destionation);


        public static MersCompanyDtos ToModel(this MersedensBenscompanys options)
            => _mapper.Map<MersCompanyDtos>(options);

        public static MersedensBenscompanys ToEntity(this MersCompanyDtos optionsDTO)
            => _mapper.Map<MersCompanyDtos, MersedensBenscompanys>(optionsDTO);
    }
}
