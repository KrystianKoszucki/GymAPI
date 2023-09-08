namespace GymAPI.Models
{
    public class Intensity
    {
        public int Id { get; set; }
        public string RestBetweenReps { get; set; }
        public string RestBetweenSets { get; set; }
        public string RestBetweenExcercise { get; set; }

        public virtual Training Training { get; set; }
    }
}
