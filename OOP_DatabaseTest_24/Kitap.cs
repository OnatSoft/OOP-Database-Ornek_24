using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_DatabaseTest_24
{
    class Kitap
    {
        int id;
        string ad;
        string yazar;
        string yayinevi;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string ADI
        {
            get { return ad; }
            set { ad = value; }
        }

        public string YAZARI
        {
            get { return yazar; }
            set { yazar = value; }
        }

        public string YAYINEVI
        {
            get { return yayinevi; }
            set { yayinevi = value; }
        }
    }
}
