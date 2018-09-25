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

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
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

            HodnotyStavuSimulacie.NastavKonanie(listBoxes);
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
            if (!HodnotyStavuSimulacie.ZistiBolaSpustena()) HodnotyStavuSimulacie.NastavBolasSpustena();
            else MessageBox.Show("Simulacia uz je spustena.");
        }
        //reakcia na zastavenie, resp. pokracovanie, simulacie
        private void zastaveniePokracovanieSimulacie_Click(object sender, EventArgs e)
        {
            if (HodnotyStavuSimulacie.ZistiBolaSpustena())
            {
                if (!HodnotyStavuSimulacie.ZistiBolaZastavena())
                {
                    HodnotyStavuSimulacie.NastavBolaZastavenaPokracuje(true);
                    zastaveniePokracovanieSimulacie.Text = "Pokracovanie simulacie";
                }
                else
                {
                    HodnotyStavuSimulacie.NastavBolaZastavenaPokracuje(false);
                    zastaveniePokracovanieSimulacie.Text = "Zastavenie simulacie";
                }
            }
            else
                MessageBox.Show("Nema zmysel.");
        }
        //reakcia na skoncenie simulacie
        private void skoncenieSimulacie_Click(object sender, EventArgs e)
        {
            if (!HodnotyStavuSimulacie.ZistiBolaUkoncena())
            {

                HodnotyStavuSimulacie.NastavBolaUkoncena(pocetMravcovTypu1Nastavenia,
                             pocetMravcovTypu2Nastavenia,
                             pocetMravcovTypu3Nastavenia,
                             pocetMravcovTypu4Nastavenia,
                             pocetSkalNastavenia,
                             mnozstvoZaciatocnejPotravyNastavenia,
                             minimalneMnozstvoPotravyNastavenia, casLabelVystup, fazaLabelVystup);

                InicializaciaNastaveniHodnot();

                HodnotyNaVypisovanie.VypisUdajeZakladne(dobaSimulacia, pocetMravcovTypu1TerazSimulacia,
                                                            pocetMravcovTypu1CelkovoSimulacia, pocetMravcovTypu2TerazSimulacia,
                                                            pocetMravcovTypu2CelkovoSimulacia, pocetMravcovTypu3TerazSimulacia,
                                                            pocetMravcovTypu3CelkovoSimulacia, pocetMravcovTypu4TerazSimulacia,
                                                            pocetMravcovTypu4CelkovoSimulacia, mnoztvoPotravyTerazSimulacia,
                                                            mnozstvoPotravyCelkovoSimulacia);

                GrafickyVystup.VykresliOknoBezSimulacie(vystup);
                zastaveniePokracovanieSimulacie.Text = "Zastavenie Simulácie.";
                HodnotyStavuZobrazovaniaSimulacie.NastavZobrazovanieSimulacie(false);
                zastavenieSpustenieZobrazovaniaButton.Text = "Zastavenie zobrazovania";
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
        //pokial uzivatel nastavi nastavenia v casti "Nastavenia"
        //tak tato funkcia zabezpeci nastavenie hodnoty "nastavenieNastavenia" v casti NacitaneHodnoty
        private void nastavNastavenia_Click(object sender, EventArgs e)
        {
            NacitaneHodnoty.NastavNastavenia(true);
        }
        //ulozi miesta, kam sa má výpis simulácie ulozit
        private void ukladanieSimulacie_Click(object sender, EventArgs e)
        {
            if (HodnotyStavuSimulacie.ZistiBolaSpustena() == false)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    HodnotyStavuSimulacie.NastavMiestoUlozenie(saveFileDialog1.FileName);
            else
                MessageBox.Show("Simulácia už prebieha, teda nie je možné vybrať miesto uloženie zápisu behu simulácie.");
        }
        //nastavenie rychlosti simulacie
        private void nastavenieRychlostiNum_ValueChanged(object sender, EventArgs e)
        {
            if (HodnotyStavuSimulacie.ZistiBolaSpustena())
                MessageBox.Show("Simulacia uz je spustena, nie je mozne menit jej rychlost.");
            else
                HodnotyStavuSimulacie.NastavRychlostSimulacie((int)nastavenieRychlostiNum.Value);
        }
        //zastavi zobrazovanie simulacie, simulacia ale pobezi nadalej
        private void zastavenieSpustenieZobrazovania_Click(object sender, EventArgs e)
        {
            if (HodnotyStavuSimulacie.ZistiBolaSpustena())
            {
                if (HodnotyStavuZobrazovaniaSimulacie.ZistiZobrazovanieSimulacie() == true)
                {
                    HodnotyStavuZobrazovaniaSimulacie.NastavZobrazovanieSimulacie(false);
                    zastavenieSpustenieZobrazovaniaButton.Text = "Spustenie zobrazovania";
                }
                else
                {
                    HodnotyStavuZobrazovaniaSimulacie.NastavZobrazovanieSimulacie(true);
                    zastavenieSpustenieZobrazovaniaButton.Text = "Zastavenie zobrazovania";
                }
            }
            else
                MessageBox.Show("Nema zmysel.");
        }
        //spustenie vypoctu simulacie pomocou backgroundworker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int dlzkaSpanku;

            while (HodnotyStavuSimulacie.ZistiBolaSpustena() && !HodnotyStavuSimulacie.ZistiBolaZastavena())
            {
                dlzkaSpanku = 0;

                StatickeHodnoty.ZistiBehSimulacieSimulacia().SpustiSimulaciu();
                if(StatickeHodnoty.ZistiBehSimulacieSimulacia().ZistiDobaBehu() == 0) Thread.Sleep(2000);
                backgroundWorker1.ReportProgress(1);
                StatickeHodnoty.ZistiAutoResetEvent().WaitOne();

                while(dlzkaSpanku < Konstanty.ZistiVyslednuDobuPrestavku() && 
                    HodnotyStavuSimulacie.ZistiBolaSpustena() && !HodnotyStavuSimulacie.ZistiBolaZastavena())
                {
                    Thread.Sleep(1);
                    dlzkaSpanku++;
                }
            }

                
        }
        //spustenie vykreslovania
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TabPage tabPage = Simulacia.TabPages[1];
            StatickeHodnoty.NastavMravenisko(StatickeHodnoty.ZistiBehSimulacieSimulacia().ZistiMravenisko());

            if (HodnotyStavuZobrazovaniaSimulacie.ZistiZobrazovanieSimulacie())
            {
                GrafickyVystup.VykresliMraveniskoUvod(StatickeHodnoty.ZistiMravenisko(), tabPage);
                VypisFazeMraveniska.VypisFazeMraveniskaUvod(StatickeHodnoty.ZistiMravenisko(), casLabelVystup, fazaLabelVystup);
            }
            

            if (StatickeHodnoty.ZistiMravenisko().ZistiPocetVsetkychMravcov() == 0 && 
                StatickeHodnoty.ZistiMravenisko().ZistiFazaMraveniska() == FazaMraveniska.poKonciKroku)
            {

                InicializaciaNastaveniHodnot();
                HodnotyStavuSimulacie.NastavBolaUkoncena(pocetMravcovTypu1Nastavenia, pocetMravcovTypu2Nastavenia,
                                                            pocetMravcovTypu3Nastavenia, pocetMravcovTypu4Nastavenia,
                                                            pocetSkalNastavenia, mnozstvoZaciatocnejPotravyNastavenia,
                                                            minimalneMnozstvoPotravyNastavenia, casLabelVystup, fazaLabelVystup);
                HodnotyNaVypisovanie.VypisUdajeZakladne(dobaSimulacia, pocetMravcovTypu1TerazSimulacia, pocetMravcovTypu1CelkovoSimulacia,
                                                        pocetMravcovTypu2TerazSimulacia, pocetMravcovTypu2CelkovoSimulacia, 
                                                        pocetMravcovTypu3TerazSimulacia, pocetMravcovTypu3CelkovoSimulacia,
                                                        pocetMravcovTypu4TerazSimulacia, pocetMravcovTypu4CelkovoSimulacia,
                                                        mnoztvoPotravyTerazSimulacia, mnozstvoPotravyCelkovoSimulacia);

                GrafickyVystup.VykresliOknoBezSimulacie(tabPage);
                HodnotyStavuZobrazovaniaSimulacie.NastavZobrazovanieSimulacie(true);
                zastavenieSpustenieZobrazovaniaButton.Text = "Zastavenie zobrazovania";
            }

            StatickeHodnoty.ZistiAutoResetEvent().Set();

        }

    }
}






