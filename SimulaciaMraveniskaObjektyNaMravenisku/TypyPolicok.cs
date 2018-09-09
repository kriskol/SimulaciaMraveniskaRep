using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //typy policok pred mravcom a na ktorych je mravec
    public enum TypyPolicok
    {
        prazdnaZem,
        skala,
        potrava,
        priatelPrazdnaZem,//policko s prazdnou zemou a mravcom toho isteho typu, vzhladom ktoremu zistujeme typ policka
        priatelPotrava,//policko s potravou a mravcom toho isteho typu, vzhladom ktoremu zistujeme typ policka
        nepriatelPrazdnaZem,//policko s prazdnou zemou a mravcom ineho typu, vzhladom ktoremu zistujeme typ policka
        nepriatelPotrava//policko s potravou a mravcom ineho typu, vzhladom ktoremu zistujeme typ policka
    }

}
