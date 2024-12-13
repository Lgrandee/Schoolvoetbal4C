
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.Data
{
    internal class AppOnlineContext : DbContext
    {
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +                     // Server name
                "port=3306;" +                            // Server port
                "user=Lgrandee;" +                     // Username
                "password=28.06.2007LD;" +                 // Password
                "database=csd_iv_AppOnline_v1_0;"      // Database name
                , Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql") // Version
                );
        }
        
    }
}
