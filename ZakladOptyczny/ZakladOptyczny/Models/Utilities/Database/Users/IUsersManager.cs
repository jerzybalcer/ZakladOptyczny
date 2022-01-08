using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database.Users
{
    public interface IUsersManager
    {
        public List<User> GetAllUsers();

        public User? GetUserById(int id);

        public List<User> GetMatchingUsers(string searchPhrase);

        public void AddUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(User user);
    }
}
