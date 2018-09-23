using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//samotna simulacia mraveniska a ziskavanie vstupnych a vystupnych dat
namespace SimulaciaMraveniskaSimulacia
{
    //trieda, ktora reprezentuje udaje, ktore su vypisovanie ako statisticke udaje, alebo ako udaje
    //v GUI v casti "Simulacia"
    public class VypisovacieUdaje
    {
        int pocetMravcovTypu1;
        int pocetMravcovTypu1Celkovo;
        int pocetMravcovTypu2;
        int pocetMravcovTypu2Celkovo;
        int pocetMravcovTypu3;
        int pocetMravcovTypu3Celkovo;
        int pocetMravcovTypu4;
        int pocetMravcovTypu4Celkovo;

        int mnozstvoPotravy;
        int mnozstvoPotravyCelkovo;
        int cas;

        public void NastavPocetMravcovTypu1(int pocet)
        {
            pocetMravcovTypu1 = pocet;
        }
        public void NastavPocetMravcovTypu1Celkovo(int pocet)
        {
            pocetMravcovTypu1Celkovo = pocet;
        }
        public void NastavPocetMravcovTypu2(int pocet)
        {
            pocetMravcovTypu2 = pocet;
        }
        public void NastavPocetMravcovTypu2Celkovo(int pocet)
        {
            pocetMravcovTypu2Celkovo = pocet;
        }
        public void NastavPocetMravcovTypu3(int pocet)
        {
            pocetMravcovTypu3 = pocet;
        }
        public void NastavPocetMravcovTypu3Celkovo(int pocet)
        {
            pocetMravcovTypu3Celkovo = pocet;
        }
        public void NastavPocetMravcovTypu4(int pocet)
        {
            pocetMravcovTypu4 = pocet;
        }
        public void NastavPocetMravcovTypu4Celkovo(int pocet)
        {
            pocetMravcovTypu4Celkovo = pocet;
        }

        public void NastavMnozstvoPotravy(int pocet)
        {
            mnozstvoPotravy = pocet;
        }
        public void NastavMnozstvoPotravyCelkovo(int pocet)
        {
            mnozstvoPotravyCelkovo = pocet;
        }

        public void NastavCas(int cas)
        {
            this.cas = cas;
        }

        public int ZistiPocetMravcovTypu1()
        {
            return pocetMravcovTypu1;
        }
        public int ZistiPocetMravcovTypu1Celkovo()
        {
            return pocetMravcovTypu1Celkovo;
        }
        public int ZistiPocetMravcovTypu2()
        {
            return pocetMravcovTypu2;
        }
        public int ZistiPocetMravcovTypu2Celkovo()
        {
            return pocetMravcovTypu2Celkovo;
        }
        public int ZistiPocetMravcovTypu3()
        {
            return pocetMravcovTypu3;
        }
        public int ZistiPocetMravcovTypu3Celkovo()
        {
            return pocetMravcovTypu3Celkovo;
        }
        public int ZistiPocetMravcovTypu4()
        {
            return pocetMravcovTypu4;
        }
        public int ZistiPocetMravcovTypu4Celkovo()
        {
            return pocetMravcovTypu4Celkovo;
        }

        public int ZistiMnozstvoPotravy()
        {
            return mnozstvoPotravy;
        }
        public int ZistiMnozstvoPotravyCelkovo()
        {
            return mnozstvoPotravyCelkovo;
        }

        public int ZistiCas()
        {
            return cas;
        }

        public VypisovacieUdaje(int pocet1, int pocet1Celkovo, int pocet2, int pocet2Celkovo,
                                int pocet3, int pocet3Celkovo, int pocet4, int pocet4Celkovo,
                                int mnozstvoPotravy, int mnozstvoPotravycelkovo, int cas)
        {
            NastavPocetMravcovTypu1(pocet1);
            NastavPocetMravcovTypu1Celkovo(pocet1Celkovo);
            NastavPocetMravcovTypu2(pocet2);
            NastavPocetMravcovTypu2Celkovo(pocet2Celkovo);
            NastavPocetMravcovTypu3(pocet3);
            NastavPocetMravcovTypu3Celkovo(pocet3Celkovo);
            NastavPocetMravcovTypu4(pocet4);
            NastavPocetMravcovTypu4Celkovo(pocet4Celkovo);
            NastavMnozstvoPotravy(mnozstvoPotravy);
            NastavMnozstvoPotravyCelkovo(mnozstvoPotravycelkovo);
            NastavCas(cas);
        }
    }
}
