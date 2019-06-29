using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace PTTK.Models
{
    public class KhachHangModel
    {
        public DataTable getAllKhachHang()
        {
            string strConString = ConfigurationManager.AppSettings.Get("connString");
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhachHang", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable getKhachHang(int maKH)
        {
            string strConString = ConfigurationManager.AppSettings.Get("connString");
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhachHang where ma = "+maKH, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public int insertKhachHang(string ten, string loai,  string sdt, string diaChi, string nguoiDaiDien, string sdtCongTy) 
        {
            string strConString = ConfigurationManager.AppSettings.Get("connString");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string sql = "insert into khachHang(ten , loai, sodienthoai, diachi, nguoidaidien," +
                    " sodienthoaicongty) values (@ten, @loai, @soDienThoai,@diaChi, @nguoiDaiDien, @soDienThoaiCongTy)";
                  
                
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@loai", loai);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@soDienThoai", sdt);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@nguoiDaiDien",nguoiDaiDien);
                cmd.Parameters.AddWithValue("@soDienThoaiCongTy", sdtCongTy);
                
                int k = cmd.ExecuteNonQuery();
                if (k == 0)
                {
                    Console.WriteLine("khong tim thayt");
                }
                return k;
            }
        }
        public int deleteKhachHang(int makh)
        {
            string strConString = ConfigurationManager.AppSettings.Get("connString");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string sql = "delete from khachhang where ma = @ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ma", makh);
                return cmd.ExecuteNonQuery();
            }
        }
        public int updateKhachHang(string ten, string loai,string soDienThoai,string nguoiDaiDien, string diaChi,string soDienThoaiCongTy, int id)
        {
            string strConString = ConfigurationManager.AppSettings.Get("connString");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string sql = "update khachhang set ten = @ten, loai = @loai ,sodienthoai = @sdt" +
                    ", diachi = @diaChi, nguoidaidien = @nguoiDaiDien" +
                    ", sodienthoaicongty = @sdtCongTy " +
                    " WHERE ma = @ma";
               
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@loai", loai);
                cmd.Parameters.AddWithValue("@sdt", soDienThoai);
                cmd.Parameters.AddWithValue("@nguoiDaiDien", nguoiDaiDien);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@sdtCongTy", soDienThoaiCongTy);
                cmd.Parameters.AddWithValue("@ma", id);
                return cmd.ExecuteNonQuery();
                
            }
        }
    }
}