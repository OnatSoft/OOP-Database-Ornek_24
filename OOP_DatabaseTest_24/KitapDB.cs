using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP_DatabaseTest_24
{
    class KitapDB
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-ONATSOFT\ONATSOFT;Initial Catalog=KitaplikOOP_DB;Integrated Security=True");

        public List<Kitap> ktpListe()
        {
            List<Kitap> ktp = new List<Kitap>();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from KitapTBL", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Kitap kitap = new Kitap();
                kitap.ID = int.Parse(dr[0].ToString());
                kitap.ADI = dr[1].ToString();
                kitap.YAZARI = dr[2].ToString();
                kitap.YAYINEVI = dr[3].ToString();
                ktp.Add(kitap);
            }
            baglanti.Close();
            return ktp;
        }

        public void KitapEkle(Kitap ktp)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into KitapTBL (KITAPAD,KITAPYAZAR,KITAPYAYINEVI) values (@a1, @a2, @a3)", baglanti);
            cmd.Parameters.AddWithValue("@a1", ktp.ADI);
            cmd.Parameters.AddWithValue("@a2", ktp.YAZARI);
            cmd.Parameters.AddWithValue("@a3", ktp.YAYINEVI);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        public void KitapSil(Kitap ktp)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from KitapTBL where ID=@id", baglanti);
            cmd.Parameters.AddWithValue("@id", ktp.ID);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        public void KitapGuncelle(Kitap ktp)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update KitapTBL set KITAPAD = @a1, KITAPYAZAR=@a2, KITAPYAYINEVI=@a3 where ID=@id", baglanti);
            cmd.Parameters.AddWithValue("@id", ktp.ID);
            cmd.Parameters.AddWithValue("@a1", ktp.ADI);
            cmd.Parameters.AddWithValue("@a2", ktp.YAZARI);
            cmd.Parameters.AddWithValue("@a3", ktp.YAYINEVI);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
