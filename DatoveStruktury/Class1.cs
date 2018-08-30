using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatoveStruktury
{
    public class Halda<T>
    {
        private int pocetPrvkov = 0;
        private int velkost = 10;
        private T[] halda = new T[10];

        private int[] polePriorita1 = new int[10];
        private int[] polePriorita2 = new int[10];

        private void Zabublaj(int pozicia)
        {
            int poziciaList1 = 2 * pozicia + 1;
            int poziciaList2 = 2 * pozicia + 2;

            if (poziciaList1 <= pocetPrvkov - 1)
            {
                if (poziciaList2 <= pocetPrvkov - 1)
                {
                    if (polePriorita1[pozicia] > polePriorita1[poziciaList1] || polePriorita1[pozicia] > polePriorita1[poziciaList2])
                    {
                        if (polePriorita1[poziciaList1] > polePriorita1[poziciaList2])
                        {
                            Zamen(pozicia, poziciaList2);
                            Zabublaj(poziciaList2);
                        }
                        else if (polePriorita1[poziciaList1] == polePriorita1[poziciaList2])
                        {
                            if (polePriorita2[poziciaList1] > polePriorita2[poziciaList2])
                            {
                                Zamen(pozicia, poziciaList2);
                                Zabublaj(poziciaList2);
                            }
                            else if (polePriorita2[poziciaList1] == polePriorita2[poziciaList2])
                            {
                                Zamen(pozicia, poziciaList1);
                                Zabublaj(poziciaList1);
                            }
                            else
                            {
                                Zamen(pozicia, poziciaList1);
                                Zabublaj(poziciaList1);
                            }
                        }
                        else
                        {
                            Zamen(pozicia, poziciaList1);
                            Zabublaj(poziciaList1);
                        }
                    }
                    else if (polePriorita1[pozicia] == polePriorita1[poziciaList1] || polePriorita1[pozicia] == polePriorita1[poziciaList2])
                    {
                        if (polePriorita1[poziciaList1] == polePriorita1[poziciaList2])
                        {
                            if (polePriorita2[pozicia] > polePriorita2[poziciaList1] || polePriorita2[pozicia] > polePriorita2[poziciaList2])
                            {
                                if (polePriorita2[poziciaList2] > polePriorita2[poziciaList1])
                                {
                                    Zamen(pozicia, poziciaList1);
                                    Zabublaj(poziciaList1);
                                }
                                else if (polePriorita2[poziciaList2] == polePriorita2[poziciaList1])
                                {
                                    Zamen(pozicia, poziciaList1);
                                    Zabublaj(poziciaList1);
                                }
                                else
                                {
                                    Zamen(pozicia, poziciaList2);
                                    Zabublaj(poziciaList2);
                                }
                            }
                        }
                        else if (polePriorita1[pozicia] == polePriorita1[poziciaList2])
                        {
                            if (polePriorita2[pozicia] > polePriorita2[poziciaList2])
                            {
                                Zamen(pozicia, poziciaList2);
                                Zabublaj(poziciaList2);
                            }
                        }
                        else
                        {
                            if (polePriorita2[pozicia] > polePriorita2[poziciaList1])
                            {
                                Zamen(pozicia, poziciaList1);
                                Zabublaj(poziciaList1);
                            }
                        }
                    }
                }
                else
                {
                    if (polePriorita1[pozicia] > polePriorita1[poziciaList1] || (polePriorita1[pozicia] == polePriorita1[poziciaList1] &&
                        polePriorita2[poziciaList1] < polePriorita2[pozicia]))
                    {
                        Zamen(pozicia, poziciaList1);
                        Zabublaj(poziciaList1);
                    }
                }
            }
            
        }
        
        private void Vybublaj(int pozicia)
        {
            int poziciaRodica;
            if (pozicia > 0)
            {
                if (pozicia % 2 == 0) poziciaRodica = (pozicia - 2) / 2;
                else poziciaRodica = (pozicia - 1) / 2;

                if (polePriorita1[poziciaRodica] > polePriorita1[pozicia] || (polePriorita1[poziciaRodica] == polePriorita1[pozicia] &&
                    polePriorita2[poziciaRodica] > polePriorita2[pozicia]))
                {
                    Zamen(poziciaRodica, pozicia);
                    Vybublaj(poziciaRodica);
                }
            } 
       }
        
        private void Zamen(int i, int j)
        {
            T prvokNahradny = halda[i];
            int priorita1Nahradna = polePriorita1[i];
            int priorita2Nahradna = polePriorita2[i];

            halda[i] = halda[j];
            polePriorita1[i] = polePriorita1[j];
            polePriorita2[i] = polePriorita2[j];

            halda[j] = prvokNahradny;
            polePriorita1[j] = priorita1Nahradna;
            polePriorita2[j] = priorita2Nahradna;
        }

        public T VratPrvok()
        {
            if (pocetPrvkov == 0) return default(T);
            else
            {
                T prvok = halda[0];
                halda[0] = halda[pocetPrvkov - 1];
                polePriorita1[0] = polePriorita1[pocetPrvkov - 1];
                polePriorita2[0] = polePriorita2[pocetPrvkov - 1];

                pocetPrvkov--;

                Zabublaj(0);
                return prvok;
            }
        }
        
        public void VlozPrvok(T prvokHaldy, int priorita1, int priorita2)
        {
            if (pocetPrvkov == velkost) ZvacsiHaldu();

            halda[pocetPrvkov] = prvokHaldy;
            polePriorita1[pocetPrvkov] = priorita1;
            polePriorita2[pocetPrvkov] = priorita2;
            pocetPrvkov++;

            Vybublaj(pocetPrvkov-1);
        }

        private void ZvacsiHaldu()
        {
            int novaVelkost = 2 * velkost;
            T[] novaHalda = new T[novaVelkost];
            int[] novePolePriorita1 = new int[novaVelkost];
            int[] novePolePriorita2 = new int[novaVelkost];

            for(int i=0;i<pocetPrvkov; i++)
            {
                novaHalda[i] = halda[i];
                novePolePriorita1[i] = polePriorita1[i];
                novePolePriorita2[i] = polePriorita2[i];
            }

            halda = novaHalda;
            polePriorita1 = novePolePriorita1;
            polePriorita2 = novePolePriorita2;
            velkost = novaVelkost;

        }


    }
}
