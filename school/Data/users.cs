using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.Data
{
    public class User
    {
        public int Id { get; set; }  // De Id wordt automatisch gegenereerd door de database (auto-increment)
        public string Username { get; set; }  // Gebruikersnaam van de gebruiker
        public string PasswordHash { get; set; }  // Gehasht wachtwoord

        // Optioneel: Constructor voor makkelijker instantiëren van gebruikers
        public User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        // Standaard constructor voor Entity Framework
        public User() { }
    }
}
