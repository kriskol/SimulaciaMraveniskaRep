using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using SimulaciaMraveniskaSimulacia;
using SimulaciaMraveniskaUdalostiSpravaUdalosti;
using SimulaciaMraveniskaGUI;

namespace SimulaciaMraveniskaGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //iniciallzacia niektorych hodnot v casti "NacitaneHodnoty" ako su pocty mravcov a inych objektov
            //takisto rozmery mravenisk
            //taktiez inicializacie "ListBoxov" reprezentujucich konanie mravcov "Nastavenia Mravcov"
            InicializujListBoxs();
            InicializaciaNastaveni();
            NacitaneHodnoty.InicializujPoctyHodnotMravcov(pocetMravcovTypu1Nastavenia, pocetMravcovTypu2Nastavenia,
                                                            pocetMravcovTypu3Nastavenia, pocetMravcovTypu4Nastavenia);
            NacitaneHodnoty.InicializujIneHodnoty(pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia,
                                                    minimalneMnozstvoPotravyNastavenia);

        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click_1(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //inicializuje pole "ListBox-ov", ktore reprezentuje nastavenie konania mravcov v danej situacii
        private void InicializujListBoxs()
        {
            ListBox[,] listBoxes = new ListBox[,] { { prazdnaPrazdnaStrategia, prazdnaSkalaStrategia, prazdnaPotravaStrategia,
                                                    prazdnaVpreduPriatelPrazdnaStrategia, prazdnaVpreduPriatelPotravaStrategia,
                                                    prazdnaVpreduNepriatelPrazdnaStrategia, prazdnaVpreduNepriatelPotravaStrategia},
                                                    { potraPrazdnaStrategia, potravaSkalaStrategia, potravaPotravaStrategia,
                                                        potravaVpreduPriatelPrazdnaStrategia, potravaVpreduPriatelPotravaStrategia,
                                                        potravaVpreduNepriatelPrazdnaStrategia, prazdnaVpreduNepriatelPotravaStrategia},
                                                     { priatelPrazdnaPrazdnaStrategia, priatelPrazdnaSkalaStrategia, priatelPrazdnaPotravaStrategia,
                                                        priatelPrazdnaVpreduPriatelPrazdnaStrategia, priatelPrazdnaVpreduPriatelPotravaStrategia,
                                                        priatelPrazdnaVpreduNepriatelPrazdnaStrategia, priatelPrazdnaVpreduNepriatelPotravaStrategia},
                                                     { priatelPotravaPrazdnaStrategia, priatelPotravaSkalaStrategia, priatelPotravaPotravaStrategia,
                                                        priatelPotravaVpreduPriatelPrazdnaStrategia, priatelPotravaVpreduPriatelPotravaStrategia,
                                                        priatelPotravaVpreduNepriatelPrazdnaStrategia, priatelPotravaVpreduNepriatelPotravaStrategia} };

            Hodnoty.NastavKonanie(listBoxes);
        }

        //spravuje nastavenie strategie mravcov
        private void nastavNastavenMravca_Click(object sender, EventArgs e)
        {
            SpravaStrategiaMravcov.Nastav(vyberTypuMravca, pocetMravcovTypu3Nastavenia, pocetMravcovTypu4Nastavenia);
        }

        //inicializacia niektorych nastaveni, v sucasnom stave, nastavuje ako
        //pociatocny rozmer mraveniska na 8x8
        private void InicializaciaNastaveni()
        {
            velkostMraveniskaNastavenia.SetSelected(0, true);

            NacitaneHodnoty.NastavRozmerMraveniska(8, pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia,
                                                    minimalneMnozstvoPotravyNastavenia);


        }

        //reakcia na nastavenie zaciatocneho poctu potravi v casti Nastavenia
        private void mnozstvoZaciatocnejPotravyNastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavMnozstvoZaciatocnejPotravy((int)numericUpDown.Value, mnozstvoZaciatocnejPotravyNastavenia,
                                                            pocetSkalNastavenia, minimalneMnozstvoPotravyNastavenia);
        }

        //reakcia na nastavenie mnozstav minimalnej potravy v casti Nastavenia
        private void minimalneMnozstvoPotravyNastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavMnozstvoMinimalnejPotravy((int)numericUpDown.Value, minimalneMnozstvoPotravyNastavenia,
                                                            pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia);
        }

        //reakcia na nastavenie poctu skal v casti Nastavenia
        private void pocetSkalNastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetSkal((int)numericUpDown.Value, pocetSkalNastavenia,
                                            mnozstvoZaciatocnejPotravyNastavenia,
                                            minimalneMnozstvoPotravyNastavenia);
        }

        //reakcia na nastavenie velkosti mraveniska v casti Nastavenia
        private void velkostMraveniskaNastavenia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            switch (listBox.GetItemText(listBox.SelectedItem))
            {
                case "8x8":
                    NacitaneHodnoty.NastavRozmerMraveniska(8, minimalneMnozstvoPotravyNastavenia,
                                                            pocetSkalNastavenia,
                                                            mnozstvoZaciatocnejPotravyNastavenia); break;
                case "16x16":
                    NacitaneHodnoty.NastavRozmerMraveniska(16, minimalneMnozstvoPotravyNastavenia,
                                                              pocetSkalNastavenia,
                                                              mnozstvoZaciatocnejPotravyNastavenia); break;
                case "32x32":
                    NacitaneHodnoty.NastavRozmerMraveniska(32, minimalneMnozstvoPotravyNastavenia,
                                                               pocetSkalNastavenia,
                                                               mnozstvoZaciatocnejPotravyNastavenia); break;

            }
        }

        //reakcia na nastavenie poctu mravcov typu 1 v casti nastavenia
        private void pocetMravcovTypu1Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu1((int)numericUpDown.Value);
        }

        //reakcia na nastavenie poctu mravcov typu 2 v casti Nastavenia
        private void pocetMravcovTypu2Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu2((int)numericUpDown.Value);
        }

        //reakcia na nastavenie poctu mravcov typu 3 v casti Nastavenia
        private void pocetMravcovTypu3Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu3((int)numericUpDown.Value);
        }

        //reakcia na nastavenie poctu mravcov  typu 4 v casti Nastavenia
        private void pocetMravcovTypu4Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu4((int)numericUpDown.Value);
        }

        //reakcia na spustenie simulacie
        private void spustenieSimulacie_Click(object sender, EventArgs e)
        {
            if (!Hodnoty.ZistiBolaSpustena()) Hodnoty.NastavBolasSpustena(true);
        }

        //reakcia na zastavenie, resp. pokracovanie, simulacie
        private void zastaveniePokracovanieSimulacie_Click(object sender, EventArgs e)
        {
            if (Hodnoty.ZistiBolaSpustena())
            {
                if (!Hodnoty.ZistiBolaZastavena())
                {
                    Hodnoty.NastavBolaZastavenaPokracuje(true);
                    zastaveniePokracovanieSimulacie.Text = "pokracuj";
                }
                else
                {
                    Hodnoty.NastavBolaZastavenaPokracuje(false);
                    zastaveniePokracovanieSimulacie.Text = "zastav";
                }
            }
            else
            {
                MessageBox.Show("Nema zmysel.");
            }
        }

        //reakcia na skoncenie simulacie
        private void skoncenieSimulacie_Click(object sender, EventArgs e)
        {
            if (!Hodnoty.ZistiBolaUkoncena() && Hodnoty.ZistiBolaSpustena())
            {
                InicializaciaNastaveni();

                Hodnoty.NastavBolaUkoncena(true, pocetMravcovTypu1Nastavenia,
                             pocetMravcovTypu2Nastavenia,
                             pocetMravcovTypu3Nastavenia,
                             pocetMravcovTypu4Nastavenia,
                             pocetSkalNastavenia,
                             mnozstvoZaciatocnejPotravyNastavenia,
                             minimalneMnozstvoPotravyNastavenia);
            }
            else MessageBox.Show("Nema zmysel ukoncovat simulaciu");
        }

        //reakcia na poziadavku o vypisovanie udajov v casti Simulacia
        private void button1_Click(object sender, EventArgs e)
        {
            SpravaBehuGUI.VypisUdaje(dobaSimulacia, pocetMravcovTypu1TerazSimulacia, pocetMravcovTypu1CelkovoSimulacia,
                                    pocetMravcovTypu2TerazSimulacia, pocetMravcovTypu2CelkovoSimulacia,
                                    pocetMravcovTypu3TerazSimulacia, pocetMravcovTypu3CelkovoSimulacia,
                                    pocetMravcovTypu4TerazSimulacia, pocetMravcovTypu4CelkovoSimulacia,
                                    mnoztvoPotravyTerazSimulacia, mnozstvoPotravyCelkovoSimulacia);
        }

        //prvky reprezentuju ci bol v casti Nastavenie nastavy pocet skal,
        //mnozstvo potravy zaciatocnej alebo minimalnej
        public enum Nastaveny
        {
            skaly,
            zaciatocnaPotrava,
            minimalnaPotrava
        }

        //hodnoty reprezentujuce stav simulacie nastavovanej v casti Simulacia
        public static class Hodnoty
        {
            static bool simulaciaBolaSpustena = false;
            static bool simmulaciaBolaZastavena = false;
            static bool simulaviaBolaUkoncena = true;
            static bool jeNastavenieMiestoUlozenia = false;
            static string miestoUlozenia = "";
            static int rychlostSimulacie = 1;

            static ListBox[,] konanieMravcov = new ListBox[4, 7];

            public static void NastavKonanie(ListBox[,] listBoxes)
            {

                konanieMravcov = listBoxes;
            }//pomaha pri nastavovani strategie mravcov
            public static void NastavBolasSpustena(bool pravdivost)
            {
                if (NacitaneHodnoty.ZistiNastaveneNastavenia())
                {
                    simulaciaBolaSpustena = pravdivost;

                    if (simulaciaBolaSpustena) { simmulaciaBolaZastavena = false; simulaviaBolaUkoncena = false; }

                    SpravaBehuGUI.SimulaciaBolaSpustena();
                }
                else
                {
                    MessageBox.Show("Pred spustenim simulácie musíte nastaviť nastavenia.");
                }
            }//spravuje spustenie simulacie
            public static void NastavBolaZastavenaPokracuje(bool pravdivost)
            {

                simmulaciaBolaZastavena = pravdivost;

                if (ZistiBolaZastavena()) SpravaBehuGUI.SimulaciaBolaZastavena();
                else SpravaBehuGUI.SimulaciaPokracuje();
            }//spravuje zastavenie, alebo spustenie
             //simulacie
            public static void NastavBolaUkoncena(bool pravdivost, NumericUpDown pocetMravcovTypu1, //spravuje 
                                                    NumericUpDown pocetMravcovTypu2,                //ukoncenie simulacie
                                                    NumericUpDown pocetMravcovTypu3,
                                                    NumericUpDown pocetMravocvTypu4,
                                                    NumericUpDown pocetSkal,
                                                    NumericUpDown mnozstvoPotravyZaciatocnej,
                                                    NumericUpDown mnozstvoPotravyMinimalnej)
            {

                simulaviaBolaUkoncena = pravdivost;
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
                jeNastavenieMiestoUlozenia = true;
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
                return simulaviaBolaUkoncena;
            }
            public static bool ZistiNastavenostMiestaUlozenia()
            {
                return jeNastavenieMiestoUlozenia;
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
                jeNastavenieMiestoUlozenia = false;
                miestoUlozenia = "";
            } 
        }

        //spravuje beh simulacie podla prikazov z uzivatelskeho rozhrania
        public static class SpravaBehuGUI
        {
            static BehSimulacie behSimulacie;

            //spravuje spustenie simulacie
            public static void SimulaciaBolaSpustena()
            {
                ZadaneHodnoty.NastavPocetMravcovTypu1(NacitaneHodnoty.ZistiPocetMravcovTypu1());
                ZadaneHodnoty.NastavPocetMravcovTypu2(NacitaneHodnoty.ZistiPocetMravcovTypu2());
                ZadaneHodnoty.NastavPocetMravcovTypu3(NacitaneHodnoty.ZistiPocetMravcovTypu3());
                ZadaneHodnoty.NastavPocetMravcovTypu4(NacitaneHodnoty.ZistiPocetMravcovTypu4());

                ZadaneHodnoty.NastavMinimalneMnozstvoPotravy(NacitaneHodnoty.ZistiMnozstvoMinimalnejPotravy());
                ZadaneHodnoty.NastavMnozstvoPotravy(NacitaneHodnoty.ZistiMnozstvoStartovnejPotavy());

                ZadaneHodnoty.NastavPocetSkal(NacitaneHodnoty.ZistiPocetSkal());
                ZadaneHodnoty.NastavRozmerMraveniska(NacitaneHodnoty.ZistiRozmerMraveniska());

                Konstanty.NastavNasobokDobyPrestavky(Hodnoty.ZistiRychlostSimulacie());

                behSimulacie = new BehSimulacie();
                behSimulacie.InicializujSimulaciu(Hodnoty.ZistiMiestoUlozenia());

                behSimulacie.SpustiSimulaciu();
            }

            //spravuje zastavenie simulacie
            public static void SimulaciaBolaZastavena()
            {
                NastaveneHodnotyPocasKrokov.NastavPokracovanie(false);
            }

            //spravuje pokracovanie simulacie
            public static void SimulaciaPokracuje()
            {
                NastaveneHodnotyPocasKrokov.NastavPokracovanie(true);

                behSimulacie.SpustiSimulaciu();
            }

            //spravuje ukoncenie simulacie a inicializaciu cast hodnot pre pripadne dalsie spustenie simulacie
            //zvysok sa inicializuje v casti InicializaciaNastaveni
            public static void SimulaciaBolaUkoncena(NumericUpDown pocetMravcovTypu1, NumericUpDown pocetMravcovTypu2,
                                                        NumericUpDown pocetMravcovTypu3, NumericUpDown poceMravcovTypu4,
                                                        NumericUpDown pocetSkal, NumericUpDown mnozstvoPotravyZaciatocnej,
                                                        NumericUpDown mnozstvoPotravyMinnimalnej)
            {
                NastaveneHodnotyPocasKrokov.NastavPokracovanie(false);
                NacitaneHodnoty.NastavNastavenia(false);

                Hodnoty.ResetujMiestoUlozenia();

                behSimulacie.UkonecieSimulacie();
                behSimulacie.InicializujSimulaciu("");

                

                NacitaneHodnoty.InicializujPoctyHodnotMravcov(pocetMravcovTypu1, pocetMravcovTypu2, pocetMravcovTypu3,
                                                                poceMravcovTypu4);
                NacitaneHodnoty.InicializujIneHodnoty(pocetSkal, mnozstvoPotravyZaciatocnej, mnozstvoPotravyMinnimalnej);
            }

            //spravuje vypisovanie udajov v casti Simulacia
            public static void VypisUdaje(Label dobaBehu, Label pocetMravcovTypu1, Label pocetMravcovTypu1Celkovo,
                                            Label pocetMravcovTypu2, Label pocetMravcovTypu2Celkovo,
                                            Label pocetMravcovTypu3, Label pocetMravcovTypu3Celkovo,
                                            Label pocetMravcovTypu4, Label pocetMravcovTypu4Celkovo,
                                            Label mnozsvtoPotrava, Label pocetPotravyCelkovo)
            {
                VypisovacieUdaje vypisovacieUdaje = default(VypisovacieUdaje);

                if (Hodnoty.ZistiBolaSpustena())
                {
                    vypisovacieUdaje = behSimulacie.ZistiUdaje();
                    HodnotyNaVypisovanie.NacitajUdaje(vypisovacieUdaje);
                    HodnotyNaVypisovanie.VypisUdaje(dobaBehu, pocetMravcovTypu1, pocetMravcovTypu1Celkovo,
                                                pocetMravcovTypu2, pocetMravcovTypu2Celkovo, pocetMravcovTypu3,
                                                pocetMravcovTypu3Celkovo, pocetMravcovTypu4, pocetMravcovTypu4Celkovo,
                                                mnozsvtoPotrava, pocetPotravyCelkovo);
                }
                else
                    MessageBox.Show("Musíte najpr spustiť simuláciu pre vypysovanie údajov.");

            }
        }

        //spravuje nacitanie hodnot z casti Nastavenia a objekty v tejto cas
        public static class NacitaneHodnoty
        {
            private static bool nastavenieNastavenia;

            private static int pocetMravcovTypu1;
            private static int pocetMravcovTypu2;
            private static int pocetMravcovTypu3;
            private static int pocetMravcovTypu4;

            private static int pocetSkal;
            private static int mnozstvoZaciatocnejPotravy;
            private static int mnozstvoMinimalnejPotravy;
            private static int rozmer;

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

            //nastavy pocet skal, v zavislosti od hodnoty budu potom v casti NastavRozmedziaPreHodnoty, 
            //prenastavene rozmedzia pre pocet skal, mnozstvo potravy zaciatocnej a minimalnej
            public static void NastavPocetSkal(int pocet, NumericUpDown numericUpDownPocetSkal, NumericUpDown
                                                numericUpDownMnozstvoPotravy, NumericUpDown numericUpDownMnozstvoPotravyMin)
            {
                pocetSkal = pocet;

                NastavRozmedziaPreHodnoty(Nastaveny.skaly, numericUpDownPocetSkal, numericUpDownMnozstvoPotravy,
                    numericUpDownMnozstvoPotravyMin);
            }

            //nastavy pocet zaciatocnej potravy, v zavislosti od hodnoty budu potom v casti NastavRozmerdiaPreHodnoty
            //prenastavene rozmedzia pre pocet skal, mnozstvo potravy zaciatocnej a minimalnej
            public static void NastavMnozstvoZaciatocnejPotravy(int pocet, NumericUpDown numericUpDownMnozstvoPotravy,
                                                                NumericUpDown numericUpDownPocetSkal,
                                                                NumericUpDown numericUpDownMnozstvoPotravyMin)
            {
                mnozstvoZaciatocnejPotravy = pocet;

                NastavRozmedziaPreHodnoty(Nastaveny.zaciatocnaPotrava, numericUpDownPocetSkal, numericUpDownMnozstvoPotravy,
                                            numericUpDownMnozstvoPotravyMin);
            }

            //nastavy pocet pocet minimalnej potravy, v zavislosti od hodnoty budu potom v casti NastavRozmedziaPreHodnoty
            //prenastavene rozmedzia pre pocet skal, mnozstvo potravy zaciatocnej a minimalnej
            public static void NastavMnozstvoMinimalnejPotravy(int pocet, NumericUpDown numericUpDownMnozstvoPotravyMin,
                                                                NumericUpDown numericUpDownPocetSkal,
                                                                NumericUpDown numericUpDownMnozstvoPotravy)
            {
                mnozstvoMinimalnejPotravy = pocet;

                NastavRozmedziaPreHodnoty(Nastaveny.minimalnaPotrava, numericUpDownPocetSkal,
                                            numericUpDownMnozstvoPotravy, numericUpDownMnozstvoPotravyMin);
            }

            //nastavy rozmer mraveniska, a v casti NastavHodnotyVzhladomRozmer prenastavy medze a hodnoty
            //pre pocet skal, mnozstvo potravy zaciatocnej a minimalnej
            public static void NastavRozmerMraveniska(int rozmerNastavenie, NumericUpDown numericUpDownMnozstvoPotravyMin,
                                                        NumericUpDown numericUpDownPocetSkal,
                                                       NumericUpDown numericUpDownMnozstvoPotravy)
            {
                rozmer = rozmerNastavenie;

                NastavHodnotyVzhladomRozmer(numericUpDownPocetSkal, numericUpDownMnozstvoPotravy,
                    numericUpDownMnozstvoPotravyMin);
            }
            //nastavi ci boli alebo neboli nastavene nastavenia
            public static void NastavNastavenia(bool pravdivost)
            {
                nastavenieNastavenia = pravdivost;
            }

            //nastavi pocet skal, neaktualizuje ale rozmedzia
            private static void NastavPocetSkalVnutro(int pocet)
            {
                pocetSkal = pocet;
            }

            //nastavi pocet potravy minimalnej, neaktualizuje ale rozmedzia
            private static void NastavMnozstvoPotravyMinimalnejVnutro(int mnozstvo)
            {
                mnozstvoMinimalnejPotravy = mnozstvo;
            }

            //nastavi pocet potravy zaciatocnej, neaktualizuje ale rozmedzia
            private static void NastavMnozstvoPotravyZaciatocnejVnutro(int mnozstvo)
            {
                mnozstvoZaciatocnejPotravy = mnozstvo;
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
            public static int ZistiMnozstvoStartovnejPotavy()
            {
                return mnozstvoZaciatocnejPotravy;
            }
            public static int ZistiMnozstvoMinimalnejPotravy()
            {
                return mnozstvoMinimalnejPotravy;
            }
            public static int ZistiRozmerMraveniska()
            {
                return rozmer;


            }
            public static bool ZistiNastaveneNastavenia()
            {
                return nastavenieNastavenia;
            }

            //aktualizuje medze mravca typu 3, pokial bola nastavena jeho strategia
            public static void AktualizujPocetMravcovTypu3(NumericUpDown numericUpDown)
            {
                if (numericUpDown.Maximum == 0) numericUpDown.Maximum = 200;
            }

            //aktualizuje medze mravca typu 4, pokial bola nastavena jeho strategia
            public static void AktualizujPocetMravcovTypu4(NumericUpDown numericUpDown)
            {
                if (numericUpDown.Maximum == 0) numericUpDown.Maximum = 200;
            }

            //inicializuje niektore hodnoty
            public static void InicializujIneHodnoty(NumericUpDown mnozstvoSkal, NumericUpDown mnozstvoPotravy,
                                                        NumericUpDown mnozstvoPotravyMinimum)
            {
                mnozstvoSkal.Minimum = 0;
                mnozstvoPotravy.Minimum = 0;
                mnozstvoPotravyMinimum.Minimum = 0;

                mnozstvoSkal.Value = 0;
                mnozstvoPotravyMinimum.Value = 0;
                mnozstvoPotravy.Value = 0;

                mnozstvoPotravyMinimum.Maximum = 0;
                mnozstvoSkal.Maximum = rozmer * rozmer - 4;
                mnozstvoPotravy.Maximum = rozmer * rozmer - (int)mnozstvoSkal.Value;

                NastavNastavenia(false);

                pocetSkal = 0;
                mnozstvoZaciatocnejPotravy = 0;
                mnozstvoMinimalnejPotravy = 0;
            }

            //inicializuje hodnoty mravcov
            public static void InicializujPoctyHodnotMravcov(NumericUpDown mravceTypu1, NumericUpDown mravceTypu2,
                                                                NumericUpDown mravceTypu3, NumericUpDown mravceTypu4)
            {
                mravceTypu1.Minimum = 0;
                mravceTypu2.Minimum = 0;
                mravceTypu3.Minimum = 0;
                mravceTypu4.Minimum = 0;

                mravceTypu1.Maximum = 200;
                mravceTypu2.Maximum = 200;

                mravceTypu1.Value = 0;
                mravceTypu2.Value = 0;
                mravceTypu3.Value = 0;
                mravceTypu4.Value = 0;

                pocetMravcovTypu1 = 0;
                pocetMravcovTypu2 = 0;
                pocetMravcovTypu3 = 0;
                pocetMravcovTypu4 = 0;

                if (SpravaStrategiaMravcov.ZistiNastavenyTyp3()) mravceTypu3.Maximum = 200;
                else mravceTypu3.Maximum = 0;

                if (SpravaStrategiaMravcov.ZistiNastavenyTyp4()) mravceTypu4.Maximum = 200;
                else mravceTypu4.Maximum = 0;
            }

            //nastvi medze pre hodnoty pocet skal, mnozstvo potravy a mnozstvo potravy minimalnej; pripadne i ich nastavi
            private static void NastavRozmedziaPreHodnoty(Nastaveny nastaveny, NumericUpDown numericUpDownPocetSkal,
                                                            NumericUpDown numericUpDownMnozstvoPotravy,
                                                            NumericUpDown numericUpDownMnozstvoPotravyMin)
            {
                if (nastaveny == Nastaveny.skaly)
                {
                    numericUpDownMnozstvoPotravy.Maximum = rozmer * rozmer - numericUpDownPocetSkal.Value;

                    if (numericUpDownMnozstvoPotravy.Value >= 4)
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - numericUpDownMnozstvoPotravy.Value;
                    else
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - 4 - numericUpDownMnozstvoPotravy.Value;
                }
                else if (nastaveny == Nastaveny.zaciatocnaPotrava)
                {
                    numericUpDownMnozstvoPotravy.Maximum = rozmer * rozmer - numericUpDownPocetSkal.Value;
                    if (numericUpDownMnozstvoPotravy.Value >= 4)
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - numericUpDownMnozstvoPotravy.Value;
                    else
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - 4 - numericUpDownMnozstvoPotravy.Value;

                    if (numericUpDownMnozstvoPotravyMin.Value > numericUpDownMnozstvoPotravy.Value)
                    {
                        numericUpDownMnozstvoPotravyMin.Value = numericUpDownMnozstvoPotravy.Value;
                        NastavMnozstvoPotravyMinimalnejVnutro((int)numericUpDownMnozstvoPotravyMin.Value);
                    }

                    numericUpDownMnozstvoPotravyMin.Maximum = numericUpDownMnozstvoPotravy.Value;
                }
            }

            //nastavy medzi pre hodnoty pocet skal, mnnozstvo potravy a mnozstvo potravy minimalnej; pripadne ich i nastavi
            private static void NastavHodnotyVzhladomRozmer(NumericUpDown numericUpDownPocetSkal,
                                                            NumericUpDown numericUpDownMnozstvoPotravy,
                                                            NumericUpDown numericUpDownMnozstvoPotravyMin)
            {

                if (numericUpDownPocetSkal.Value > rozmer * rozmer - 4)
                {
                    numericUpDownPocetSkal.Value = rozmer * rozmer - 4;

                    NastavPocetSkalVnutro((int)numericUpDownPocetSkal.Value);
                }

                numericUpDownPocetSkal.Maximum = rozmer * rozmer - 4;

                if (numericUpDownMnozstvoPotravy.Value > rozmer * rozmer - (int)numericUpDownPocetSkal.Value)
                {
                    numericUpDownMnozstvoPotravy.Value = rozmer * rozmer - (int)numericUpDownPocetSkal.Value;

                    NastavMnozstvoPotravyZaciatocnejVnutro((int)numericUpDownMnozstvoPotravy.Value);
                }

                numericUpDownMnozstvoPotravy.Maximum = rozmer * rozmer - (int)numericUpDownPocetSkal.Value;

                if (numericUpDownMnozstvoPotravyMin.Value > numericUpDownMnozstvoPotravy.Value)
                {
                    numericUpDownMnozstvoPotravyMin.Value = numericUpDownMnozstvoPotravy.Value;

                    NastavMnozstvoPotravyMinimalnejVnutro((int)numericUpDownMnozstvoPotravyMin.Value);
                }

                numericUpDownMnozstvoPotravyMin.Maximum = numericUpDownMnozstvoPotravy.Value;
            }

        }

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
                                            Label pocetMravcovTypu1Cel, Label pocetMravcovTypu2,
                                            Label pocetMravcovTypu2Cel, Label pocetMravcovTypu3,
                                            Label pocetMravcovTypu3Cel, Label pocetMravcovTypu4,
                                            Label pocetMravcovTypu4Cel, Label mnozstvoPotravy,
                                            Label pocetPotravyCel)
            {

                dobaBehu.Text = ZistiCas().ToString();
                pocetMravcovTypu1.Text = ZistiPocetMravcovTypu1().ToString();
                pocetMravcovTypu1Cel.Text = ZistiPocetMravcovTypu1Celkovo().ToString();
                pocetMravcovTypu2.Text = ZistiPocetMravcovTypu2().ToString();
                pocetMravcovTypu2Cel.Text = ZistiPocetMravcovTypu2Celkovo().ToString();
                pocetMravcovTypu3.Text = ZistiPocetMravcovTypu3().ToString();
                pocetMravcovTypu3Cel.Text = ZistiPocetMravcovTypu3Celkovo().ToString();
                pocetMravcovTypu4.Text = ZistiPocetMravcovTypu4().ToString();
                pocetMravcovTypu4Cel.Text = ZistiPocetMravcovTypu4Celkovo().ToString();
                mnozstvoPotravy.Text = ZistiMnozstvoPotravy().ToString();
                pocetPotravyCel.Text = ZistiMnozstvoPotravyCelkovo().ToString();
            }
        }

        //spravuje nastavovanie strategie mravocov typu 3 a 4
        public static class SpravaStrategiaMravcov
        {
            private static TypyMravcov typyMravcov = default(TypyMravcov);
            private static CinnostiMravcov[,] strategiaMravca = new CinnostiMravcov[4, 7];
            private static bool nastavenyTyp3;//reprezentuje, ci bola nastavena strategia pre mravca typu 3
            private static bool nastavenyTyp4;//reprezentuje, ci bola nastavena strategia pre mravca typu 4

            public static void NastavTypyMravcov(TypyMravcov typ)
            {
                typyMravcov = typ;
            }
            public static void NastavNastavenyTyp3(bool nastav)
            {
                nastavenyTyp3 = nastav;
            }
            public static void NastavNastavenyTyp4(bool nastavenie)
            {
                nastavenyTyp4 = nastavenie;
            }

            public static TypyMravcov ZistiTypyMravcov()
            {
                return typyMravcov;
            }
            public static bool ZistiNastavenyTyp3()
            {
                return nastavenyTyp3;
            }
            public static bool ZistiNastavenyTyp4()
            {
                return nastavenyTyp4;
            }

            //pokial je vybraty v casti Nastavenia mravce typ mravca a jeho konanie v kazdej situacii, tak 
            //sa nastavi jeho strategia pomocou funkkcii Nastav, NastavCinnostPozicia a NastavCinnostMravca
            public static void Nastav(ListView vyber, NumericUpDown numericUpDown3, NumericUpDown numericUpDown4)
            {
                if (vyber.SelectedItems.Count > 0)
                {
                    if (vyber.SelectedItems[0].Text == "mravec typu 3") typyMravcov = TypyMravcov.MravecTypu3;
                    else typyMravcov = TypyMravcov.MravecTypu4;

                    strategiaMravca = new CinnostiMravcov[4, 7];

                    bool hodnotaUspech = true;

                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 7; j++)
                            if (!NastavCinnostPozicia(i, j, strategiaMravca, (Hodnoty.ZistiKonanie())[i, j]))
                                hodnotaUspech = false;

                    if (hodnotaUspech) NastavCinnostMravca(typyMravcov, strategiaMravca, numericUpDown3, numericUpDown4);

                }
                else
                {
                    MessageBox.Show("Nevybrali ste typ mravca, pre ktorého sa má nastavit daná stratégia");
                }
            }

            //nastavi cinnost mravca vzhladom k danej situacii
            private static bool NastavCinnostPozicia(int i, int j, CinnostiMravcov[,] cinnostiMravcov, ListBox listBox)
            {
                if (listBox.SelectedItems.Count == 0) { MessageBox.Show("Nevybrali ste pre mravca konanie vo všetkých situáciách."); return false; }
                else
                    switch (listBox.GetItemText(listBox.SelectedItem))
                    {
                        case "zostaň stáť": cinnostiMravcov[i, j] = CinnostiMravcov.zostan; break;
                        case "otoč sa vľavo": cinnostiMravcov[i, j] = CinnostiMravcov.otocSaVlavo; break;
                        case "choď dopredu obranne": cinnostiMravcov[i, j] = CinnostiMravcov.chodDopreduObrana; break;
                        case "choď dopredu útočne": cinnostiMravcov[i, j] = CinnostiMravcov.chodDopreduUtok; break;
                        case "najedz sa": cinnostiMravcov[i, j] = CinnostiMravcov.najedzSa; break;
                        case "rozmnožuj sa": cinnostiMravcov[i, j] = CinnostiMravcov.paritSa; break;
                    }

                return true;
            }

            //nastavi strategiu mravca, taktisto nastavy, ze pocet mravcov typu 3 alebo 4 moze byt rozny od 0
            private static void NastavCinnostMravca(TypyMravcov typyMravcov, CinnostiMravcov[,] cinnostiMravcov,
                NumericUpDown numericUpDown3, NumericUpDown numericUpDown4)
            {
                switch (typyMravcov)
                {
                    case TypyMravcov.MravecTypu3:
                        Konstanty.NastavStrategiu3(cinnostiMravcov); NastavNastavenyTyp3(true);
                        NacitaneHodnoty.AktualizujPocetMravcovTypu3(numericUpDown3); break;
                    case TypyMravcov.MravecTypu4:
                        Konstanty.NastavStrategiu4(cinnostiMravcov); NastavNastavenyTyp4(true);
                        NacitaneHodnoty.AktualizujPocetMravcovTypu4(numericUpDown4); break;
                }
            }
        }

        private void potravaSkalaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prazdnaVpreduPriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prazdnaVpreduPriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prazdnaVpreduNepriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prazdnaVpreduNepriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void potravaVpreduNepriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void potravaVpreduNepriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void potravaVpreduPriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void potravaVpreduPriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void potravaPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prazdnaPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void potraPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaSkalaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaVpreduPriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaVpreduPriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaVpreduNepriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPrazdnaVpreduNepriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPotravaVpreduNepriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPotravaVpreduNepriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPotravaVpreduPriatelPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPotravaVpreduPriatelPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPotravaPotravaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prazdnaSkalaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priatelPotravaPrazdnaStrategia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //pokial uzivatel nastavi nastavenia v casti "Nastavenia"
        //tak tato funkcia zabezpeci nastavenie hodnoty "nastavenieNastavenia" v casti NacitaneHodnoty
        private void nastavNastavenia_Click(object sender, EventArgs e)
        {
            NacitaneHodnoty.NastavNastavenia(true);
        }

        //správa miesta, kam sa má výpis simulácie ulozit
        private void ukladanieSimulacie_Click(object sender, EventArgs e)
        {
            if (Hodnoty.ZistiBolaSpustena() == false)
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Hodnoty.NastavMiestoUlozenie(saveFileDialog1.FileName);
                }
            else
                {
                    MessageBox.Show("Simulácia už prebieha, teda nie je možné vybrať miesto uloženie zápisu behu simulácie.");
                }
        }

        //nastavenie rychlosti simulacie
        private void nastavenieRychlostiNum_ValueChanged(object sender, EventArgs e)
        {
            if (Hodnoty.ZistiBolaSpustena())
                MessageBox.Show("Simulacia uz je spustena, nie je mozne menit jej rychlost.");
            else
                Hodnoty.NastavRychlostSimulacie((int)nastavenieRychlostiNum.Value);
        }
    }
}






