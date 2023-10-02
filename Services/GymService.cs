using AutoMapper;
using GymAPI.Authorization;
using GymAPI.Exceptions;
using GymAPI.Models;
using GymAPI.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GymAPI.Services
{
    public interface IGymService
    {
        void Update(int id, UpdateTrainingDto model);
        void DeleteById(int id);
        int Create(CreateTrainingDto model);
        IEnumerable<TrainingDto> GetAll();
        TrainingDto GetById(int id);
    }

    public class GymService : IGymService
    {
        private readonly GymDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GymService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public GymService(GymDbContext dbContext, IMapper mapper, ILogger<GymService> logger,
             IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
            _authorizationService= authorizationService;
            _userContextService = userContextService;
        }
        public TrainingDto GetById(int id)
        {
            var training = _dbContext
                .Trainings
                .Include(r => r.Exercises)
                .Include(r => r.Intensity)
                .FirstOrDefault(c => c.Id == id);

            if (training is null)
            {
                throw new NotFoundException("Training not found");
            }
            var trainingDto = _mapper.Map<TrainingDto>(training);
            return trainingDto;

        }
        public IEnumerable<TrainingDto> GetAll()
        {
            var trainings = _dbContext
                .Trainings
                .Include(r => r.Exercises)
                .Include(r => r.Intensity)
                .ToList();
            var trainingsDto = _mapper.Map<List<TrainingDto>>(trainings);

            return trainingsDto;
        }

        public int Create(CreateTrainingDto model)
        {
            var training = _mapper.Map<Training>(model);
            training.CreatedById = _userContextService.GetUserId;
            _dbContext.Trainings.Add(training);
            _dbContext.SaveChanges();
            return training.Id;
        }
        public void DeleteById(int id)
        {
           _logger.LogWarning($"Training with id: {id} DELETE action invoked");

            var training = _dbContext
                .Trainings
                .Include(r => r.Exercises)
                .FirstOrDefault(c => c.Id == id);

            if (training is null)
            {
                throw new NotFoundException("Training not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, training,
                new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            _dbContext.Trainings.Remove(training);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateTrainingDto model)
        {
            var training = _dbContext
                .Trainings
                .FirstOrDefault(a => a.Id == id);

            if (training is null)
            {
                throw new NotFoundException("Training not found");
            }

            var authorizationResult= _authorizationService.AuthorizeAsync(_userContextService.User, training,
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            training.Name = model.Name;
            training.Day= model.Day;
            training.PushOrPull= model.PushOrPull;

            _dbContext.SaveChanges();
        }


    }
}
