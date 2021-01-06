using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DTO
{
    class NhanVien
    {
        private string maNV;
        private string nameNV;
        private string dienThoai;
        private string ngayVaoLam;
        public string MaNV { get => maNV; set => maNV = value; }
        public string NameNV { get => nameNV; set => nameNV = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }

        public NhanVien() { }
        public NhanVien(string MaNV, string NameNV, string DienThoai, string NgayVaoLam)
        {
            this.MaNV = MaNV;
            this.NameNV = NameNV;
            this.DienThoai = DienThoai;
            this.NgayVaoLam = NgayVaoLam;
        }
        public NhanVien(DataRow row)
        {
            this.MaNV = row["MANV"].ToString();
            this.NameNV = row["HOTEN"].ToString();
            this.DienThoai = row["SDT"].ToString();
            this.NgayVaoLam = row["NGVL"].ToString();
        }
    }
}
