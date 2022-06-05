using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YakamozSpot.DL
{
    public static class DataLayer
    {
        static MySqlConnection connection = new MySqlConnection(
            new MySqlConnectionStringBuilder()
            {
                Server ="localhost", 
                Database = "yakamoz",
                UserID = "root",
                Password="root",



            }.ConnectionString
            );


        public static int MüşteriEkle(Musteri m )
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                MySqlCommand komut = new MySqlCommand("yakamoz_MusteriEkle", connection);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", m.ID);
                komut.Parameters.AddWithValue("@ad", m.Ad);
                komut.Parameters.AddWithValue("@soy", m.Soyad);
                komut.Parameters.AddWithValue("@tel", m.Telefon);
                komut.Parameters.AddWithValue("@mail", m.Mail);
                komut.Parameters.AddWithValue("@adr", m.Adres);

                int res =  komut.ExecuteNonQuery();
                return res;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State!=System.Data.ConnectionState.Closed) 
                connection.Close();
            }
             

        }

        internal static DataSet MüşteriGetir(string filtre)
        {
            throw new NotImplementedException();
        }

        internal static int MüşteriSil(string id)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                MySqlCommand komut = new MySqlCommand("yakamoz_MusteriSil", connection);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", id);
         
                int res = komut.ExecuteNonQuery();
                return res;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }

        internal static DataSet UrunGetir(string filtre)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                MySqlCommand komut;
                if (string.IsNullOrEmpty(filtre))
                {

                    komut = new MySqlCommand("yakamoz_UrunlerHepsi", connection);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;

                }
                else
                {
                    komut = new MySqlCommand("yakamoz_UrunBul", connection);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@filtre", filtre);
                }


                Dataset dataSet = new Dataset();
                MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                adp.Fill(dataSet);
                return dataSet;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }

        internal static int UrunEkle(Urun u)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                MySqlCommand komut = new MySqlCommand("yakamoz_UrunEkle", connection);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", u.ID);
                komut.Parameters.AddWithValue("@ad", u.Ad);
                komut.Parameters.AddWithValue("@kat", u.Kategori);
                komut.Parameters.AddWithValue("@fiy", u.Fiyat);
                komut.Parameters.AddWithValue("@stk", u.Stok);
                komut.Parameters.AddWithValue("@brm", u.Birim);
                komut.Parameters.AddWithValue("@dty", u.Detay);

                int res = komut.ExecuteNonQuery();
                return res;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }

        }

        internal static int MüşteriGüncelle(object m)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                MySqlCommand komut = new MySqlCommand("yakamoz_MusteriGuncelle", connection);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", m.ID);
                komut.Parameters.AddWithValue("@ad", m.Ad);
                komut.Parameters.AddWithValue("@soy", m.Soyad);
                komut.Parameters.AddWithValue("@tel", m.Telefon);
                komut.Parameters.AddWithValue("@mail", m.Mail);
                komut.Parameters.AddWithValue("@adr", m.Adres);

                int res = komut.ExecuteNonQuery();
                return res;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }

        }

        internal static Dataset Müşterigetir(string filtre)
        {
            
            {
                try
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();
                    MySqlCommand komut;
                    if (string.IsNullOrEmpty(filtre))
                    {

                        komut = new MySqlCommand("yakamoz_MusterilerHepsi", connection);
                        komut.CommandType = System.Data.CommandType.StoredProcedure;
                       
                    }
                    else
                    {
                        komut = new MySqlCommand("yakamoz_MusteriBul", connection);
                        komut.CommandType = System.Data.CommandType.StoredProcedure;
                        komut.Parameters.AddWithValue("@filtre", filtre);
                    }
                   

                    Dataset dataSet = new Dataset();
                  MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                    adp.Fill(dataSet);
                    return dataSet;



                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    if (connection.State != System.Data.ConnectionState.Closed)
                        connection.Close();
                }
                

            }
        }
}
