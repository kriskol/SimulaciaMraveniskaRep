using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaciaMraveniskaGUI
{
    static class HodnotyStavuZobrazovaniaSimulacie
    {
        private static bool simulaciaSaZobrazuje = true;

        public static void NastavZobrazovanieSimulacie(bool pravdivost)
        {
            simulaciaSaZobrazuje = pravdivost;
        }

        public static bool ZistiZobrazovanieSimulacie()
        {
            return simulaciaSaZobrazuje;
        }
    }
}
