using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DTO
{
    class HoaDon
    {
        private string maHD;
        private string maNV;
        private string ngayBan;
        private string maKhach;
        private string tongTien;
        private string ghiChu;

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string NgayBan { get => ngayBan; set => ngayBan = value; }
        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public HoaDon() { }
        public HoaDon(string MaHD, string NgayBan, string MaKhach,  string MaNV, string TongTien, string GhiChu)
        {
            this.MaHD = MaHD;
            this.MaNV = MaNV;
            this.NgayBan = NgayBan;
            this.MaKhach = MaKhach;
            this.TongTien = TongTien;
            this.GhiChu = GhiChu;
        }
        public HoaDon(DataRow row)
        {
            this.MaHD = row["SOHD"].ToString();
            this.NgayBan = row["NGHD"].ToString();
            this.MaKhach = row["MAKH"].ToString();
            this.MaNV = row["MANV"].ToString();
            this.TongTien = row["TRIGIA"].ToString();
            this.GhiChu = row["GHICHU"].ToString();
        }
    }
}
