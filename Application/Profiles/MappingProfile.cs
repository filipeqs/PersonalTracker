using Application.Dtos.Exercise;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exercise, ExerciseDetailsDto>().ReverseMap();
            CreateMap<Exercise, ExerciseListDto>().ReverseMap();
        }
    }
}
