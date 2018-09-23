using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
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
                    numericUpDownMnozstvoPotravyMin.Value = numericUpDownMnozstvoPotravy.Value;
                    NastavMnozstvoPotravyMinimalnejVnutro((int)numericUpDownMnozstvoPotravyMin.Value);

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
}
