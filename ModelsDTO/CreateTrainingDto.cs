using GymAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GymAPI.ModelsDTO
{
    public class CreateTrainingDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public TrainingDay Day { get; set; }
        public PushOrPull PushOrPull { get; set; }
        public string RestBetweenReps { get; set; }
        public string RestBetweenSets { get; set; }
        public string RestBetweenExcercise { get; set; }


    }
}
