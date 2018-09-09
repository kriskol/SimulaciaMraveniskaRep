using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulaciaMraveniskaObjektyNaMravenisku;

//hlasky pri textovom vystupe
namespace SimulaciaMraveniskaHlasky
{
    //hlasky popisujuce cinnosti mravcov, resp. akcie
    //ktore mravce vykonali, alebo boli ich sucastou
    //takisto existenciu inych objektov
    static class HlaskyCinnostiMravcovStavObjektov
    {
        private static void MravecCisloCas(int cas, int cisloMravca, int cisloTypuMravca)
        {
            Console.Write("[" + cas + "] Mravec cislo " + cisloMravca + " typu " + cisloTypuMravca + " ");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Mravec cislo " + cisloMravca + " typu " + cisloTypuMravca + " ");
        }

        public static void MravecZostalStat(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" zostal stat na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" zostal stat na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecSaOtocilDolava(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa otocil vlavo na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa otocil vlavo na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecIdeDopreduUtocne(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" ide utocne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" ide utocne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecIdeDopreduObranne(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" ide obranne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" ide obranne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecJe(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa najedol a zvysila sa jeho energia na " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa najedol a zvysila sa jeho energia na " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecBojovalV(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" bojoval a vyhral, jeho energia sa zvysila na " + energia + " je na policku so suradnicami" + xSuradnica, "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" bojoval a vyhral, jeho energia sa zvysila na " + energia + " je na policku so suradnicami" + xSuradnica, "," + ySuradnica + ".");
        }
        public static void MravecSaRozhodolParit(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa chce parit na policku " + xSuradnica, "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa chce parit na policku " + xSuradnica, "," + ySuradnica + ".");
        }
        public static void MravecSaPari(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa pari na policku " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa pari na policku " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecPrisielNaPolicko(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);

            Console.WriteLine(" prisiel na policko so suradnicami " + xSuradnica + "," + ySuradnica);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel na policko so suradnicami " + xSuradnica + "," + ySuradnica);
        }
        public static void ZnizenaEnergiaMravcaParenie(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" prisiel pri pareni o energiu, terajsia hodnota energie:" + energia + " je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel pri pareni o energiu, terajsia hodnota energie:" + energia + " je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void ZnizenaEnergiaMravcaUskok(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" prisiel pri uskok od boja o energiu, terajsia hodnota energie:" + energia + " teraz je na policku so suradnicamu" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel pri uskok od boja o energiu, terajsia hodnota energie:" + energia + " teraz je na policku so suradnicamu" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void ZnizenaEnergiaMravcaNaKonciDanehoCasu(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" prisiel na konci kroku o energiu, hodnota jeho energie je: " + energia + ", je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel na konci kroku o energiu, hodnota jeho energie je: " + energia + ", je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecZanikolNaPolickuPriBoji(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" zanikol pri prehratom boji na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" zanikol pri prehratom boji na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecZanikolNaPolickuNedostatokEnergie(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" zanikol kvoli nedostatku energie na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" zanikol kvoli nedostatku energie na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecVznikolNaPolickuSoZaciatocnouEnergiou(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" vznikol so zaciatocnou energiou: " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" vznikol so zaciatocnou energiou: " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }

        public static void PotravaVzniklaNaPolicku(int cas, int xSuradnica, int ySuradnica, int energia)
        {
            Console.WriteLine("[" + cas + "] Vznikla potrava na pozicii so suradnicami " + xSuradnica + "," + ySuradnica + " s energiou " + energia);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Vznikla potrava na pozicii so suradnicami " + xSuradnica + "," + ySuradnica + " s energiou " + energia);
        }
        public static void PotravaZanikla(int cas, int xSuradnica, int ySuradnica)
        {
            Console.WriteLine("[" + cas + "] Potrava zanikla na policku so suradnicami " + xSuradnica + "," + ySuradnica);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Potrava zanikla na policku so suradnicami " + xSuradnica + "," + ySuradnica);
        }
        public static void SkalaVznikla(int cas, int xSuradnica, int ySuradnica)
        {
            Console.WriteLine("[" + cas + "] Vznikla skala na policku so suradnicami " + xSuradnica + "," + ySuradnica);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Vznikla skala na policku so suradnicami " + xSuradnica + "," + ySuradnica);
        }
    }
}
