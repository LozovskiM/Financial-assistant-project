using AutoMapper;
using Financial_assistant.DTO.Classes;
using Financial_assistant.Models.DbModels;

namespace Financial_assistant.Mapping
{
    public class CurrencyMapperProfile : Profile
    {
        public CurrencyMapperProfile()
        {
            CreateMap<CurrencyDto, Currency>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<CurrencyCreateDto, Currency>().PreserveReferences().ReverseMap().PreserveReferences();
        }
    }
}
