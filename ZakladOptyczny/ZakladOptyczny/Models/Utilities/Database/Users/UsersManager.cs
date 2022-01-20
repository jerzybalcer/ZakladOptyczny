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

        public User? GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(user => user.UserId == id);
        }

        public List<User> GetMatchingUsers(string searchPhrase)
        {
            return _db.Users.Where(user => user.Name.Contains(searchPhrase)
            || user.Surname.Contains(searchPhrase)).ToList();
        }

        public List<User> GetMatchingUsersByFullName(string searchPhraseName,
            string searchPhraseSurname)
        {
            return _db.Users.Where(user => user.Name.Contains(searchPhraseName)
            && user.Surname.Contains(searchPhraseSurname)).ToList();
        }

        public List<User> GetMatchingUsersByEmail(string searchPhraseName)
        {
            return _db.Users.Where(user => user.Email.Contains(searchPhraseName)).ToList();
        }

        public User AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
