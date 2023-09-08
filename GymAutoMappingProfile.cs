using AutoMapper;
using GymAPI.Models;
using GymAPI.ModelsDTO;

namespace GymAPI
{
    public class GymAutoMappingProfile : Profile
    {
        public GymAutoMappingProfile()
        {
            CreateMap<Training, TrainingDto>()
                .ForMember(a => a.RestBetweenReps, b => b.MapFrom(c => c.Intensity.RestBetweenReps))
                .ForMember(a => a.RestBetweenExcercise, b => b.MapFrom(c => c.Intensity.RestBetweenExcercise))
                .ForMember(a => a.RestBetweenSets, b => b.MapFrom(c => c.Intensity.RestBetweenSets));

            CreateMap<Exercise, ExerciseDto>();

            CreateMap<CreateTrainingDto, Training>()
                .ForMember(d => d.Intensity, e => e.MapFrom(dtoModel => new Intensity()
                {RestBetweenReps = dtoModel.RestBetweenReps, RestBetweenExcercise = dtoModel.RestBetweenExcercise, RestBetweenSets = dtoModel.RestBetweenSets}));

            CreateMap<CreateExerciseDto, Exercise>();

        }
    }
}
