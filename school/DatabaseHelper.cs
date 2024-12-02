using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace school
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper()
        {
            // Databasepad instellen
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AppData.db");
            _database = new SQLiteAsyncConnection(dbPath);

            // Maak de User-tabel als deze niet bestaat
            _database.CreateTableAsync<User>().Wait();
        }

        // Voeg een nieuwe gebruiker toe
        public Task<int> AddUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        // Controleer inloggegevens
        public Task<User> GetUserAsync(string username, string password)
        {
            return _database.Table<User>().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        // Controleer of een gebruikersnaam al bestaat
        public Task<User> GetUserByUsernameAsync(string username)
        {
            return _database.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
