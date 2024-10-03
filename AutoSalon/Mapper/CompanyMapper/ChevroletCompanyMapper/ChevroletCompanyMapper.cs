using AutoMapper;
using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Companys.Chevrolet;
using AutoSalonAPI.Profile.CompanyProfile.ChevroletCompanyProfile;
using AutoSalonAPI.UnversalModel;

namespace AutoSalonAPI.Mapper.CompanyMapper.ChevroletCompanyMapper
{
    public static class ChevroletCompanyMapper
    {
        private static readonly IMapper _mapper;
        static ChevroletCompanyMapper()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<ChevroletCompanyProfile>()).CreateMapper();
        }

        public static PaginationModel<ChevroletCompanyResponce> ToPagedListDto(this List<Chevroletcompanys>? options, int page, int limit, int total)
        {
            IEnumerable<ChevroletCompanyResponce>? sourceList = _mapper.Map<List<Chevroletcompanys>, List<ChevroletCompanyResponce>>(options);

            return new PaginationModel<ChevroletCompanyResponce>()
            {
                Items = sourceList,
                Page = page,
                Limit = limit,
                Total = total
            };
        }
        public static ChevroletTranslationCompany ToEntityMapper(this TranslationDto translation)
            => _mapper.Map<TranslationDto, ChevroletTranslationCompany>(translation);

        public static ChevroletTranslationCompany ToEntityMapper(this TranslationDto translation, ChevroletTranslationCompany destionation)
            => _mapper.Map(translation, destionation);


        public static ChevroletCompanyDtos ToModel(this Chevroletcompanys options)
            => _mapper.Map<ChevroletCompanyDtos>(options);

        public static Chevroletcompanys ToEntity(this ChevroletCompanyDtos optionsDTO)
            => _mapper.Map<ChevroletCompanyDtos, Chevroletcompanys>(optionsDTO);
    }
}
