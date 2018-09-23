using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulaciaMraveniskaObjektyNaMravenisku;

//hlasky pri textovom vystupe
namespace SimulaciaMraveniskaHlasky
{
    //informacne hlasky pocas simulacie
    static class HlaskyInformacnePocasSimulacie
    {

        public static void VypisCasu(int cas)
        {
            Console.WriteLine("Terajsi cas je:" + cas);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Terajsi cas je:" + cas);
        }
        public static void VypisPoctuMravcov(int pocetMravcovTypu1, int pocetMravcovTypu2,
                                            int pocetMravcovTypu3, int pocetMravcovTypu4)
        {
            Console.WriteLine("Pocty mravcov:");
            Console.WriteLine("typu 1:" + pocetMravcovTypu1);
            Console.WriteLine("typu 2:" + pocetMravcovTypu2);
            Console.WriteLine("typu 3:" + pocetMravcovTypu3);
            Console.WriteLine("typu 4:" + pocetMravcovTypu4);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Pocty mravcov:");
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 1:" + pocetMravcovTypu1);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 2:" + pocetMravcovTypu2);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 3:" + pocetMravcovTypu3);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 4:" + pocetMravcovTypu4);
        }
        public static void VypisPoctuPotravy(int pocetPotravy)
        {
            Console.WriteLine("Mnozstvo policok s potravou " + pocetPotravy);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Mnozstvo policok s potravou " + pocetPotravy);
        }
        public static void KoniecSimulacie(int cas)
        {
            Console.WriteLine("Simulacie skoncila v case: " + cas);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Simulacie skoncila v case: " + cas);
        }
    }
}
