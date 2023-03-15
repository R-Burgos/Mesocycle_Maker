using Dapper;
using Mesocycle_Maker.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace Mesocycle_Maker
{
    public class UserMesoRepo : IUserMesoRepo
    {
        private readonly IDbConnection _connection;
        public UserMesoRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public void DeleteUserMeso(int selectedUserMeso)
        {
            //In order to delete a userMesoID, no exercises can be assigned to the userMesoID on the ExercisePerMeso table.
            //All exercises will de deleted from the ExercisePerMeso table first before deleting the UserMeso.

            _connection.Execute("DELETE FROM exercisepermeso WHERE UserMesoID = (@userID);",
                new { userID = selectedUserMeso });

            _connection.Execute("DELETE FROM usermeso WHERE UserMesoID = (@userMesoID);",
                new { userMesoID = selectedUserMeso });
        }

        public IEnumerable<UserMeso> GetAllUserMeso()
        {
            return _connection.Query<UserMeso>("SELECT * FROM usermeso;");
        }

        public IEnumerable<UserMeso> GetOneUserMesoID(int userMesoID)
        {
            return _connection.Query<UserMeso>("SELECT * FROM usermeso WHERE UserMesoID = (@userID);",
                new { userID = userMesoID });
        }

        public IEnumerable<UserMeso> GetOneWithoutID(string userMesoGoal, int userMesoWeekLength)
        {
            return _connection.Query<UserMeso>("SELECT * FROM usermeso WHERE UserMesoGoal = (@newUser) AND UserMesoWeekLength = (@newUserWeek);",
                new { newUser = userMesoGoal, newUserWeek = userMesoWeekLength });
        }

        public void InsertUserMeso(string newUserMesoGoal, int newUserMesoWeekLength)
        {
             _connection.Execute("INSERT INTO usermeso (UserMesoGoal, UserMesoWeekLength) VALUES (@newUser, @newUserWeek);",
                new { newUser = newUserMesoGoal, newUserWeek = newUserMesoWeekLength });

        }
    }
}
