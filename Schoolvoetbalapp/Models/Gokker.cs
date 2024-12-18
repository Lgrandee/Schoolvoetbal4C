using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolvoetbalapp.Models
{
    public class Gokker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public double Budget { get; set; }

        public ICollection<Weddenschap> Weddenschappen { get; set; }

    }
}
