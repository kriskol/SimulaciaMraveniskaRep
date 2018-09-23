using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sprava udalosti a suvisiace objekty a enum typy
namespace SimulaciaMraveniskaUdalostiSpravaUdalosti
{
    //typy udalosti
    public enum TypyUdalosti
    {
        zvysenieCasu = 0,//navysenie casu mraveniska a samotnej simulacie
        navysenieVekuMravcov = 1,//navysenie veku mravcov
        vykonanieCinnostiMravcovPohybovych = 2,//vykonanie skor pohybovyvh cinnosti jednotlivych mravcov
        grafickyVypisSmerOtocenia = 6,//vykresli smer otocenia mravcov
        grafickyVypisSmerAktivnehoPohybuStatie = 7, //vykresli smer pohybu mravcov, ktory sa idu pohybovat, resp. ich statie
        bojMravcovPrechadzajucich = 8,//boj mravcov pri prechadzani medzi dvomi susednymi polickami, kde mravce
                                      //rovnakeho typu bojuju spolu proti mravcom ineho typu
        grafickyVypisMraveniskaBojPrechadzajuci = 9,//vykresli mravenisko po boji prechadzajucich mravcov
        bojMravcovNaPolickach = 10,//boj mravcov na policku, kde mravce rovnakeho typu bojuju spolu
                                  //proti mravcom ineho typu
        grafickyVypisMraveniskaBojNaPolicku = 11,//vykresli mravenisko po boji na policku
        paritSa = 12,//spustenie parenia mravcov
        grafickyVypisMraveniskaParenie = 13,//vykresli mravenisko po pareni
        vykonanieCinnostiMravcovNepohybovych = 14,//vykonanie skor nepohybovych cinnosti jednotlivych mravcov
        grafickyvVypisPoVykonaniCinnostiNepohybovych=15,//vykresli mravenisko po najedeni sa mravcov
        upravyNepohybujucichPolicok = 16,//aktualizacia nepohybovych policok
        znizenieEnergiaNaKonci = 17,//znizenie energie mravcov na konci kroku, resp. "casu"
        grafickyVypisPoZnizeniEnergieMravcov = 18,//vykresli policka, kde doslo k ubytku mravcov z dovodu
                                                  //znizenia energie
        vypisStatistickychUdajov = 19,//vypis statistickych udajov - pri GUI verzii nefunkcne
        precistenieHodnot = 20,//resetovanie hodnot pred dalsim krokom, resp. "casom"
        nastavenieNasledujucichCinnostiMravcov = 21,//nastavenie cinnosti mravcov
        grafickyVypisMraveniska = 22,//vykresli mravenisko
        otazkaNaKoniec = 23//otazka ukoncenia behu mraveniska - pri GUI verzii nefunkcne
    }
}
