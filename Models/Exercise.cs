namespace GymAPI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrainedPart { get; set; }
        public string OptimalRepsRange { get; set; }
        public string OptimalSeriesNumber { get; set; }
        public PushOrPull PushOrPull { get; set; }
        public string Description { get; set; }

        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
        
    }
}
