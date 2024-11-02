using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANAV_OTOMASYONU
{
    internal class HalMusteri
    {
        public double alınan { get; set; }
        public string ad { get; set; }
        public double meyveSepetTutari { get; set; }
        public double meyveTutari { get; set; }
        public double sebzeTutari { get; set; }
        public double sebzeSepetTutari { get; set; }
        internal static List<HalMusteri> meyves = new List<HalMusteri>() { };
        internal static List<HalMusteri> sebzes = new List<HalMusteri>() { };
    }
}
