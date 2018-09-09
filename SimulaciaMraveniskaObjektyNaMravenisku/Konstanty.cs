using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //konstantne,staticke sucasti programu
    public static class Konstanty
    {
        public const int maximumEnergiaPotrava = 101;
        public const int minimumEnergiaPotrava = 50;
        public const int maximumEnergiaMravec = 101;
        public const int minusHodnotaPriKrmeni = 5;
        public static int minimumPotravy;
        public const int dobaPrestavky = 2000;
        public static bool jeNastaveneMiestoUlozenia = false;
        public static string miestoUlozenia = "";
        public static System.IO.StreamWriter zapisovacUdajov;
        private static int nasobokDobyPrestavky = 1;

        public static StrategiaMravca strategiaMravcaTypu1;
        public static StrategiaMravca strategiaMravcaTypu2;
        public static StrategiaMravca strategiaMravcaTypu3;
        public static StrategiaMravca strategiaMravcaTypu4;

        public static CinnostiMravcov[,] cinnostiMravcovTypu1 = {{CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.otocSaVlavo, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.otocSaVlavo, CinnostiMravcov.chodDopreduObrana },
        { CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa },
        { CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok },
        { CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa},
        };
        public static CinnostiMravcov[,] cinnostiMravcovTypu2 =
        {
            {CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.otocSaVlavo, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok},
            {CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.najedzSa, CinnostiMravcov.chodDopreduUtok },
            {CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok},
            {CinnostiMravcov.najedzSa, CinnostiMravcov.paritSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok },
        };

        public static void NastavStrategiuMravceTypu1()
        {
            strategiaMravcaTypu1 = new StrategiaMravca(cinnostiMravcovTypu1);
        }
        public static void NastavStrategiuMravceTypu2()
        {
            strategiaMravcaTypu2 = new StrategiaMravca(cinnostiMravcovTypu2);
        }
        public static void NastavStrategiuMravceTypu3(CinnostiMravcov[,] cinnostMravcov)
        {
            strategiaMravcaTypu3 = new StrategiaMravca(cinnostMravcov);
        }
        public static void NastavStrategiuMravceTypu4(CinnostiMravcov[,] cinnostiMravcov)
        {
            strategiaMravcaTypu4 = new StrategiaMravca(cinnostiMravcov);
        }
        public static void NastavMinimumPotravy(int Potrava)
        {
            minimumPotravy = Potrava;
        }
        public static void NastavMiestoUlozenia(string miesto)
        {
            miestoUlozenia = miesto;

            if (miesto != "")
            {
                zapisovacUdajov = new System.IO.StreamWriter(miestoUlozenia);

                ; jeNastaveneMiestoUlozenia = true;
            }
            else jeNastaveneMiestoUlozenia = false;

        }
        public static void NastavNasobokDobyPrestavky(int nasobok)
        {
            nasobokDobyPrestavky = nasobok;
        }
        public static int ZistiVyslednuDobuPrestavku()
        {
            return dobaPrestavky * nasobokDobyPrestavky;
        }
    }
}
