using CodEx;
using SimulaciaMraveniskaHlasky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//samotna simulacia mraveniska a ziskavanie vstupnych a vystupnych dat
namespace SimulaciaMraveniskaSimulacia
{
    //stara sa o nacitanie hodnot od uzivatela, ako je rozmer mravniska, pocet mravcov,...
    //len konzolova verzia
    static class NacitavaciaTrieda
    {
        static Reader nacitavac = Reader.Console();

        public static void NacitajRozmerMraveniska()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadavanieRozmeruMraveniska();

            int rozmer;
            nacitavac.Int(out rozmer);

            ZadaneHodnoty.NastavRozmerMraveniska(rozmer);
        }
        public static void NacitajPoctyMravcov()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadavaniePoctuMravcov();

            int pocetMravcovTypu1, pocetMravcovTypu2;
            int pocetMravcovTypu3, pocetMravcovTypu4;

            nacitavac.Int(out pocetMravcovTypu1);
            nacitavac.Int(out pocetMravcovTypu2);
            nacitavac.Int(out pocetMravcovTypu3);
            nacitavac.Int(out pocetMravcovTypu4);

            ZadaneHodnoty.NastavPocetMravcovTypu1(pocetMravcovTypu1);
            ZadaneHodnoty.NastavPocetMravcovTypu2(pocetMravcovTypu2);
            ZadaneHodnoty.NastavPocetMravcovTypu3(pocetMravcovTypu3);
            ZadaneHodnoty.NastavPocetMravcovTypu4(pocetMravcovTypu4);
        }
        public static void NacitajPocetSkal()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadajtePocetSkal();
            HlaskyPriNacitavaniHodnotRozhodnuti.RozsahHodnoty(0,
                ZadaneHodnoty.ZistiRozmerMraveniska() * ZadaneHodnoty.ZistiRozmerMraveniska() - 4);

            int pocetSkal;
            nacitavac.Int(out pocetSkal);

            ZadaneHodnoty.NastavPocetSkal(pocetSkal);
        }
        public static void NacitajInfoMnozstvaPotravy()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadavaniePoctuStartovnejPotravy();
            HlaskyPriNacitavaniHodnotRozhodnuti.RozsahHodnoty(0, ZadaneHodnoty.ZistiRozmerMraveniska() *
                                                             ZadaneHodnoty.ZistiRozmerMraveniska() -
                                                             ZadaneHodnoty.ZistiPocetSkal() *
                                                             ZadaneHodnoty.ZistiPocetSkal());
       
            int zaciatocneMnozstvoPotravy;
            int minimalneMnozstvoPotravy;

            nacitavac.Int(out zaciatocneMnozstvoPotravy);
            nacitavac.Int(out minimalneMnozstvoPotravy);

            ZadaneHodnoty.NastavMnozstvoPotravy(zaciatocneMnozstvoPotravy);
            ZadaneHodnoty.NastavMinimalneMnozstvoPotravy(minimalneMnozstvoPotravy);
        }
        public static void SpustiNacitanie()
        {
            NacitajRozmerMraveniska();
            NacitajPocetSkal();
            NacitajInfoMnozstvaPotravy();
            NacitajPoctyMravcov();
        }

    }
}
