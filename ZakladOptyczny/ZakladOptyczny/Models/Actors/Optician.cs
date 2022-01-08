namespace ZakladOptyczny.Models.Actors
{
    public class Optician : User
    {
        public Optician(string name, string surname, string pesel, string email) : base(name, surname, pesel, email)
        {
            // base constructor already called at this point
        }

    }
}
