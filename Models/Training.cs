namespace GymAPI.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrainingDay Day { get; set; }
        public PushOrPull PushOrPull { get; set; }
        


        public int IntensityId { get; set; }
        public virtual Intensity Intensity { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
        
    }
}
