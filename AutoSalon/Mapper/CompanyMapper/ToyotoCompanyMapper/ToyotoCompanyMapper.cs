using AutoMapper;
using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.BMW;
using AutoSalon.Models.Companys.Toyoto;
using AutoSalonAPI.Profile.CompanyProfile.ToyotoCompanyProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CompanyMapper.ToyotoCompanyMapper
{
    public static class ToyotoCompanyMapper
    {
        private static readonly IMapper _mapper;
        static ToyotoCompanyMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<ToyotoCompanyProfile>()).CreateMapper();
        }

        public static PaginationModel<ToyotoCompanyResponce> ToPagedListDto(this List<Toyotocompanys>? options, int page, int limit, int total)
        {
            IEnumerable<ToyotoCompanyResponce>? sourceList = _mapper.Map<List<Toyotocompanys>, List<ToyotoCompanyResponce>>(options);

            return new PaginationModel<ToyotoCompanyResponce>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static ToyotoTranslationCompany ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, ToyotoTranslationCompany>(translation);

        public static ToyotoTranslationCompany ToEntityMapper(this TranslationDto translation, ToyotoTranslationCompany destionation)
            => _mapper.Map(translation, destionation);


        public static ToyotoCompanyDtos ToModel(this Toyotocompanys options)
            => _mapper.Map<ToyotoCompanyDtos>(options);

        public static Toyotocompanys ToEntity(this ToyotoCompanyDtos optionsDTO)
            => _mapper.Map<ToyotoCompanyDtos, Toyotocompanys>(optionsDTO);
    }
}
