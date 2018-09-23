using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//hlasky pri textovom vystupe
namespace SimulaciaMraveniskaHlasky
{
    //hlasky pri nacitavani hodnot
    static class HlaskyPriNacitavaniHodnotRozhodnuti
    {
        public static void ZadavanieRozmeruMraveniska()
        {
            Console.WriteLine("Zadajte rozmer mraveniska.(8/16/32)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte rozmer mraveniska.(8/16/32)");
        }
        public static void NespravneRozmer()
        {
            Console.WriteLine("Zadali ste nespravny rozmer mraveniska. Opakujte zadanie.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nespravny rozmer mraveniska. Opakujte zadanie.");
        }
        public static void ZadavaniePoctuMravcov()
        {
            Console.WriteLine("Zadajte pocty mravcov danych typov (najprv 1.typu, 2. typu, 3.typu, 4.typu)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte pocty mravcov danych typov (najprv 1.typu, 2.typu, 3.typu, 4.typu");
        }
        public static void NespravneZadaniePoctuMravcov()
        {
            Console.WriteLine("Zadali ste nekorektne pocty mravcov.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nekorektne pocty mravcov.");
        }
        public static void ZadavaniePoctuStartovnejPotravy()
        {
            Console.WriteLine("Zadajte mnozstvo startovnej potravy a minimalne mnozstvo potravy");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte mnozstvo startovnej potravy a minimalne mnozstvo potravy");
        }
        public static void NespravneZadaniePoctuPotravy()
        {
            Console.WriteLine("Zadali ste nekorektne mnozstva potravy");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nekorektne mnozstva potravy");
        }
        public static void RozsahHodnoty(int spodnaHranica, int vrchnaHranica)
        {
            Console.WriteLine("Dana hodnota musi byt v rozsahu " + spodnaHranica + " - " + vrchnaHranica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Dana hodnota musi byt v rozsahu " + spodnaHranica + " - " + vrchnaHranica + ".");
        }
        public static void ZadajtePocetSkal()
        {
            Console.WriteLine("Zadajte pocet skal.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte pocet skal.");
        }
        public static void ZadaliSteNekorektnuHodnotuOpakujteZadanie()
        {
            Console.WriteLine("Zadali ste nekorektnu hodnotu, opakujte zadanie hodnoty.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nekorektnu hodnotu, opakujte zadanie hodnoty.");
        }
        public static void ZaciatokSimulacie()
        {
            Console.WriteLine("Chcete zacat simulaciu? (ANO/NIE)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Chcete zacat simulaciu? (ANO/NIE)");
        }
        public static void ChcetePokracovatVSimulacii()
        {
            Console.WriteLine("Chcete pokracovat v simulacii? (ANO/NIE)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Chcete pokracovat v simulacii? (ANO/NIE)");
        }
    }
}
