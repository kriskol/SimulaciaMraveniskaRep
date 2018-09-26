using SimulaciaMraveniskaObjektyNaMravenisku;
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
    //spravuje beh simulacie podla prikazov z uzivatelskeho rozhrania
    public static class SpravaBehuGUI
    {
        //spravuje spustenie simulacie
        public static void SimulaciaBolaSpustena()
        {
            NastavHodnotySimulacie();

            HodnotyStavuZobrazovaniaSimulacie.NastavZobrazovanieSimulacie(true);

            StatickeHodnoty.NastavBehSimulacieSimulacia(new BehSimulacie());
            StatickeHodnoty.ZistiBehSimulacieSimulacia().InicializujSimulaciu(HodnotyStavuSimulacie.ZistiMiestoUlozenia());

            VykreslovanieASpustenieBehuSimulacie();
        }
        //nastavi prvotne hodnoty simulacie
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

            Konstanty.NastavNasobokDobyPrestavky(HodnotyStavuSimulacie.ZistiRychlostSimulacie());

            GrafickyVystup.Inicializacia(ZadaneHodnoty.ZistiRozmerMraveniska());
        }
        //spusti simulaciu a jej beh pomocou backgroundwoker
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
                                                 NumericUpDown mnozstvoPotravyMinnimalnej, Label labelCas, Label labelFaza)
        {
            StatickeHodnoty.ZistiBehSimulacieSimulacia().UkonecieSimulacie();

            if (Konstanty.jeNastaveneMiestoUlozenia)
                Konstanty.zapisovacUdajov.Close();

            NastaveneHodnotyPocasKrokov.NastavPokracovanie(false);
            NacitaneHodnoty.NastavNastavenia(false);
            HodnotyStavuSimulacie.ResetujMiestoUlozenia();
            HodnotyStavuZobrazovaniaSimulacie.NastavZobrazovanieSimulacie(false);
            StatickeHodnoty.ZistiBehSimulacieSimulacia().InicializujSimulaciu("");



            NacitaneHodnoty.InicializujPoctyHodnotMravcov(pocetMravcovTypu1, pocetMravcovTypu2, pocetMravcovTypu3,
                                                          poceMravcovTypu4);
            NacitaneHodnoty.InicializujHodnoty(pocetSkal, mnozstvoPotravyZaciatocnej, mnozstvoPotravyMinnimalnej);

            VypisFazeMraveniska.NastavZakladneHodnoty(labelCas, labelFaza);
            
        }
        //spravuje vypisovanie udajov v casti Simulacia
        public static void VypisUdaje(Label dobaBehu, Label pocetMravcovTypu1, Label pocetMravcovTypu1Celkovo,
                                      Label pocetMravcovTypu2, Label pocetMravcovTypu2Celkovo,
                                      Label pocetMravcovTypu3, Label pocetMravcovTypu3Celkovo,
                                      Label pocetMravcovTypu4, Label pocetMravcovTypu4Celkovo,
                                      Label mnozsvtoPotrava, Label pocetPotravyCelkovo)
        {
            VypisovacieUdaje vypisovacieUdaje = default(VypisovacieUdaje);

            if (HodnotyStavuSimulacie.ZistiBolaSpustena())
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
}
