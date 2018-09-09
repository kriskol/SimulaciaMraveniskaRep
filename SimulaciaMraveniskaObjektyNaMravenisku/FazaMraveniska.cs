using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekt mravenisko, objekty a enum typy suvisiace s mraveniskom
namespace SimulaciaMraveniskaMravenisko
{
    //faze mraveniska pri vypisovani
    public enum FazaMraveniska
    {
        poBojiPrechadzani,//faza, ktora je po boji, ktory nastal pri prechadzani medzi polickami
        poBojiPolicku,//faza ktora je po boji na policku
        poPareni,//faza, ktora je po pareni
        poKonciKroku//faza, ktora je po konci jedneho kroku
    }
}
