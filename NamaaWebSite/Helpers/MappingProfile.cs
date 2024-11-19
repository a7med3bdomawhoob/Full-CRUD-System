
using AutoMapper;
using DAL.Entity;
using PL.Dto;


namespace PL.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap< ProjectDto, Project>();
            //CreateMap<DAL.Entity.AreaDto, Area>();\
            CreateMap<NewsDto, News>();
            CreateMap<EquipementDto, Equipement>();
            CreateMap<JobDto, Job>().ReverseMap();
            CreateMap<RequirementDto,JobRequirements >();
            CreateMap<ResponsibilitiesDto,JobResponsibilities>();

            CreateMap<ProjectDto, Project>();

            //  CreateMap<AreaDto, Area>().ReverseMap();



            // Mapping from Area to AreaDto for GET requests
            CreateMap<Area, AreaDto>()
                .ForMember(dest => dest.service, opt => opt.MapFrom(src => src.Service)); // Map Service entity if needed

            // Mapping from AreaDto to Area for INSERT requests
            CreateMap<AreaDto, Area>()
                .ForMember(dest => dest.Service, opt => opt.Ignore());  // Ignore the Service property during insert


            //////////////////////////////////














            CreateMap<ServiceDto, Service>();

        }
    }
}
