using SimulaciaMraveniskaSimulacia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
    //spravuje hodnoty, ktore sa vypisuju v casti Simulacia
    public static class HodnotyNaVypisovanie
    {
        private static int pocetMravcovTypu1;
        private static int pocetMravcovTypu2;
        private static int pocetMravcovTypu3;
        private static int pocetMravcovTypu4;

        private static int pocetMravcovTypu1Celkovo;
        private static int pocetMravcovTypu2Celkovo;
        private static int pocetMravcovTypu3Celkovo;
        private static int pocetMravcovTypu4Celkovo;

        private static int mnozstvoPotravy;
        private static int mnozstvoPotravyCelkovo;

        private static int cas;

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

        public static void NastavPocetMravcovTypu1Celkovo(int pocet)
        {
            pocetMravcovTypu1Celkovo = pocet;
        }
        public static void NastavPocetMravcovTypu2Celkovo(int pocet)
        {
            pocetMravcovTypu2Celkovo = pocet;
        }
        public static void NastavPocetMravcovTypu3Celkovo(int pocet)
        {
            pocetMravcovTypu3Celkovo = pocet;
        }
        public static void NastavPocetMravcovTypu4Celkovo(int pocet)
        {
            pocetMravcovTypu4Celkovo = pocet;
        }

        public static void NastavMnozstvoPotravy(int pocet)
        {
            mnozstvoPotravy = pocet;
        }
        public static void NastavMnozsvtvoPotravyCelkovo(int pocet)
        {
            mnozstvoPotravyCelkovo = pocet;
        }

        public static void NastavCas(int casNastav)
        {
            cas = casNastav;
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

        public static int ZistiPocetMravcovTypu1Celkovo()
        {
            return pocetMravcovTypu1Celkovo;
        }
        public static int ZistiPocetMravcovTypu2Celkovo()
        {
            return pocetMravcovTypu2Celkovo;
        }
        public static int ZistiPocetMravcovTypu3Celkovo()
        {
            return pocetMravcovTypu3Celkovo;
        }
        public static int ZistiPocetMravcovTypu4Celkovo()
        {
            return pocetMravcovTypu4Celkovo;
        }

        public static int ZistiMnozstvoPotravy()
        {
            return mnozstvoPotravy;
        }
        public static int ZistiMnozstvoPotravyCelkovo()
        {
            return mnozstvoPotravyCelkovo;
        }

        public static int ZistiCas()
        {
            return cas;
        }

        //nacita udaje z "vypisovacieUdaje"
        public static void NacitajUdaje(VypisovacieUdaje vypisovacieUdaje)
        {
            NastavPocetMravcovTypu1(vypisovacieUdaje.ZistiPocetMravcovTypu1());
            NastavPocetMravcovTypu1Celkovo(vypisovacieUdaje.ZistiPocetMravcovTypu1Celkovo());
            NastavPocetMravcovTypu2(vypisovacieUdaje.ZistiPocetMravcovTypu2());
            NastavPocetMravcovTypu2Celkovo(vypisovacieUdaje.ZistiPocetMravcovTypu2Celkovo());
            NastavPocetMravcovTypu3(vypisovacieUdaje.ZistiPocetMravcovTypu3());
            NastavPocetMravcovTypu3Celkovo(vypisovacieUdaje.ZistiPocetMravcovTypu3Celkovo());
            NastavPocetMravcovTypu4(vypisovacieUdaje.ZistiPocetMravcovTypu4());
            NastavPocetMravcovTypu4Celkovo(vypisovacieUdaje.ZistiPocetMravcovTypu4Celkovo());

            NastavMnozstvoPotravy(vypisovacieUdaje.ZistiMnozstvoPotravy());
            NastavMnozsvtvoPotravyCelkovo(vypisovacieUdaje.ZistiMnozstvoPotravyCelkovo());

            NastavCas(vypisovacieUdaje.ZistiCas());
        }

        //vypise udaje do GUI
        public static void VypisUdaje(Label dobaBehu, Label pocetMravcovTypu1,
                                        Label pocetMravcovTypu1Celkovo, Label pocetMravcovTypu2,
                                        Label pocetMravcovTypu2Celkovo, Label pocetMravcovTypu3,
                                        Label pocetMravcovTypu3Celkovo, Label pocetMravcovTypu4,
                                        Label pocetMravcovTypu4Celkovo, Label mnozstvoPotravy,
                                        Label pocetPotravyCelkovo)
        {

            dobaBehu.Text = ZistiCas().ToString();
            pocetMravcovTypu1.Text = ZistiPocetMravcovTypu1().ToString();
            pocetMravcovTypu1Celkovo.Text = ZistiPocetMravcovTypu1Celkovo().ToString();
            pocetMravcovTypu2.Text = ZistiPocetMravcovTypu2().ToString();
            pocetMravcovTypu2Celkovo.Text = ZistiPocetMravcovTypu2Celkovo().ToString();
            pocetMravcovTypu3.Text = ZistiPocetMravcovTypu3().ToString();
            pocetMravcovTypu3Celkovo.Text = ZistiPocetMravcovTypu3Celkovo().ToString();
            pocetMravcovTypu4.Text = ZistiPocetMravcovTypu4().ToString();
            pocetMravcovTypu4Celkovo.Text = ZistiPocetMravcovTypu4Celkovo().ToString();
            mnozstvoPotravy.Text = ZistiMnozstvoPotravy().ToString();
            pocetPotravyCelkovo.Text = ZistiMnozstvoPotravyCelkovo().ToString();
        }
    }
}
