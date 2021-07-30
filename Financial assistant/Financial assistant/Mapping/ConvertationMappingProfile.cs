using AutoMapper;
using Financial_assistant.DTO.Сlasses;
using Financial_assistant.Models.DbModels;

namespace Financial_assistant.Mapping
{
    public class ConvertationMapperProfile : Profile
    {
        public ConvertationMapperProfile()
        {
            CreateMap<Convertation, ConvertationDto>();
            CreateMap<ConvertationCreateDto, Convertation>();
        }
    }
}
