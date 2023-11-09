using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_DatabaseTest_24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kitap> Listktp = new List<Kitap>();
        KitapDB kitapDB = new KitapDB();
        Kitap kitap = new Kitap();

        /* 'KitapDB' sınıfında tüm veritabanı işlemleri/komutları yazılırken burada 'KitapDB' sınıfında yazılan ilgili (Ekleme, Silme, Güncelleme, Listeleme) metod'lar çağrılarak
         * 'kitap' sınıfında yazan değişkenler ile karşılık gelen textbox nesneleri eşleştiriliyor ve gerekli işlem başarıyla gerçekleştiriliyor. */

        private void btn_Listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kitapDB.ktpListe();
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurduktan sonra tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    kitap.ADI = textBox2.Text;
                    kitap.YAZARI = textBox3.Text;
                    kitap.YAYINEVI = textBox4.Text;
                    kitapDB.KitapEkle(kitap);
                    MessageBox.Show("Kitap listeye başarıyla kaydedildi.", "BİLGİ");
                    dataGridView1.DataSource = kitapDB.ktpListe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Kaydetme işleminde olağan dışı bir hata oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurduktan sonra tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    kitap.ID = int.Parse(textBox1.Text);
                    kitap.ADI = textBox2.Text;
                    kitap.YAZARI = textBox3.Text;
                    kitap.YAYINEVI = textBox4.Text;
                    kitapDB.KitapSil(kitap);
                    MessageBox.Show("Seçili kitap listeden başarıyla silindi.", "BİLGİ");
                    dataGridView1.DataSource = kitapDB.ktpListe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Silme işleminde olağan dışı bir hata oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Güncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurduktan sonra tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    kitap.ID = int.Parse(textBox1.Text);
                    kitap.ADI = textBox2.Text;
                    kitap.YAZARI = textBox3.Text;
                    kitap.YAYINEVI = textBox4.Text;
                    kitapDB.KitapGuncelle(kitap);
                    MessageBox.Show("Seçili kitap listede başarıyla güncellendi.", "BİLGİ");
                    dataGridView1.DataSource = kitapDB.ktpListe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Güncelleme işleminde olağan dışı bir hata oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ornek2 frm2 = new Ornek2();
            frm2.Show();
            this.Hide();
        }
    }
}