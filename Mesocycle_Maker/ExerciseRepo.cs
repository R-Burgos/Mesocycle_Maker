using Dapper;
using Mesocycle_Maker.Models;
using System.Data;

namespace Mesocycle_Maker
{
    public class ExerciseRepo : IExerciseRepo
    {
        private readonly IDbConnection _connection;
        public ExerciseRepo(IDbConnection connection)
        { 
            _connection = connection;
        }

        public void DeleteExercise(int exerciseID)
        {
            _connection.Execute("DELETE FROM exercise WHERE (ExerciseID) = (@exID);",
                new { exID = exerciseID });
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _connection.Query<Exercise>("SELECT * FROM exercise;");
        }

        public IEnumerable<Exercise> GetByCategory(int categoryID)
        {
            return _connection.Query<Exercise>("SELECT * FROM exercise WHERE (CategoryID) = (@catID);",
                new { catID = categoryID });
        }

        public void InsertExercise(string newExerciseName, int newExerciseCategoryID)
        {
            _connection.Execute("INSERT INTO exercise (ExerciseName, CategoryID) VALUES (@exerciseName, @categoryID);",
                new { exerciseName = newExerciseName, categoryID = newExerciseCategoryID });
        }

        public void UpdateExercise(string exerciseName, int categoryID, int exerciseID)
        {
            _connection.Execute("UPDATE exercise SET ExerciseName = (@exName), CategoryID = (@catID) WHERE ExerciseID = (@exID);",
                new { exName = exerciseName, catID = categoryID, exID = exerciseID });
        }
    }
}
