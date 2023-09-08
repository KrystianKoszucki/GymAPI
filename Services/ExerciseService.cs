using AutoMapper;
using GymAPI.Exceptions;
using GymAPI.Models;
using GymAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Services
{

    public interface IExerciseService
    {
        int Create(int trainingId, CreateExerciseDto exercise);
        ExerciseDto GetById(int trainingId, int exerciseId);
        List<ExerciseDto> GetAll(int trainingId);
        void RemoveAll(int trainingId);
        void Remove(int trainingId, int exerciseId);
    }
    public class ExerciseService: IExerciseService
    {
        private readonly ILogger<ExerciseService> _logger;
        private readonly IMapper _mapper;
        private readonly GymDbContext _context;
        public ExerciseService(GymDbContext context, IMapper mapper, ILogger<ExerciseService> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public void Remove (int trainingId, int exerciseId)
        {
            _logger.LogWarning($"Exercise with id: {exerciseId} from training with id: {trainingId} DELETE action invoked");

            var exercise = GetExercise(trainingId, exerciseId);

            _context.Remove(exercise);
            _context.SaveChanges();
        }

        public void RemoveAll (int trainingId)
        {
            _logger.LogWarning($"Exercises from training with id: {trainingId} DELETE action invoked");

            var training = GetTrainingById(trainingId);
            _context.RemoveRange(training.Exercises);
            _context.SaveChanges();

        }

        public int Create(int trainingId, CreateExerciseDto exercise)
        {
            var training = GetTrainingById(trainingId);

            var mappedExercise = _mapper.Map<Exercise>(exercise);

            mappedExercise.TrainingId = trainingId;

            _context.Exercises.Add(mappedExercise);
            _context.SaveChanges();

            return mappedExercise.Id;

        }

        public ExerciseDto GetById(int trainingId, int exerciseId)
        {
            var exercise = GetExercise(trainingId, exerciseId);

            var mappedExercise= _mapper.Map<ExerciseDto>(exercise);


            return mappedExercise;
        }

        public List<ExerciseDto> GetAll(int trainingId)
        {
            var training = GetTrainingById(trainingId);

            var mappedExercises = _mapper.Map<List<ExerciseDto>>(training.Exercises);

            return mappedExercises;
        }

        private Training GetTrainingById(int trainingId)
        {
            var training = _context
                .Trainings
                .Include(b => b.Exercises)
                .FirstOrDefault(r => r.Id == trainingId);

            if (training is null)
            {
                throw new NotFoundException("Training not found");
            }

            return training;
        }

        private Exercise GetExercise(int trainingId, int exerciseId)
        {
            var training = GetTrainingById(trainingId);

            var exercise = _context.Exercises.FirstOrDefault(a => a.Id == exerciseId);
            if (exercise is null || exercise.TrainingId != exerciseId)
            {
                throw new NotFoundException("Exercise not found");
            }

            return exercise;
        }

    }
}
