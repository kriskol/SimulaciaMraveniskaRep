using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //cinnosti mravcov
    public enum CinnostiMravcov
    {
        zostan, //zostane stat, pri boji na policku je zvyhodneny
        otocSaVlavo, //otoci sa vlavo na policku
        chodDopreduUtok,//ide dopredu, pri pripadnom strete s mravcami ineho typu, ktore idu opacne bojuje
        chodDopreduObrana,//ide dopredu, pri pripadnom strete s mravcami ineho typu, ktore idu opacne uskakuje
                          //dojde pritom k znizeniu jeho energie
        paritSa,//mravec sa bude chiet parit, pokial bude mat dostatok energie a bude na jeho policku aspon jeden, taky
                //isty mravec, toho isteho typu, tak sa mu to podari a vznikne aspon jeden mravec
        najedzSa//mravec sa bude chciet najest na danom policku, ak tam bude potrava, tak sa mu to podari
    }
}
