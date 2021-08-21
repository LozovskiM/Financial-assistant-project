using AutoMapper;
using Financial_assistant.DTO.Сlasses;
using Financial_assistant.Models.DbModels;


namespace Financial_assistant.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<LoginDto, User>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<RegisterDto, Currency>().PreserveReferences().ReverseMap().PreserveReferences();
        }
    }
}
