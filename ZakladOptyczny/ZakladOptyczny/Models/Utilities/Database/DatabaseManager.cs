using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database
{
    public class DatabaseManager
    {
        private readonly DatabaseContext _db;

        public DatabaseManager(DatabaseContext dbContext)
        {
            _db = dbContext;
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public void AddTestUser()
        {
            _db.Users.Add(new Patient("antek", "antoś", "12345678901", "antek@gmail.com"));
            _db.SaveChanges();
        }
    }
}
