using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Modeliai<Auto> A = new Modeliai<Auto>();
            p.Skaitymas("duom.txt", A);
            
            Auto Brangiausias = p.Brangiausias(A);
            Modeliai<Auto> B = p.Brangiausi(A, Brangiausias);

            B.Rikiuoti();
            p.Spausdinti(p.Brangiausi(A, Brangiausias), B);
        }

        Modeliai<Auto> Brangiausi(Modeliai<Auto> A, Auto Brangus)
        {
            Modeliai<Auto> B = new Modeliai<Auto>();
            foreach(Auto auto in A)
            {
                if(auto.Kaina >= Brangus.Kaina - Brangus.Kaina*0.25 || auto.Kaina == Brangus.Kaina)
                {
                    B.DetiDuomenisT(auto);
                }
            }
            return B;
        }

        Auto Brangiausias(Modeliai<Auto> modeliai)
        {
            int kaina = 0;
            Auto brangus = new Auto();
            foreach(Auto modelis in modeliai)
            {
                if(modelis.Kaina > kaina)
                {
                    kaina = modelis.Kaina;
                    brangus = modelis;
                }
            }
            return brangus;
        } 

        void Spausdinti(Modeliai<Auto> Nerik, Modeliai<Auto> Rik)
        {
            using (StreamWriter sw = new StreamWriter("Rezultatai.txt"))
            {
                sw.WriteLine("Nerikiuotas sąrašas:");
                string eil = string.Format("{0, -20} {1, -20} {2, -20}", "Markė", "Modelis", "Kaina");
                sw.WriteLine(eil);
                foreach (var modelis in Nerik)
                {
                    sw.WriteLine(modelis.ToString());
                }
                sw.WriteLine("Rikiuotas sąrašas:");
                eil = string.Format("{0, -20} {1, -20} {2, -20}", "Markė", "Modelis", "Kaina");
                sw.WriteLine(eil);
                foreach (var modelis in Rik)
                {
                    sw.WriteLine(modelis.ToString());
                }
            }
        }

        void Skaitymas(string failas, Modeliai<Auto> modeliai)
        {
            using(StreamReader sr = new StreamReader(failas))
            {
                string eil = null;
                while(null != (eil = sr.ReadLine()))
                {
                    string[] duom = eil.Split(';');
                    Auto auto = new Auto(duom[0], duom[1], int.Parse(duom[2]));
                    modeliai.DetiDuomenisT(auto);
                }
            }
        }
    }
}
