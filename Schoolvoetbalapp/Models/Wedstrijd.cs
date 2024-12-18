using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolvoetbalapp.Models
{

    public class Wedstrijd
    {
        public int Id { get; set; }
        public string ThuisTeam { get; set; }
        public string UitTeam { get; set; }
        public string Datum { get; set; }
        public ICollection<Weddenschap> Weddenschappen { get; set; }
    }
}
