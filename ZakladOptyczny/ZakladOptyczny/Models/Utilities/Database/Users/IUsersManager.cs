using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database.Users
{
    public interface IUsersManager
    {
        public List<User> GetAllUsers();

        public User GetUserById(int id);

        public void AddUser();

        public void UpdateUser();

        public void DeleteUser();
    }
}
