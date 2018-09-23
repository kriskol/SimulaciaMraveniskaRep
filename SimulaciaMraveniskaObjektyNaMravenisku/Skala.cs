using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda reprezentujuca skalu
    public class Skala : NepohybujuceSaObjekty
    {
        public Skala(int xSuradnica, int ySuradnica, bool viditelnost, bool existencia) :
            base(xSuradnica, ySuradnica, TypyObjektov.skala, "", viditelnost, existencia, false)
        { }
    }
}
