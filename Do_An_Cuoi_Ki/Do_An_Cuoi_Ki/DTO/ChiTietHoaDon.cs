using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DTO
{
    class ChiTietHoaDon
    {
        private string maHD;
        private string maHang;
        private int soLuong;

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietHoaDon(string MaHD, string MaHang, int SoLuong)
        {
            this.MaHD = MaHD;
            this.MaHang = MaHang;
            this.SoLuong = SoLuong;
            
        }
        public ChiTietHoaDon(DataRow row)
        {
            this.MaHD = row["SOHD"].ToString();
            this.MaHang = row["MASP"].ToString();
            this.SoLuong = (int) row["SL"];
        }
    }
}
