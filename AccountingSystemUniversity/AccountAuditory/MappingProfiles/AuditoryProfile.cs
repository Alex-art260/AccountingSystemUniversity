using AccountAuditory.Models;
using AccountAuditory.Models.Dto;
using AutoMapper;

namespace AccountingSystemUniversity.MappingProfiles
{
    public class AuditoryProfile : Profile
    {
        public AuditoryProfile() 
        {
            CreateMap<Buildings, BuildingDto>().ReverseMap();

            CreateMap<TypeRoom, TypeRoomDto>().ReverseMap();

            CreateMap<AuditoryDto, Auditory>() // Направление маппинга из Dto в модель
                      .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                      .ForMember(dest => dest.TypeRoomId, opt => opt.MapFrom(src => src.TypeRoomId));

        }
    }

}
