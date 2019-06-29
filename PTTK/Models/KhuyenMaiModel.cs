using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PTTK.Models
{
    public class KhuyenMaiModel
    {
        string strConString = ConfigurationManager.AppSettings.Get("connString");

        public DataTable getAllKhuyenMai()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhuyenMai", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable getKhuyenMai(int ma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhuyenMai where ma = @ma", con);
                cmd.Parameters.AddWithValue("@ma", ma);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insert(string ten, string loai, string thoiGianBatDau, string thoiGianKetThuc, int giaTri, int tongTienThapNhat = 0)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into KhuyenMai (ten, loai,thoiGianBatDau, thoiGianKetThuc, giaTri, tongTienThapNhat ) values(@ten, @loai, @thoiGianBatDau, @thoiGianKetThuc, @giaTri, @tongTienThapNhat)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@loai", loai);
                cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                cmd.Parameters.AddWithValue("@giaTri", giaTri);
                cmd.Parameters.AddWithValue("@tongTienThapNhat", tongTienThapNhat);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(int ma, string ten, string loai, string thoiGianBatDau, string thoiGianKetThuc, int giaTri, int tongTienThapNhat = 0)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update KhuyenMai SET ten = @ten, loai = @loai, thoiGianBatDau = @thoiGianBatDau, thoiGianKetThuc = @thoiGianKetThuc, giaTri = @giaTri, tongTienThapNhat = @tongTienThapNhat where ma=@ma";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@loai", loai);
                cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                cmd.Parameters.AddWithValue("@giaTri", giaTri);
                cmd.Parameters.AddWithValue("@tongTienThapNhat", tongTienThapNhat);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int ma)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete KhuyenMai Where ma = @ma";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ma", ma);
                return cmd.ExecuteNonQuery();
            }

        }
    }
}