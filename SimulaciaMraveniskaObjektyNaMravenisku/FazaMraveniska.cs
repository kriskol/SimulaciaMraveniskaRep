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
        poNastaveniSmerOtocenia,//faza, ktora je po vykonani cinnosti pohybovych, sluzi na vykreslenie smeru otocenia mravcov
        poNastaveniSmerAktivnehoPohybuStatie,//faza, ktora je po vykonani cinnosti pohybovych, sluzi na vykreslenie smeru aktivneho pohybu mravcov, resp. ich statia
        poBojiPrechadzani,//faza, ktora je po boji, ktory nastal pri prechadzani medzi polickami
        poBojiPolicku,//faza ktora je po boji na policku
        poPareni,//faza, ktora je po pareni
        poVykonaniCinnostiNepohybovych,//faza, ktora je po vykonani nepohybovych cinnosti
        poZnizeniEnergie,//faza, ktora je po znizeni energie mravcov na konci kroku
        poKonciKroku//faza, ktora je po konci jedneho kroku
    }
}
