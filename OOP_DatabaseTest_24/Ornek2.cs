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
    public partial class Ornek2 : Form
    {
        public Ornek2()
        {
            InitializeComponent();
        }

        Urunler urunler = new Urunler();
        UrunDB urunDB = new UrunDB();

        DialogResult bildirim = new DialogResult();

        private void Ornek2_Load(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_ID.Clear();
            txt_MARKA.Clear();
            txt_MODEL.Clear();
            txt_SATISFIYAT.Clear();
            txt_SATISYIL.Clear();
            txt_SATICIAD.Clear();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {// textbox'lara girilen değerleri, 'urunler' adlı değişkene aktararak ve 'urunDB' sınıfında UrunEKle methodu çağrılarak DB'ye kaydediliyor.

            try
            {
                if (txt_MARKA.Text != "" || txt_MODEL.Text != "" || txt_SATISYIL.Text != "" || txt_SATISFIYAT.Text != "" || txt_SATICIAD.Text != "")
                {
                    urunler.MARKA = txt_MARKA.Text;
                    urunler.MODEL = txt_MODEL.Text;
                    urunler.SATIS_YIL = int.Parse(txt_SATISYIL.Text);
                    urunler.SATIS_FIYAT = int.Parse(txt_SATISFIYAT.Text);
                    urunler.SATICI = txt_SATICIAD.Text;
                    urunDB.UrunEkle(urunler);
                    MessageBox.Show("Ürün başarıyla listeye kaydedildi.", "BİLGİ");
                    dataGridView1.DataSource = urunDB.UrunList();
                }
                else
                {
                    MessageBox.Show("Lütfen tüm boş alanları doldurduktan sonra tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ürün kaydetme işleminde olağandışı bir hata oluştu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {// textbox'lara girilen değerleri, 'urunler' adlı değişkene aktararak ve 'urunDB' sınıfında UrunGuncelle methodu çağrılarak DB'ye güncelleniyor.

            try
            {
                if (txt_ID.Text == "" || txt_MARKA.Text == "" || txt_MODEL.Text == "" || txt_SATISYIL.Text == "" || txt_SATISFIYAT.Text == "" || txt_SATICIAD.Text == "")
                {
                    MessageBox.Show("Lütfen tüm boş alanları doldurduktan sonra tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bildirim = MessageBox.Show(txt_ID.Text + " Numaralı ürünün verileri listeden güncellenecek. Onaylıyor musunuz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (bildirim == DialogResult.Yes)
                    {
                        urunler.ID = int.Parse(txt_ID.Text);
                        urunler.MARKA = txt_MARKA.Text;
                        urunler.MODEL = txt_MODEL.Text;
                        urunler.SATIS_YIL = int.Parse(txt_SATISYIL.Text);
                        urunler.SATIS_FIYAT = int.Parse(txt_SATISFIYAT.Text);
                        urunler.SATICI = txt_SATICIAD.Text;
                        urunDB.UrunGuncelle(urunler);
                        MessageBox.Show(txt_ID.Text + " Numaralı ürün başarıyla listeden güncellendi.", "BİLGİ");
                        dataGridView1.DataSource = urunDB.UrunList();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ürün güncelleme işleminde olağandışı bir hata oluştu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_ID.Text == "" || txt_MARKA.Text == "" || txt_MODEL.Text == "" || txt_SATISYIL.Text == "" || txt_SATISFIYAT.Text == "" || txt_SATICIAD.Text == "")
                {
                    MessageBox.Show("Lütfen tüm boş alanları doldurduktan sonra tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bildirim = MessageBox.Show(txt_ID.Text + " Numaralı ürün listeden kalıcı olarak silinecek. Onaylıyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (bildirim == DialogResult.Yes)
                    {
                        urunler.ID = int.Parse(txt_ID.Text);
                        urunler.MARKA = txt_MARKA.Text;
                        urunler.MODEL = txt_MODEL.Text;
                        urunler.SATIS_YIL = int.Parse(txt_SATISYIL.Text);
                        urunler.SATIS_FIYAT = int.Parse(txt_SATISFIYAT.Text);
                        urunler.SATICI = txt_SATICIAD.Text;
                        urunDB.UrunSil(urunler);
                        MessageBox.Show(txt_ID.Text + " Numaralı ürün başarıyla listeden silindi.", "BİLGİ");
                        dataGridView1.DataSource = urunDB.UrunList();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ürün silme işleminde olağandışı bir hata oluştu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urunDB.UrunList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {// Datagridview'den çift tıklayınca ilgili textbox'lara verileri aktarma.

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_ID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_MARKA.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_MODEL.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_SATISYIL.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_SATISFIYAT.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_SATICIAD.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
