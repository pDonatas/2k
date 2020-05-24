using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2
{
    class Modeliai<tipas> : IEnumerable<Auto>
        where tipas: IComparable<Auto>
    {
        private class Mazgas<type>{
            public Mazgas<type> Kaire { get; set; }
            public Mazgas<type> Desine { get; set; }
            public Auto Duom { get; set; }

            public Mazgas(Auto auto, Mazgas<type> k, Mazgas<type> d)
            {
                Desine = d;
                Kaire = k;
                Duom = auto;
            }
        }
        private Mazgas<tipas> pr;
        private Mazgas<tipas> pb;
        private Mazgas<tipas> d;

        public Modeliai()
        {
            pr = null;
            pb = null;
            d = null;
        }

        public void Pradzia()
        {
            d = pr;
        }

        public void Pabaiga()
        {
            d = pb;
        }

        public bool Baigti()
        {
            return d == null;
        }

        public void Desinen()
        {
            if (d != null) d = d.Desine;
        }

        public void Kairen()
        {
            if (d != null) d = d.Kaire;
        }

        public void Kitas()
        {
            d = d.Desine;
        }

        public bool Yra()
        {
            return d.Desine != null;
        }

        public bool KYra()
        {
            return d.Kaire != null;
        }

        public Auto ImtiDuomenis()
        {
            return d.Duom;
        }

        public void DetiDuomenisA(Auto auto)
        {
            var dd = new Mazgas<tipas>(auto, null, pr);
            if (pr != null) pr.Kaire = dd;
            else pb = dd;
            pr = dd;
        }

        public void DetiDuomenisT(Auto auto)
        {
            var dd = new Mazgas<tipas>(auto, pb, null);

            if (pr != null) pb.Desine = dd;
            else pr = dd;
            pb = dd;
        }

        public void Rikiuoti()
        {
            for(Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.Desine)
            {
                Mazgas<tipas> laik = d1;
                for(Mazgas<tipas> d2 = d1; d2 != null; d2 = d2.Desine)
                {
                    if (laik.Duom >= d2.Duom) laik = d2;
                }
                Auto at = d1.Duom;
                d1.Duom = laik.Duom;
                laik.Duom = at;
            }
        }

        public IEnumerator<Auto> GetEnumerator()
        {
            for(Mazgas<tipas> dd = pr; dd != null; dd = dd.Desine)
            {
                yield return dd.Duom;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
