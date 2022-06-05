using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YakamozSpot.DL;

namespace YakamozSpot.BL
{
    public static class BLogic
    {
        public static bool MüşteriEkle(Musteri m )
        {
            try
            {

                int res = DataLayer.MüşteriEkle(m);
                return (res > 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata Oluştu :"+ ex.Message);
                return false;
            }

        }

        internal static DataSet Müşterigetir(string filtre)
        {
            try
            {

                DataSet ds  = DataLayer.MüşteriGetir(filtre);
                return ds
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu :" + ex.Message);
                return null;
            }
        }

        internal static bool MüşteriGüncelle(Musteri musteri)
        {
            try
            {

                int res = DataLayer.MüşteriGüncelle(m);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool MüşteriSil(string id)
        {
            try
            {

                int res = DataLayer.MüşteriSil(id);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool UrunEkle(Urun u)
        {
            try
            {

                int res = DataLayer.UrunEkle(u);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu :" + ex.Message);
                return false;
            }
        }

        internal static DataSet Urungetir(string v)
        {
            try
            {

                DataSet ds = DataLayer.UrunGetir(filtre);
                return ds
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu :" + ex.Message);
                return null;
            }
        }
    }
}
