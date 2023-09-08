using GymAPI.Models;

namespace GymAPI.ModelsDTO
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrainedPart { get; set; }
        public string OptimalRepsRange { get; set; }
        public string OptimalSeriesNumber { get; set; }
        public PushOrPull PushOrPull { get; set; }
        public string Description { get; set; }
    }
}
