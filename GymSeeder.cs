using GymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAPI
{
    public class GymSeeder
    {
        private readonly GymDbContext _dbContext;
        public GymSeeder(GymDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }


                if(!_dbContext.Trainings.Any())
                {
                    var trainings = GetTrainings();
                    _dbContext.Trainings.AddRange(trainings);
                    _dbContext.SaveChanges();
                }
            }

        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name= "User"
                },
                new Role()
                {
                    Name= "Manager"
                },
                new Role()
                {
                    Name= "Admin"
                },
            };
            return roles;
        }

        private IEnumerable<Training> GetTrainings()
        {
            var trainings = new List<Training>()
            {
                new Training()
                {
                    Name= "Upper Body",
                    Day= TrainingDay.Monday,
                    PushOrPull= PushOrPull.PUSH,
                    Intensity= new Intensity
                    {
                        RestBetweenReps= "2",
                        RestBetweenExcercise= "2",
                        RestBetweenSets= "2",

                    },
                    Exercises= new List<Exercise>()
                    {
                        new Exercise()
                        {
                            Name= "Flat Bench Press",
                            TrainedPart= "Chest",
                            OptimalRepsRange= "8-18",
                            OptimalSeriesNumber= "5",
                            PushOrPull= PushOrPull.PUSH,
                            Description="Lay down on the bench. Grab barbell or dumbbells with same width as your shoulders. Press weight upward and lower it to the level of your chest."

                        },
                        new Exercise()
                        {
                            Name= "Straightening arms",
                            TrainedPart= "Triceps",
                            OptimalRepsRange= "6-15",
                            OptimalSeriesNumber= "4",
                            PushOrPull= PushOrPull.PUSH,
                            Description="Stand against upper lift machine. Lean over a little. Catch handle with both hands and straighten arms. Then bend arms to 90 degrees angle. Try to keep elbows in the same place. "

                        }                        
                    }
                    

                },
                new Training()
                {
                    Name= "Legs",
                    Day= TrainingDay.Wednesday,
                    PushOrPull= PushOrPull.LEGS,
                    Intensity= new Intensity
                    {
                        RestBetweenReps= "2",
                        RestBetweenExcercise= "2",
                        RestBetweenSets= "2",

                    },
                    Exercises= new List<Exercise>()
                    {
                        new Exercise()
                        {
                            Name= "Classic Squats",
                            TrainedPart= "Quadriceps",
                            OptimalRepsRange= "5-12",
                            OptimalSeriesNumber= "3",
                            PushOrPull= PushOrPull.LEGS,
                            Description="Put barbell on your back and keep it with your hands. Do the squat to the point your knees cover feet. Get up."

                        },
                        new Exercise()
                        {
                            Name= "Bulgarian Squats",
                            TrainedPart= "Quadriceps, Hunkers",
                            OptimalRepsRange= "6-15",
                            OptimalSeriesNumber= "4",
                            PushOrPull= PushOrPull.LEGS,
                            Description="Don't do them."

                        }
                    }

                }

            };
            return trainings;
        }
    }
}
