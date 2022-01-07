using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly DatabaseContext _db;

        public UsersManager(DatabaseContext dbContext)
        {
            _db = dbContext;
        }

        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
