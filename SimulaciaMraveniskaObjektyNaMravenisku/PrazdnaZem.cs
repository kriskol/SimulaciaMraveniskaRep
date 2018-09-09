using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda reprezentujuca prazdnu zem
    public class PrazdnaZem : NepohybujuceSaObjekty
    {
        public PrazdnaZem(int xSuradnica, int ySuradnica,
            bool viditelnost, bool existencia) : base(xSuradnica, ySuradnica, TypyObjektov.prazdnaZem, "",
                viditelnost, existencia, true)
        { }

    }
}
