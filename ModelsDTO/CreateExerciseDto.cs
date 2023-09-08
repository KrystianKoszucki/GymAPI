using GymAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GymAPI.ModelsDTO
{
    public class CreateExerciseDto
    {
        [Required]
        public string Name { get; set; }
        public string TrainedPart { get; set; }
        public string OptimalRepsRange { get; set; }
        public string OptimalSeriesNumber { get; set; }
        public PushOrPull PushOrPull { get; set; }
        public string Description { get; set; }

        public int TrainingId { get; set; }
    }
}
