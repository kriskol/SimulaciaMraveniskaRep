using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //typy objektov, ktore budu na mraveniskus
    public enum TypyObjektov
    {
        prazdnaZem, //mravec na nu moze vstupit
        skala, //mravec na nu nemoze vstupit
        potrava, //mravec na nu moze vstupit a ziskat z nej energiu
        mravec
    }
}
