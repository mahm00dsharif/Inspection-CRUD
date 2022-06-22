using AutoMapper;

namespace Inspection.DTO
{
    public class InspectionDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string InspectionTypeName { get; set; }
    }

    public class InspectionProfile : Profile
    {
        public InspectionProfile()
        {
            CreateMap<Models.Inspection, DTO.InspectionDTO>()
                 .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status)
                ).ForMember(
                    dest => dest.Comments,
                    opt => opt.MapFrom(src => src.Comments)
                )
                .ForMember(
                    dest => dest.InspectionTypeName,
                    opt => opt.MapFrom(src => src.InspectionType.InspectionName)
                );
        }
    }
}

