using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
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
                        if (!NastavCinnostPozicia(i, j, strategiaMravca, (HodnotyStavuSimulacie.ZistiKonanie())[i, j]))
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
}
