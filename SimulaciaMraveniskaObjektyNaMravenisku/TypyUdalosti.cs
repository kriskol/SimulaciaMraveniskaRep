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
        bojMravcovPrechadzajucich = 6,//boj mravcov pri prechadzani medzi dvomi susednymi polickami, kde mravce
                                      //rovnakeho typu bojuju spolu proti mravcom ineho typu
        grafickyVypisMraveniskaBojPrechadzajuci = 7,//vykresli mravenisko po boji prechadzajucich mravcov
        bojMravcovNaPolickach = 8,//boj mravcov na policku, kde mravce rovnakeho typu bojuju spolu
                                  //proti mravcom ineho typu
        grafickyVypisMraveniskaBojNaPolicku = 9,//vykresli mravenisko po boji na policku
        paritSa = 10,//spustenie parenia mravcov
        grafickyVypisMraveniskaParenie = 11,//vykresli mravenisko po pareni
        vykonanieCinnostiMravcovNepohybovych = 12,//vykonanie skor nepohybovych cinnosti jednotlivych mravcov
        upravyNepohybujucichPolicok = 13,//aktualizacia nepohybovych policok
        znizenieEnergiaNaKonci = 14,//znizenie energie mravcov na konci kroku, resp. "casu"
        vypisStatistickychUdajov = 15,//vypis statistickych udajov - pri GUI verzii nefunkcne
        precistenieHodnot = 16,//resetovanie hodnote pred dalsim krokom, resp. "casom"
        nastavenieNasledujucichCinnostiMravcov = 17,//nastavenie cinnosti mravcov
        grafickyVypisMraveniska = 18,//vykresli mravenisko
        otazkaNaKoniec = 19//otazka ukoncenia behu mraveniska - pri GUI verzii nefunkcne
    }
}
