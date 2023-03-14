using Mesocycle_Maker.Models;

namespace Mesocycle_Maker
{
    public interface IExerciseRepo
    {
        public IEnumerable<Exercise> GetAllExercises();
        public IEnumerable<Exercise> GetByCategory(int categoryID);
        public void DeleteExercise(int exerciseID);
        public void InsertExercise(string newExerciseName, int newExerciseCategoryID);
        public void UpdateExercise(string exerciseName, int categoryID, int exerciseID);
    }
}
