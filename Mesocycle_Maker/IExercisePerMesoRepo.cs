using Mesocycle_Maker.Models;

namespace Mesocycle_Maker
{
    public interface IExercisePerMesoRepo
    {
        public IEnumerable<ExercisePerMeso> GetAll();
        public IEnumerable<ExercisePerMeso> GetOneWithNames(int userMesoID);
        public void DeleteAnExercise(int userMesoID, int exID, string exOnDay);
        public void InsertAnExercise(int userMesoID);
        public void UpdateAnExercise(int userMesoID);

    }
}
