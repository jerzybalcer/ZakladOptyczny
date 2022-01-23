namespace ZakladOptyczny.Models.Actors
{
    public abstract class User
    {
        public int UserId { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string Email { get; set; }

        public User(string name, string surname, string pesel, string email)
        {
            Name = name;
            Surname = surname;  
            Pesel = pesel;
            Email = email;
        }
    }
}
