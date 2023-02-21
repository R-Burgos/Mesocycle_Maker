using Mesocycle_Maker.Models;

namespace Mesocycle_Maker
{
    public interface IUserMesoRepo
    {
        public IEnumerable<UserMeso> GetAllUserMeso();
        public IEnumerable<UserMeso> GetOneUserMesoID(int userMesoID);
        public IEnumerable<UserMeso> GetOneWithoutID(string userMesoGoal, int userMesoWeekLength);
        public void DeleteUserMeso(int selectedUserMeso);
        public void InsertUserMeso(string newUserMesoGoal, int newUserMesoWeekLength);
    }
}
