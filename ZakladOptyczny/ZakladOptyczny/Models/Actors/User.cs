namespace ZakladOptyczny.Models.Actors
{
    public abstract class User
    {
        private int _databaseId;

        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public string? Pesel { get; private set; }
        public string? Email { get; private set; }

        public User(string name, string surname, string pesel, string email, int dbId)
        {
            Name = name;
            Surname = surname;  
            Pesel = pesel;
            Email = email;
            _databaseId = dbId;
        }
    }
}
