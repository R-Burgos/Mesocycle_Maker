namespace Mesocycle_Maker.Models
{
    public class ExercisePerMeso
    {
        public ExercisePerMeso()
        {

        }

        public int UserMesoID { get; set; }
        public int ExerciseID { get; set; }
        public int ExerciseTenRPM { get; set; }
        public string ExerciseOnDay { get; set; }
        public string ExerciseName { get; set; }

    }
}
