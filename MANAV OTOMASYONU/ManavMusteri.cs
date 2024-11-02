using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANAV_OTOMASYONU
{
    internal class ManavMusteri
    {
        public double alınan { get; set; }
        public string ad { get; set; }
        public double meyveSepetTutari { get; set; }
        public double meyveTutari { get; set; }
        public double sebzeTutari { get; set; }
        public double sebzeSepetTutari { get; set; }
        internal static List<ManavMusteri> meyves = new List<ManavMusteri>() { };
        internal static List<ManavMusteri> sebzes = new List<ManavMusteri>() { };
    }
}
