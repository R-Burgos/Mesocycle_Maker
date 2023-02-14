using Dapper;
using Mesocycle_Maker.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace Mesocycle_Maker
{
    public class ExercisePerMesoRepo : IExercisePerMesoRepo
    {
        private readonly IDbConnection _connection;
        public ExercisePerMesoRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ExercisePerMeso> GetAll()
        {
            return _connection.Query<ExercisePerMeso>("SELECT * FROM exercisepermeso;");
        }

        public IEnumerable<ExercisePerMeso> GetOneWithNames(int userMesoID)
        {
            return _connection.Query<ExercisePerMeso>("SELECT exercise.ExerciseName, exercisepermeso.ExerciseTenRPM, exercisepermeso.ExerciseOnDay FROM exercisepermeso INNER JOIN exercise ON exercisepermeso.ExerciseID = exercise.ExerciseID WHERE exercisepermeso.UserMesoID = (@userID);",
                new { userID = userMesoID });
        }

        public void DeleteAnExercise(int userMesoID, int exID, string exOnDay)
        {
            _connection.Execute("DELETE FROM exercisepermeso WHERE UserMesoID = (@userID) AND ExerciseID = (@exerID) AND ExerciseOnDay = (@exDay);",
                new { userID = userMesoID, exerID = exID, exDay = exOnDay });
        }

        public void InsertAnExercise(int userMesoID)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnExercise(int userMesoID)
        {
            throw new NotImplementedException();
        }
    }
}
