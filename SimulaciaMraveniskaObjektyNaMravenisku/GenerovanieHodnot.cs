using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //generovanie hodnot
    public static class GenerovanieHodnot
    {
        public static Random random = new Random();

        public static int ZistiHodnotuEnergiePotrava()
        {
            return random.Next(Konstanty.minimumEnergiaPotrava, Konstanty.maximumEnergiaPotrava);
        }
    }
}
