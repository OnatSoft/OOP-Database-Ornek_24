using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_DatabaseTest_24
{
    class Urunler
    {
        int id;
        string marka;
        string model;
        int satisyil;
        int satisfiyat;
        string satici;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string MARKA
        {
            get { return marka; }
            set { marka = value; }
        }

        public string MODEL
        {
            get { return model; }
            set { model = value; }
        }

        public int SATIS_YIL 
        {
            get { return satisyil; }
            set { satisyil = value; }
        }

        public int SATIS_FIYAT
        {
            get { return satisfiyat; }
            set { satisfiyat = value; }
        }

        public string SATICI
        {
            get { return satici; }
            set { satici = value; }
        }
    }
}
