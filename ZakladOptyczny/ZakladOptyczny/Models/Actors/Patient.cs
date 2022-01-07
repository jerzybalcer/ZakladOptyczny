using ZakladOptyczny.Models.Interfaces;
using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Actors
{
    public class Patient : User
    {
        public Patient(string name, string surname, string pesel, string email) : base(name, surname, pesel, email)
        {
            // base constructor already called at this point
        }
    }
}
