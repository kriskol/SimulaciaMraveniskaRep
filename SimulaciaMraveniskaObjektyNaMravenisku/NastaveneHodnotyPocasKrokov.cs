using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //hodnoty, ktore budu nastavovanie pocas behov simulacie
    public static class NastaveneHodnotyPocasKrokov
    {
        private static bool parenie;
        private static bool chcemPokracovatSimulacia;

        public static void NastavParenie(bool parenieP)
        {
            parenie = parenieP;
        }
        public static void NastavPokracovanie(bool pokracovatP)
        {
            chcemPokracovatSimulacia = pokracovatP;
        }

        public static bool ZistiParenie()
        {
            return parenie;
        }
        public static bool ZistiPokracovanie()
        {
            return chcemPokracovatSimulacia;
        }

    }
}
