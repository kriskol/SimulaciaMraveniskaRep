using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
    //hodnoty reprezentujuce stav simulacie nastavovanej v casti Simulacia
    public static class HodnotyStavuSimulacie
    {
        static bool simulaciaBolaSpustena = false;
        static bool simmulaciaBolaZastavena = false;
        static bool simulaciaBolaUkoncena = true;
        static bool jeNastaveneMiestoUlozenia = false;
        static string miestoUlozenia = "";
        static int rychlostSimulacie = 1;

        static ListBox[,] konanieMravcov = new ListBox[4, 7];

        //pomaha pri nastavovani strategie mravcov
        public static void NastavKonanie(ListBox[,] listBoxes)
        {
            konanieMravcov = listBoxes;
        }

        //spravuje spustenie simulacie
        public static void NastavBolasSpustena()
        {
            if (NacitaneHodnoty.ZistiNastaveneNastavenia())
            {
                simulaciaBolaSpustena = true;
                simmulaciaBolaZastavena = false; simulaciaBolaUkoncena = false;

                SpravaBehuGUI.SimulaciaBolaSpustena();
            }
            else
            {
                MessageBox.Show("Pred spustenim simulácie musíte nastaviť nastavenia.");
            }
        }

        //spravuje spustenie, alebo zastavenie simulacie
        public static void NastavBolaZastavenaPokracuje(bool pravdivost)
        {

            simmulaciaBolaZastavena = pravdivost;

            if (ZistiBolaZastavena()) SpravaBehuGUI.SimulaciaBolaZastavena();
            else SpravaBehuGUI.SimulaciaPokracuje();
        }

        //spravuje ukoncenie simulacie
        public static void NastavBolaUkoncena(NumericUpDown pocetMravcovTypu1, //spravuje 
                                                NumericUpDown pocetMravcovTypu2,                //ukoncenie simulacie
                                                NumericUpDown pocetMravcovTypu3,
                                                NumericUpDown pocetMravocvTypu4,
                                                NumericUpDown pocetSkal,
                                                NumericUpDown mnozstvoPotravyZaciatocnej,
                                                NumericUpDown mnozstvoPotravyMinimalnej)
        {

            simulaciaBolaUkoncena = true;
            simulaciaBolaSpustena = false;
            simmulaciaBolaZastavena = false;

            SpravaBehuGUI.SimulaciaBolaUkoncena(pocetMravcovTypu1, pocetMravcovTypu2, pocetMravcovTypu3,
                                                    pocetMravocvTypu4, pocetSkal, mnozstvoPotravyZaciatocnej,
                                                    mnozstvoPotravyMinimalnej);

        }
        public static void NastavMiestoUlozenie(string miesto)
        {
            miestoUlozenia = miesto;
            Console.WriteLine(miestoUlozenia);
            jeNastaveneMiestoUlozenia = true;
        }
        public static void NastavRychlostSimulacie(int rychlost)
        {
            rychlostSimulacie = rychlost;
        }

        public static ListBox[,] ZistiKonanie()
        {
            return konanieMravcov;
        }
        public static bool ZistiBolaSpustena()
        {
            return simulaciaBolaSpustena;
        }
        public static bool ZistiBolaZastavena()
        {
            return simmulaciaBolaZastavena;
        }
        public static bool ZistiBolaUkoncena()
        {
            return simulaciaBolaUkoncena;
        }
        public static bool ZistiNastavenostMiestaUlozenia()
        {
            return jeNastaveneMiestoUlozenia;
        }
        public static string ZistiMiestoUlozenia()
        {
            return miestoUlozenia;
        }
        public static int ZistiRychlostSimulacie()
        {
            return rychlostSimulacie;
        }

        public static void ResetujMiestoUlozenia()
        {
            jeNastaveneMiestoUlozenia = false;
            miestoUlozenia = "";
        }
    }
}
