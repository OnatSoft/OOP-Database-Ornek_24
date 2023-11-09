using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP_DatabaseTest_24
{
    class UrunDB
    {
        SqlConnection baglanti = new SqlConnection(@"connection string");

        public List<Urunler> UrunList()
        {// Sınıf üzerinden OOP ile veritabanı Listeleme örneği

            List<Urunler> uruns = new List<Urunler>();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from UrunTBL", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Urunler urunler = new Urunler();
                urunler.ID = int.Parse(dr[0].ToString());
                urunler.MARKA = dr[1].ToString();
                urunler.MODEL = dr[2].ToString();
                urunler.SATIS_YIL = int.Parse(dr[3].ToString());
                urunler.SATIS_FIYAT = int.Parse(dr[4].ToString());
                urunler.SATICI = dr[5].ToString();
                uruns.Add(urunler);
            }
            baglanti.Close();
            return uruns;
        }

        public void UrunEkle(Urunler urunler)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into UrunTBL (marka,model,satısyıl,satısfıyat,satıcı) values (@pr1, @pr2, @pr3, @pr4, @pr5)", baglanti);
            cmd.Parameters.AddWithValue("@pr1", urunler.MARKA);
            cmd.Parameters.AddWithValue("@pr2", urunler.MODEL);
            cmd.Parameters.AddWithValue("@pr3", urunler.SATIS_YIL.ToString());
            cmd.Parameters.AddWithValue("@pr4", urunler.SATIS_FIYAT.ToString());
            cmd.Parameters.AddWithValue("@pr5", urunler.SATICI);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        public void UrunGuncelle(Urunler urunler)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update UrunTBL set marka=@pr1, model=@pr2, satısyıl=@pr3, satısfıyat=@pr4, satıcı=@pr5 where ıd=@id", baglanti);
            cmd.Parameters.AddWithValue("@id", urunler.ID);
            cmd.Parameters.AddWithValue("@pr1", urunler.MARKA);
            cmd.Parameters.AddWithValue("@pr2", urunler.MODEL);
            cmd.Parameters.AddWithValue("@pr3", urunler.SATIS_YIL.ToString());
            cmd.Parameters.AddWithValue("@pr4", urunler.SATIS_FIYAT.ToString());
            cmd.Parameters.AddWithValue("@pr5", urunler.SATICI);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        public void UrunSil(Urunler urunler)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from UrunTBL where ıd=@id", baglanti);
            cmd.Parameters.AddWithValue("@id", urunler.ID);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
