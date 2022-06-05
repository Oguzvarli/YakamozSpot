using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YakamozSpot.BL;
using YakamozSpot.UI;

namespace YakamozSpot
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnMüşteriEkle_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri()
            {   Text = "Müşteri Ekle",
                Musteri = new Musteri() { ID = Guid.NewGuid() },

               


            };
            tekrar:
            var sonuc = frmMusteri.ShowDialog();  
            if (sonuc == DialogResult.OK)
            {

               bool b =  BLogic.MüşteriEkle(frmMusteri.Musteri);
                if (b)
                {
                        DataSet ds = BLogic.Müşterigetir("");
                        if (ds != null)
                            dataGridView1.DataSource = ds.Tables[0];
                        

                }
                else
                    goto tekrar;

            }

        }

        private void btnMüşteriDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            FrmMusteri frmMusteri = new FrmMusteri()
            {
                Text = "Müşteri Güncelle",
                Güncelleme = true,
                Musteri = new Musteri()
                {
                    ID = Guid.Parse( row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Soyad = row.Cells[2].Value.ToString(),
                    Telefon = row.Cells[3].Value.ToString(),
                    Mail = row.Cells[4].Value.ToString(),
                    Adres = row.Cells[5].Value.ToString(),
                },
            };
             
            var sonuc = frmMusteri.ShowDialog();
            if (sonuc == DialogResult.OK)
            {

                bool b = BLogic.MüşteriGüncelle(frmMusteri.Musteri);
                if (b)
                {

                    row.Cells[1].Value = frmMusteri.Musteri.Ad;
                    row.Cells[2].Value = frmMusteri.Musteri.Soyad;
                    row.Cells[3].Value = frmMusteri.Musteri.Telefon;
                    row.Cells[4].Value = frmMusteri.Musteri.Mail;
                    row.Cells[5].Value = frmMusteri.Musteri.Adres;

                }
           

            }
        }

        private void btnMüşteriBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.Müşterigetir("toolStripTextBox1.Text");
            if(ds != null)
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.Müşterigetir("");
            if (ds1 != null)
                dataGridView1.DataSource = ds1.Tables[0];

            DataSet ds2 = BLogic.Urungetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }

        private void btnMüşteriSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID =row.Cells[0].Value.ToString();
            
            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi ?", "Silmeyi Onayla ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {

                bool b = BLogic.MüşteriSil(ID);
                if (b)
                {

                    if (b)
                    {
                        DataSet ds = BLogic.Müşterigetir("");
                        if (ds != null)
                            dataGridView1.DataSource = ds.Tables[0];


                    }
                }


            }
        }

        private void btnÜrünEkle_Click(object sender, EventArgs e)
        {
            FrmUrun frm = new FrmUrun()
            {
                Text = "Müşteri Ekle",
                Urun = new Urun() { ID = Guid.NewGuid() },




            };
        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {

                bool b = BLogic.UrunEkle(frm.Urun);
                if (b)
                {
                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];


                }
                else
                    goto tekrar;

            }

        }
    }
    }
}
