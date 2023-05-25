using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Sürücü_Kursu_Otomasyonu
{
    internal class Sınıf
    {

        //public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Surucu Kursu;Integrated Security=True";
        public static string BAG()
        {
            string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Surucu Kursu;Integrated Security=True";
            return SqlCon;
        }
        //public static string SqlCon = @"Data Source=EMIN\SQLEXPRESS;Initial Catalog=Pharmacy;Integrated Security=True";

        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static DataSet ds;



        public static bool login(string kullanici, string password)
        {
            string sorgu = "select * from login where kullanıcı=@kullanici and sifre=@parola";
            con = new SqlConnection(Sınıf.BAG());
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kullanici", kullanici);
            cmd.Parameters.AddWithValue("@parola", Sınıf.MD5sifreleme(password));
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                con.Close();
                return true;
            }
            else
            {

                con.Close();
                return false;


            }

        }
        public static DataGridView griddoldur(DataGridView grid, string sqlselectsorgu)
        {
            con = new SqlConnection(BAG());
            da = new SqlDataAdapter(sqlselectsorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlselectsorgu);
            grid.DataSource = ds.Tables[sqlselectsorgu];
            con.Close();
            return grid;

        }


        public static string MD5sifreleme(string sifreleme)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifreleme);
            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (byte item in dizi)
            {
                sb.Append(item.ToString("x2").ToLower());
            }

            return sb.ToString();


        }
        public static void kom(string sql)
        { 
        con = new SqlConnection(BAG());
        cmd = new SqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
        con.Close();
         }



    
    }
}
