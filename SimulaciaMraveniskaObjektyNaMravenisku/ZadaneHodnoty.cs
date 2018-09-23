using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//samotna simulacia mraveniska a ziskavanie vstupnych a vystupnych dat
namespace SimulaciaMraveniskaSimulacia
{
    //tato staticka trieda sluzi ako uschovna zadanych hodnot od uzivatel
    //taketo uschovne hodnot su este 2 (nie nutne vsetky uchovavaju hodnoty od uzivatela)
    //su to: Konstanty, NastaveneHodnotyPocasKrokov
    public static class ZadaneHodnoty
    {
        private static int rozmerMraveniska = 0;
        private static int pocetMravcovTypu1 = 0;
        private static int pocetMravcovTypu2 = 0;
        private static int pocetMravcovTypu3 = 0;
        private static int pocetMravcovTypu4 = 0;
        private static int pocetSkal = 0;
        private static int mnzostvoPotravy = 0;
        private static int minimalneMnozstvoPotravy = 0;

        public static void NastavRozmerMraveniska(int rozmer)
        {
            rozmerMraveniska = rozmer;
        }
        public static void NastavPocetMravcovTypu1(int pocet)
        {
            pocetMravcovTypu1 = pocet;
        }
        public static void NastavPocetMravcovTypu2(int pocet)
        {
            pocetMravcovTypu2 = pocet;
        }
        public static void NastavPocetMravcovTypu3(int pocet)
        {
            pocetMravcovTypu3 = pocet;
        }
        public static void NastavPocetMravcovTypu4(int pocet)
        {
            pocetMravcovTypu4 = pocet;
        }
        public static void NastavPocetSkal(int pocet)
        {
            pocetSkal = pocet;
        }
        public static void NastavMnozstvoPotravy(int mnozstvo)
        {
            mnzostvoPotravy = mnozstvo;
        }
        public static void NastavMinimalneMnozstvoPotravy(int mnozstvo)
        {
            minimalneMnozstvoPotravy = mnozstvo;
        }

        public static int ZistiRozmerMraveniska()
        {
            return rozmerMraveniska;
        }
        public static int ZistiPocetMravcovTypu1()
        {
            return pocetMravcovTypu1;
        }
        public static int ZistiPocetMravcovTypu2()
        {
            return pocetMravcovTypu2;
        }
        public static int ZistiPocetMravcovTypu3()
        {
            return pocetMravcovTypu3;
        }
        public static int ZistiPocetMravcovTypu4()
        {
            return pocetMravcovTypu4;
        }
        public static int ZistiPocetSkal()
        {
            return pocetSkal;
        }
        public static int ZistiMnozstvoPotravy()
        {
            return mnzostvoPotravy;
        }
        public static int ZistiMinimalneMnozstvoPotravy()
        {
            return minimalneMnozstvoPotravy;
        }

    }
}
