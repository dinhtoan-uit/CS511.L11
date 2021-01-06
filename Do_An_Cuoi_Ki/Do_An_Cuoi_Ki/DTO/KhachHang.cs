using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DTO
{
    class KhachHang
    {
        private string maKH;
        private string tenKH;
        private string diaChiKH;
        private string soDienThoaiKH;
        private string ngaySinhKH;
        private string doanhSoKH;
        private string ngayDangKyKH;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string DiaChiKH { get => diaChiKH; set => diaChiKH = value; }
        public string SoDienThoaiKH { get => soDienThoaiKH; set => soDienThoaiKH = value; }
        public string DoanhSoKH { get => doanhSoKH; set => doanhSoKH = value; }
        public string NgayDangKyKH { get => ngayDangKyKH; set => ngayDangKyKH = value; }
        public string NgaySinhKH { get => ngaySinhKH; set => ngaySinhKH = value; }

        public KhachHang() { }
        public KhachHang(string MaKH, string TenKH, string DiaChiKH, string SoDienThoaiKH, string NgaySinhKH, string DoanhSoKH, string NgayDangKyKH)
        {
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.DiaChiKH = DiaChiKH;
            this.SoDienThoaiKH = SoDienThoaiKH;
            this.NgaySinhKH = NgaySinhKH;
            this.DoanhSoKH = DoanhSoKH;
            this.NgayDangKyKH = NgayDangKyKH;
        }
        public KhachHang(DataRow row)
        {
            this.MaKH = row["MAKH"].ToString();
            this.TenKH = row["HOTEN"].ToString();
            this.DiaChiKH = row["DCHI"].ToString();
            this.SoDienThoaiKH = row["SODT"].ToString();
            this.NgaySinhKH = row["NGSINH"].ToString();
            this.DoanhSoKH =  row["DOANHSO"].ToString();
            this.NgayDangKyKH = row["NGDK"].ToString();
        }
    }
}
