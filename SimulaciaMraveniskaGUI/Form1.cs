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
using System.Threading;

//zmen strategiu mravcov 
//ukoncenie simulacie

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
            InicializaciaNastaveniHodnot();

            OdkazNaFormu.NastavFormu(this);
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

        //spravuje nastavenie strategie mravcov, resp. sposobi ich nastavenie
        private void nastavNastavenMravca_Click(object sender, EventArgs e)
        {
            SpravaStrategiaMravcov.Nastav(vyberTypuMravca, pocetMravcovTypu3Nastavenia, pocetMravcovTypu4Nastavenia);
        }

        //inicializacia niektorych nastaveni a hodnot v casti NacitaneHodnoty, v sucasnom stave, nastavuje ako
        //pociatocny rozmer mraveniska na 8x8
        private void InicializaciaNastaveniHodnot()
        {
            velkostMraveniskaNastavenia.SetSelected(0, true);

            NacitaneHodnoty.NastavRozmerMraveniska(8, pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia,
                                                    minimalneMnozstvoPotravyNastavenia);

            NacitaneHodnoty.InicializujHodnoty(pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia, minimalneMnozstvoPotravyNastavenia);
            NacitaneHodnoty.InicializujPoctyHodnotMravcov(pocetMravcovTypu1Nastavenia, pocetMravcovTypu2Nastavenia, pocetMravcovTypu3Nastavenia, pocetMravcovTypu4Nastavenia);



        }

        //reakcia na nastavenie zaciatocneho poctu potravi v casti Nastavenia
        private void mnozstvoZaciatocnejPotravyNastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownMnozstvoZaciatocnejPotravy = sender as NumericUpDown;

            NacitaneHodnoty.NastavMnozstvoZaciatocnejPotravy((int)numericUpDownMnozstvoZaciatocnejPotravy.Value, mnozstvoZaciatocnejPotravyNastavenia,
                                                            pocetSkalNastavenia, minimalneMnozstvoPotravyNastavenia);
        }

        //reakcia na nastavenie mnozstav minimalnej potravy v casti Nastavenia
        private void minimalneMnozstvoPotravyNastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownMinimalneMnozstvoPotravy = sender as NumericUpDown;

            NacitaneHodnoty.NastavMnozstvoMinimalnejPotravy((int)numericUpDownMinimalneMnozstvoPotravy.Value, minimalneMnozstvoPotravyNastavenia,
                                                            pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia);
        }

        //reakcia na nastavenie poctu skal v casti Nastavenia
        private void pocetSkalNastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownPocetSkal = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetSkal((int)numericUpDownPocetSkal.Value, pocetSkalNastavenia,
                                            mnozstvoZaciatocnejPotravyNastavenia,
                                            minimalneMnozstvoPotravyNastavenia);
        }

        //reakcia na nastavenie velkosti mraveniska v casti Nastavenia
        private void velkostMraveniskaNastavenia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBoxNastavovanieRozmeruMraveniska = sender as ListBox;

            switch (listBoxNastavovanieRozmeruMraveniska.GetItemText(listBoxNastavovanieRozmeruMraveniska.SelectedItem))
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
            NumericUpDown numericUpDownPocetMravcovTypu1 = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu1((int)numericUpDownPocetMravcovTypu1.Value);
        }

        //reakcia na nastavenie poctu mravcov typu 2 v casti Nastavenia
        private void pocetMravcovTypu2Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownPocetMravcovTypu2 = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu2((int)numericUpDownPocetMravcovTypu2.Value);
        }

        //reakcia na nastavenie poctu mravcov typu 3 v casti Nastavenia
        private void pocetMravcovTypu3Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownPocetMravcovTypu3 = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu3((int)numericUpDownPocetMravcovTypu3.Value);
        }

        //reakcia na nastavenie poctu mravcov  typu 4 v casti Nastavenia
        private void pocetMravcovTypu4Nastavenia_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownPocetMravcovTypu4 = sender as NumericUpDown;

            NacitaneHodnoty.NastavPocetMravcovTypu4((int)numericUpDownPocetMravcovTypu4.Value);
        }

        //reakcia na spustenie simulacie
        private void spustenieSimulacie_Click(object sender, EventArgs e)
        {
            if (!Hodnoty.ZistiBolaSpustena()) Hodnoty.NastavBolasSpustena();
            else MessageBox.Show("Simulacia uz je spustena.");
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
            if (!Hodnoty.ZistiBolaUkoncena())
            {
                InicializaciaNastaveniHodnot();


                Hodnoty.NastavBolaUkoncena(pocetMravcovTypu1Nastavenia,
                             pocetMravcovTypu2Nastavenia,
                             pocetMravcovTypu3Nastavenia,
                             pocetMravcovTypu4Nastavenia,
                             pocetSkalNastavenia,
                             mnozstvoZaciatocnejPotravyNastavenia,
                             minimalneMnozstvoPotravyNastavenia);

                VypisovacieUdaje vypisovacieUdaje = new VypisovacieUdaje(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                HodnotyNaVypisovanie.NacitajUdaje(vypisovacieUdaje);
                HodnotyNaVypisovanie.VypisUdaje(dobaSimulacia, pocetMravcovTypu1TerazSimulacia, pocetMravcovTypu1CelkovoSimulacia, pocetMravcovTypu2TerazSimulacia,
                                                pocetMravcovTypu2CelkovoSimulacia, pocetMravcovTypu3TerazSimulacia, pocetMravcovTypu3CelkovoSimulacia,
                                                pocetMravcovTypu4TerazSimulacia, pocetMravcovTypu4CelkovoSimulacia, mnoztvoPotravyTerazSimulacia,
                                                mnozstvoPotravyCelkovoSimulacia);
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


        //prvky reprezentuju ci bol v casti Nastavenie nastavene: pocet skal,
        //mnozstvo potravy zaciatocnej alebo minimalnej
        public enum Nastaveny
        {
            skaly,
            zaciatocnaPotrava,
            minimalnaPotrava
        }

        public static class StatickeHodnoty
        {
            private static BehSimulacie behSimulacieSimulacia;

            private static Mravenisko mravenisko;

            private static AutoResetEvent autoReset = new AutoResetEvent(false);

            public static void NastavBehSimulacieSimulacia(BehSimulacie behSimulacie)
            {
                behSimulacieSimulacia = behSimulacie;
            }
            public static void NastavMravenisko(Mravenisko mraveniskoNastav)
            {
                mravenisko = mraveniskoNastav;
            }
            public static void NastavAutoResetEvent(AutoResetEvent autoResetEvent)
            {
                autoReset = autoResetEvent;
            }

            public static BehSimulacie ZistiBehSimulacieSimulacia()
            {
                return behSimulacieSimulacia;
            }
            public static Mravenisko ZistiMravenisko()
            {
                return mravenisko;
            }
            public static AutoResetEvent ZistiAutoResetEvent()
            {
                return autoReset;
            }
        }

        public static class VypisFazeMraveniska
        {
            public static void VypisFazeMraveniskaUvod(Mravenisko mravenisko, Label labelCas, Label labelFaza)
            {
                labelCas.Text = mravenisko.ZistiCasMraveniska().ToString();

                VypisFazeMraveniskaRozhod(mravenisko, labelFaza);
            }

            private static void VypisFazeMraveniskaRozhod(Mravenisko mravenisko, Label labelFaza)
            {
                switch (mravenisko.ZistiFazaMraveniska())
                {
                    case FazaMraveniska.poBojiPolicku: labelFaza.Text = "Boje na polickach."; break;
                    case FazaMraveniska.poBojiPrechadzani: labelFaza.Text = "Boje pri prechadzani."; break;
                    case FazaMraveniska.poKonciKroku: labelFaza.Text = "Koniec kroku simulacie."; break;
                    case FazaMraveniska.poPareni: labelFaza.Text = "Parenie."; break;
                }
            }
        }

        //spravuje graficke zobrazovanie mraveniska
        public static class GrafickyVystup
        {            
            //spusti vykreslovanie mraveniska
            public static void VykresliMraveniskoUvod(Mravenisko mravenisko, TabPage tabPage)
            {
                Graphics graphics;

                graphics = tabPage.CreateGraphics();
                

                VykresliMravenisko(mravenisko, graphics, tabPage);

            }

            //zacne vykreslovanie mraveniska
            private static void VykresliMravenisko(Mravenisko mravenisko, Graphics graphics, TabPage tabPage)
            {

                int vyska;
                int sirka;
                int velkostStvorceka;


                vyska = tabPage.Height;
                sirka = tabPage.Width;

                velkostStvorceka = Math.Min(vyska / mravenisko.ZistiRozmerMraveniska(), sirka / mravenisko.ZistiRozmerMraveniska());

                for (int i = 0;i < mravenisko.ZistiRozmerMraveniska(); i++)
                    for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    {
                        switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)).ZistiTypObjektu())
                        {
                            case TypyObjektov.potrava:
                                {
                                    VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.LawnGreen, graphics);

                                    if(mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i,j)).Count > 0)
                                    
                                        RozhodovanieOVyfarbovaniMravcov(mravenisko, graphics, i, j, velkostStvorceka);
                                    
                                }
                                break;
                            case TypyObjektov.prazdnaZem:
                                {
                                    VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                                            Color.Khaki, graphics);

                                    if(mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i,j)).Count > 0)

                                        RozhodovanieOVyfarbovaniMravcov(mravenisko, graphics, i, j, velkostStvorceka);
                                    

                                }
                                break;
                            case TypyObjektov.skala:
                                {
                                    VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                                                Color.Gray, graphics);

                                }
                                break;
                        }
                    }

                if (mravenisko.ZistiFazaMraveniska() == FazaMraveniska.poBojiPrechadzani)
                    for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                        for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                            VyfarbenieBojPriPrechadzaniSpojnice(mravenisko, graphics, i, j, velkostStvorceka);
            }

            
            // rozhoduje sa o tom ako, ake vykreslovanie mravcov sa bude diat, podla typu fazy vykreslovania
            public static void RozhodovanieOVyfarbovaniMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
            {
                switch (mravenisko.ZistiFazaMraveniska())
                {
                    case FazaMraveniska.poKonciKroku: VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2); break;
                    case FazaMraveniska.poBojiPrechadzani:
                        {
                            VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2);
                            VyfarbenieBojPriPrechadzaniPolicko(mravenisko, i, j, graphics, velkostStvorceka);
                        }
                        break;
                    case FazaMraveniska.poBojiPolicku: {VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2) ;
                            VyfarbenieMravcovBojNaPolickach(mravenisko, graphics, i, j, velkostStvorceka);} break;
                    case FazaMraveniska.poPareni: {
                            VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2);
                            VyfarbenieMravcovParenie(mravenisko, graphics, i, j, velkostStvorceka); } break;
                }
            }

            //zisti farbu mravcov podla typu
            private static Color ZistiFarbuMravcov(TypyMravcov typyMravcov)
            {
                switch (typyMravcov)
                {
                    case TypyMravcov.MravecTypu1:return Color.Blue;
                    case TypyMravcov.MravecTypu2:return Color.Orange;
                    case TypyMravcov.MravecTypu3:return Color.Pink;
                    case TypyMravcov.MravecTypu4:return Color.LimeGreen;
                }

                return default(Color);
            }

            //zisti pritomnost daneho typu mravcov v poli, ktore obsahuje typy mr
            private static bool ZistiPritomnostMravcovDanehoTypu(TypyMravcov typyMravcov, List<TypyMravcov> typyMravcovs)
            {
                foreach (TypyMravcov typMravca in typyMravcovs) if (typMravca == typyMravcov) return true;

                return false;
            }

            //nastavi ako sa maju vykreslit mravce v zakladnej podobe
            private static void VyfarbenieMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka, int velkostCast)
            {

                Color farba = ZistiFarbuMravcov((mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j))[0] as Mravec).ZistiTypyMravcov());

                     VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka
                                       , velkostStvorceka / velkostCast,
                                      velkostStvorceka, farba,
                                       graphics);

            }

            private static void VyfarbenieBojPriPrechadzaniPolicko(Mravenisko mravenisko, int i, int j, Graphics graphics, int velkostStvorceka)
            {
                if (mravenisko.ZistiPolickBojPrechadzajuce(i, j) != default(List<PolickaPriPrechadzajucomBoji>) && mravenisko.ZistiPolickBojPrechadzajuce(i, j).Count
                    > 0)
                    foreach (PolickaPriPrechadzajucomBoji polickoPrechadzajuce in mravenisko.ZistiPolickBojPrechadzajuce(i, j))
                    {
                        VykresliObdlznik(polickoPrechadzajuce.ZistiSuradniceMravcov().ZistiXSuradnicu() * velkostStvorceka,
                            polickoPrechadzajuce.ZistiSuradniceMravcov().ZistiYSuradnicu() * velkostStvorceka,
                            velkostStvorceka, velkostStvorceka, Color.Red, graphics);

                        VykresliObdlznik(polickoPrechadzajuce.ZistiDruhePolicko().ZistiSuradniceMravcov().ZistiXSuradnicu() * velkostStvorceka,
                            polickoPrechadzajuce.ZistiDruhePolicko().ZistiSuradniceMravcov().ZistiYSuradnicu() * velkostStvorceka, velkostStvorceka,
                            velkostStvorceka, Color.Red, graphics);
                    }
            }

            //vykresli 2 spojnice spajajuce policka, tieto ciary reprezentuju boj mravcov pri prechadzani medzi tymito polickami, farby ciar reprezentuju typy mravcov, ktore bojuju
            //takisto vykresli
            private static void VyfarbenieBojPriPrechadzaniSpojnice(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
            {
                if (mravenisko.ZistiPolickBojPrechadzajuce(i, j) != default(List<PolickaPriPrechadzajucomBoji>) && mravenisko.ZistiPolickBojPrechadzajuce(i, j).Count > 0)
                {

                    foreach (PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji1 in mravenisko.ZistiPolickBojPrechadzajuce(i, j))
                    {
                        PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji2 = polickaPriPrechadzajucomBoji1.ZistiDruhePolicko();

                        Suradnice suradnice1 = polickaPriPrechadzajucomBoji1.ZistiSuradniceMravcov();
                        Suradnice suradnice2 = polickaPriPrechadzajucomBoji2.ZistiSuradniceMravcov();

                        Pen pen1 = new Pen(ZistiFarbuMravcov(polickaPriPrechadzajucomBoji1.ZistiTypMravcov()), 3);
                        Pen pen2 = new Pen(ZistiFarbuMravcov(polickaPriPrechadzajucomBoji2.ZistiTypMravcov()), 3);

                        if (NasledujucePolickoMraveniska.SmerJ(suradnice1, mravenisko.ZistiRozmerMraveniska()) == suradnice2)
                        {
                            if (Math.Abs(suradnice1.ZistiYSuradnicu() - suradnice2.ZistiYSuradnicu()) == 1)
                            {
                                VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2,
                                                    velkostStvorceka / 2);

                                VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2 + 3,
                                                 velkostStvorceka / 2);
                            }
                            else
                            {
                                VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice1.ZistiXSuradnicu() * velkostStvorceka , suradnice1.ZistiYSuradnicu() * velkostStvorceka + velkostStvorceka/2
                                                , graphics, velkostStvorceka / 2,
                                                    velkostStvorceka / 2);

                                VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka + velkostStvorceka/2, 
                                                graphics, velkostStvorceka / 2 + 3,
                                                 velkostStvorceka / 2);

                                VykresliCiaru(pen1, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka - velkostStvorceka/2,
                                                graphics, velkostStvorceka / 2,
                                                    velkostStvorceka / 2);

                                VykresliCiaru(pen2, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka - velkostStvorceka/2, 
                                                graphics, velkostStvorceka / 2 + 3,
                                                 velkostStvorceka / 2);
                            }

                        }
                        else
                        {
                          if(Math.Abs(suradnice1.ZistiXSuradnicu() - suradnice2.ZistiXSuradnicu()) == 1){
                                VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2,
                                                velkostStvorceka / 2);

                                VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka, suradnice2.ZistiXSuradnicu()
                                    * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);
                            }
                            else
                            {
                                VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice1.ZistiXSuradnicu() * velkostStvorceka + velkostStvorceka/2, suradnice1.ZistiYSuradnicu() * velkostStvorceka, 
                                                graphics, velkostStvorceka / 2,
                                                velkostStvorceka / 2);

                                VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka, 
                                    suradnice1.ZistiXSuradnicu()* velkostStvorceka + velkostStvorceka/2, 
                                    suradnice1.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);

                                VykresliCiaru(pen1, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                                suradnice2.ZistiXSuradnicu() * velkostStvorceka - velkostStvorceka/2, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, 
                                                velkostStvorceka / 2,
                                                velkostStvorceka / 2);

                                VykresliCiaru(pen2, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, 
                                    suradnice2.ZistiXSuradnicu() - velkostStvorceka/2
                                    * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);

                            }
                        }

                    }
                }
                
            }

            //vykresli policka, kde mravce bojuju na danom policku
            private static void VyfarbenieMravcovBojNaPolickach(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
            {
                PolickaPriBojiNaPolicku polickaPriBojiNaPolicku = mravenisko.ZistiPolickoBojNaPolicko(i, j);
                List<TypyMravcov> typyMravcovPole;

                if(polickaPriBojiNaPolicku != default(PolickaPriBojiNaPolicku)) {

                typyMravcovPole = polickaPriBojiNaPolicku.ZistiTypyMravcovPole();

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu1, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka,
                                                                                velkostStvorceka / 2, velkostStvorceka / 2,
                                                                                                     ZistiFarbuMravcov(TypyMravcov.MravecTypu1), graphics);
                else VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2, Color.White, graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu2, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                    j * velkostStvorceka, velkostStvorceka / 2,
                                                                                                                    velkostStvorceka / 2, ZistiFarbuMravcov(TypyMravcov.MravecTypu2),
                                                                                                                    graphics);
                else VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2, Color.White,
                                        graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu3, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                   velkostStvorceka / 2, velkostStvorceka / 2,
                                                                                                                   ZistiFarbuMravcov(TypyMravcov.MravecTypu3), graphics);
                else VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka  + velkostStvorceka / 2, velkostStvorceka / 2, velkostStvorceka / 2, Color.White, graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu4, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                    j * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                    velkostStvorceka / 2, velkostStvorceka / 2,
                                                                                                                    ZistiFarbuMravcov(TypyMravcov.MravecTypu4), graphics);
                else VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka + velkostStvorceka / 2, velkostStvorceka / 2, velkostStvorceka / 2,
                    Color.White, graphics);
                }
                 
                
            }

            //vykresli policka, kde prebieha parenie
            private static void VyfarbenieMravcovParenie(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
            {
                if (mravenisko.ZistiParenie(i, j))
                {
                    VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.White, graphics);

                    VykresliElipsu(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                        (ZistiFarbuMravcov((mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j))[0] as Mravec).ZistiTypyMravcov())), graphics);
                }
                 
            }

            //vykresli samotne policko, obldznik
            private static void VykresliObdlznik(int x, int y, int sirka, int vyska, Color farba, Graphics graphics)
            {
                Pen pen = new Pen(Color.Black,2);

                SolidBrush solidBrush = new SolidBrush(farba);


                graphics.DrawRectangle(pen, x, y, sirka, vyska);
                graphics.FillRectangle(solidBrush, x, y, sirka, vyska);

            }

            //vykresli samotne policko, obdlznik
            private static void VykresliElipsu(int x, int y, int sirka, int vyska, Color farba, Graphics graphics)
            {
                Pen pen = new Pen(Color.Black, 2);

                SolidBrush solidBrush = new SolidBrush(farba);

                graphics.DrawEllipse(pen, x, y, sirka, vyska);
                graphics.FillEllipse(solidBrush, x , y , sirka , vyska);
            }

            //vykresli ciaru s pripadnym posunutim
            private static void VykresliCiaru(Pen pen, int x1, int y1, int x2, int y2, Graphics graphics, int posunX, int posunY)
            {
                graphics.DrawLine(pen, x1 + posunX, y1 + posunY, x2 + posunX, y2 + posunY);
            }
        }

        //odkaz na prave beziacu windows form
        public static class OdkazNaFormu
        {
            private static Form1 MainForm;

            public static void NastavFormu(Form1 form1)
            {
                MainForm = form1;
            }

            public static Form1 ZistiOdkazNaFormu()
            {
                return MainForm;
            }
        }

        //hodnoty reprezentujuce stav simulacie nastavovanej v casti Simulacia
        public static class Hodnoty
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
            public static void NastavBolaUkoncena( NumericUpDown pocetMravcovTypu1, //spravuje 
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

        //spravuje beh simulacie podla prikazov z uzivatelskeho rozhrania
        public static class SpravaBehuGUI
        {

            //spravuje spustenie simulacie
            public static void SimulaciaBolaSpustena()
            {
                NastavHodnotySimulacie();

                StatickeHodnoty.NastavBehSimulacieSimulacia(new BehSimulacie());
                StatickeHodnoty.ZistiBehSimulacieSimulacia().InicializujSimulaciu(Hodnoty.ZistiMiestoUlozenia());

                VykreslovanieASpustenieBehuSimulacie();
            }

            private static void NastavHodnotySimulacie()
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
            }

            private static void VykreslovanieASpustenieBehuSimulacie()
            {
                Form1 form1;
                form1 = OdkazNaFormu.ZistiOdkazNaFormu();
                form1.backgroundWorker1.RunWorkerAsync();

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

                VykreslovanieASpustenieBehuSimulacie();
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

                StatickeHodnoty.ZistiBehSimulacieSimulacia().UkonecieSimulacie();
                StatickeHodnoty.ZistiBehSimulacieSimulacia().InicializujSimulaciu("");



                NacitaneHodnoty.InicializujPoctyHodnotMravcov(pocetMravcovTypu1, pocetMravcovTypu2, pocetMravcovTypu3,
                                                                poceMravcovTypu4);
                NacitaneHodnoty.InicializujHodnoty(pocetSkal, mnozstvoPotravyZaciatocnej, mnozstvoPotravyMinnimalnej);

                if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.Close(); 
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
                    vypisovacieUdaje = StatickeHodnoty.ZistiBehSimulacieSimulacia().ZistiUdaje();
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
                numericUpDown.Maximum = 200;
            }

            //aktualizuje medze mravca typu 4, pokial bola nastavena jeho strategia
            public static void AktualizujPocetMravcovTypu4(NumericUpDown numericUpDown)
            {
                numericUpDown.Maximum = 200;
            }

            //inicializuje niektore hodnoty
            public static void InicializujHodnoty(NumericUpDown numUpDownPocetSkal, NumericUpDown numUpDownMnozstvoPotravy,
                                                        NumericUpDown numUpDownMnozstvoPotravyMinimum)
            {
                numUpDownPocetSkal.Minimum = 0;
                numUpDownMnozstvoPotravy.Minimum = 0;
                numUpDownMnozstvoPotravyMinimum.Minimum = 0;

                numUpDownPocetSkal.Value = 0;
                numUpDownMnozstvoPotravyMinimum.Value = 0;
                numUpDownMnozstvoPotravy.Value = 0;

                numUpDownMnozstvoPotravyMinimum.Maximum = 0;
                numUpDownPocetSkal.Maximum = rozmer * rozmer - 4;
                numUpDownMnozstvoPotravy.Maximum = rozmer * rozmer - (int)numUpDownPocetSkal.Value;

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

            //nastavi medze pre hodnoty pocet skal, mnozstvo potravy a mnozstvo potravy minimalnej; pripadne i ich nastavi
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
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - (4 - numericUpDownMnozstvoPotravy.Value);
                }
                else if (nastaveny == Nastaveny.zaciatocnaPotrava)
                {
                    numericUpDownMnozstvoPotravy.Maximum = rozmer * rozmer - numericUpDownPocetSkal.Value;
                    if (numericUpDownMnozstvoPotravy.Value >= 4)
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - numericUpDownMnozstvoPotravy.Value;
                    else
                        numericUpDownPocetSkal.Maximum = rozmer * rozmer - (4 - numericUpDownMnozstvoPotravy.Value);

                    if (numericUpDownMnozstvoPotravyMin.Value > numericUpDownMnozstvoPotravy.Value)
                    {
                        numericUpDownMnozstvoPotravyMin.Value = numericUpDownMnozstvoPotravy.Value;
                        NastavMnozstvoPotravyMinimalnejVnutro((int)numericUpDownMnozstvoPotravyMin.Value);
                    }

                    numericUpDownMnozstvoPotravyMin.Maximum = numericUpDownMnozstvoPotravy.Value;
                }
            }

            //nastavy medze pre hodnoty pocet skal, mnnozstvo potravy a mnozstvo potravy minimalnej; pripadne ich i nastavi
            private static void NastavHodnotyVzhladomRozmer(NumericUpDown numericUpDownPocetSkal,
                                                            NumericUpDown numericUpDownMnozstvoPotravyZaciatocnej,
                                                            NumericUpDown numericUpDownMnozstvoPotravyMin)
            {

                if (numericUpDownPocetSkal.Value > rozmer * rozmer - 4)
                {
                    numericUpDownPocetSkal.Value = rozmer * rozmer - 4;

                    NastavPocetSkalVnutro((int)numericUpDownPocetSkal.Value);
                }

                numericUpDownPocetSkal.Maximum = rozmer * rozmer - 4;

                if (numericUpDownMnozstvoPotravyZaciatocnej.Value > rozmer * rozmer - (int)numericUpDownPocetSkal.Value)
                {
                    numericUpDownMnozstvoPotravyZaciatocnej.Value = rozmer * rozmer - (int)numericUpDownPocetSkal.Value;

                    NastavMnozstvoPotravyZaciatocnejVnutro((int)numericUpDownMnozstvoPotravyZaciatocnej.Value);
                }

                numericUpDownMnozstvoPotravyZaciatocnej.Maximum = rozmer * rozmer - (int)numericUpDownPocetSkal.Value;

                if (numericUpDownMnozstvoPotravyMin.Value > numericUpDownMnozstvoPotravyZaciatocnej.Value)
                {
                    numericUpDownMnozstvoPotravyMin.Value = numericUpDownMnozstvoPotravyZaciatocnej.Value;

                    NastavMnozstvoPotravyMinimalnejVnutro((int)numericUpDownMnozstvoPotravyMin.Value);
                }

                numericUpDownMnozstvoPotravyMin.Maximum = numericUpDownMnozstvoPotravyZaciatocnej.Value;
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
            public static void NastavNastavenyTyp3(bool nastavenie)
            {
                nastavenyTyp3 = nastavenie;
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
            public static void Nastav(ListView vyber, NumericUpDown numericUpDownPocetMravcovTypu3, NumericUpDown numericUpDownPocetMravcovTypu4)
            {
                if (vyber.SelectedItems.Count > 0)
                {
                    if (vyber.SelectedItems[0].Text == "mravec typu 3") NastavTypyMravcov(TypyMravcov.MravecTypu3);
                    else NastavTypyMravcov(TypyMravcov.MravecTypu4);

                    strategiaMravca = new CinnostiMravcov[4, 7];

                    bool hodnotaUspech = true;

                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 7; j++)
                            if (!NastavCinnostPozicia(i, j, strategiaMravca, (Hodnoty.ZistiKonanie())[i, j]))
                                hodnotaUspech = false;

                    if (hodnotaUspech) NastavCinnostMravca(typyMravcov, strategiaMravca, numericUpDownPocetMravcovTypu3, numericUpDownPocetMravcovTypu4);

                }
                else
                {
                    MessageBox.Show("Nevybrali ste typ mravca, pre ktorého sa má nastavit daná stratégia");
                }
            }

            //nastavi cinnost mravca vzhladom k danej situacii
            private static bool NastavCinnostPozicia(int i, int j, CinnostiMravcov[,] cinnostiMravcovStrategia, ListBox listBoxNastavenaStrategia)
            {
                if (listBoxNastavenaStrategia.SelectedItems.Count == 0) { MessageBox.Show("Nevybrali ste pre mravca konanie vo všetkých situáciách."); return false; }
                else
                    switch (listBoxNastavenaStrategia.GetItemText(listBoxNastavenaStrategia.SelectedItem))
                    {
                        case "zostaň stáť": cinnostiMravcovStrategia[i, j] = CinnostiMravcov.zostan; break;
                        case "otoč sa vľavo": cinnostiMravcovStrategia[i, j] = CinnostiMravcov.otocSaVlavo; break;
                        case "choď dopredu obranne": cinnostiMravcovStrategia[i, j] = CinnostiMravcov.chodDopreduObrana; break;
                        case "choď dopredu útočne": cinnostiMravcovStrategia[i, j] = CinnostiMravcov.chodDopreduUtok; break;
                        case "najedz sa": cinnostiMravcovStrategia[i, j] = CinnostiMravcov.najedzSa; break;
                        case "rozmnožuj sa": cinnostiMravcovStrategia[i, j] = CinnostiMravcov.paritSa; break;
                    }

                return true;
            }

            //nastavi strategiu mravca, taktisto nastavy, ze pocet mravcov typu 3 alebo 4 moze byt rozny od 0
            private static void NastavCinnostMravca(TypyMravcov typyMravcov, CinnostiMravcov[,] cinnostiMravcov,
                NumericUpDown numericUpDownPocetMravcovTypu3, NumericUpDown numericUpDownPocetMravcovTypu4)
            {
                switch (typyMravcov)
                {
                    case TypyMravcov.MravecTypu3:
                        Konstanty.NastavStrategiuMravceTypu3(cinnostiMravcov); NastavNastavenyTyp3(true);
                        NacitaneHodnoty.AktualizujPocetMravcovTypu3(numericUpDownPocetMravcovTypu3); break;
                    case TypyMravcov.MravecTypu4:
                        Konstanty.NastavStrategiuMravceTypu4(cinnostiMravcov); NastavNastavenyTyp4(true);
                        NacitaneHodnoty.AktualizujPocetMravcovTypu4(numericUpDownPocetMravcovTypu4); break;
                }
            }
        }
        

        //pokial uzivatel nastavi nastavenia v casti "Nastavenia"
        //tak tato funkcia zabezpeci nastavenie hodnoty "nastavenieNastavenia" v casti NacitaneHodnoty
        private void nastavNastavenia_Click(object sender, EventArgs e)
        {
            NacitaneHodnoty.NastavNastavenia(true);
        }

        //ulozi miesta, kam sa má výpis simulácie ulozit
        private void ukladanieSimulacie_Click(object sender, EventArgs e)
        {
            if (Hodnoty.ZistiBolaSpustena() == false)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    Hodnoty.NastavMiestoUlozenie(saveFileDialog1.FileName);
            }
            else

                MessageBox.Show("Simulácia už prebieha, teda nie je možné vybrať miesto uloženie zápisu behu simulácie.");
           
        }

        //nastavenie rychlosti simulacie
        private void nastavenieRychlostiNum_ValueChanged(object sender, EventArgs e)
        {
            if (Hodnoty.ZistiBolaSpustena())
                MessageBox.Show("Simulacia uz je spustena, nie je mozne menit jej rychlost.");
            else
                Hodnoty.NastavRychlostSimulacie((int)nastavenieRychlostiNum.Value);
        }

        //spustenie vypoctu simulacie pomocou backgroundworker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            while (Hodnoty.ZistiBolaSpustena() && !Hodnoty.ZistiBolaZastavena())
            {
                StatickeHodnoty.ZistiBehSimulacieSimulacia().SpustiSimulaciu();
                if(StatickeHodnoty.ZistiBehSimulacieSimulacia().ZistiDobaBehu() == 0) Thread.Sleep(2000);
                backgroundWorker1.ReportProgress(1);
                StatickeHodnoty.ZistiAutoResetEvent().WaitOne();
                Thread.Sleep(Konstanty.ZistiVyslednuDobuPrestavku());
            }

                
        }

        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TabPage tabPage = Simulacia.TabPages[1];
            StatickeHodnoty.NastavMravenisko(StatickeHodnoty.ZistiBehSimulacieSimulacia().ZistiMravenisko());

            GrafickyVystup.VykresliMraveniskoUvod(StatickeHodnoty.ZistiMravenisko(), tabPage);
            VypisFazeMraveniska.VypisFazeMraveniskaUvod(StatickeHodnoty.ZistiMravenisko(), casLabelVystup, fazaLabelVystup);

            StatickeHodnoty.ZistiAutoResetEvent().Set();
        }
    }
}






