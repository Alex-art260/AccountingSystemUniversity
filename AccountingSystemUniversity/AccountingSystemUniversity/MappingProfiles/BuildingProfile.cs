using AccountingSystemUniversity.Models;
using AccountingSystemUniversity.Models.Dto;
using AutoMapper;

namespace AccountingSystemUniversity.MappingProfiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile() 
        {
            CreateMap<Building, BuildingDto>().ReverseMap();
        }
      
        
    }
}
