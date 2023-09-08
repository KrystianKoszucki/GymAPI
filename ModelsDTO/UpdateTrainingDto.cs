using GymAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GymAPI.ModelsDTO
{
    public class UpdateTrainingDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public TrainingDay Day { get; set; }
        public PushOrPull PushOrPull { get; set; }
    }
}
 