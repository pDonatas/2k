using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2
{
    class Auto : IComparable<Auto>
    {
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int Kaina { get; set; }

        public Auto() { }

        public Auto(string marke, string modelis, int kaina)
        {
            Marke = marke;
            Modelis = modelis;
            Kaina = kaina;
        }

        public int CompareTo(Auto other)
        {
            if (other == null) return 1;
            if (Kaina != other.Kaina) return other.Kaina.CompareTo(Kaina);
            else return Modelis.CompareTo(other.Modelis);
        }

        public override string ToString()
        {
            string eil = string.Format("{0, -20} {1, -20} {2, -20}", Marke, Modelis, Kaina);
            return eil;
        }
        public static bool operator >=(Auto vienas, Auto du)
        {
            return vienas.CompareTo(du) == 1;
        }

        public static bool operator <=(Auto vienas, Auto du)
        {
            return vienas.CompareTo(du) == -1;
        }
    }
}
