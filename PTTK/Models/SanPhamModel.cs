using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PTTK.Models
{
    public class SanPhamModel
    {
        string strConString = ConfigurationManager.AppSettings.Get("connString");
        public DataTable getAllSanPham()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from SanPham", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable getAllDienThoai()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from SanPham where laDienThoai = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable getAllPhuKien()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from SanPham where laDienThoai = 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetSanPham(int maSanPham)  
        {  
            DataTable dt = new DataTable();  
  
            using (SqlConnection con = new SqlConnection(strConString))  
            {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from SanPham where ma=" + maSanPham, con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(dt);  
            }  
            return dt;  
        }  

    }
}