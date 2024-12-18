using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolvoetbalapp.Models
{
    public class Weddenschap
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int Team1Id { get; set; }
        public string Team1Name { get; set; }
        public int Team2Id { get; set; }
        public string Team2Name { get; set; }
    }
}
