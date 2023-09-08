using GymAPI.Models;

namespace GymAPI.ModelsDTO
{
    public class TrainingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrainingDay Day { get; set; }
        public PushOrPull PushOrPull { get; set; }
        public string RestBetweenReps { get; set; }
        public string RestBetweenSets { get; set; }
        public string RestBetweenExcercise { get; set; }

        public List<ExerciseDto> Exercises { get; set; }
    }
}
