using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DTO
{
    class SanPham
    {
        private string maSP;
        private string tenSP;
        private string dVT;
        private string nuocSX;
        private string donGiaSP;
        private string linkSP;
        private string statusSP;
        public string NuocSX { get => nuocSX; set => nuocSX = value; }
        public string DonGiaSP { get => donGiaSP; set => donGiaSP = value; }
        public string LinkSP { get => linkSP; set => linkSP = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string DVT { get => dVT; set => dVT = value; }
        public string StatusSP { get => statusSP; set => statusSP = value; }

        public SanPham() { }
        public SanPham(string MaSP, string TenSP, string DVT, string NuocSX, string DonGiaSP, string LinkSP, string StatusSP )
        {
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.DVT = DVT;
            this.NuocSX = NuocSX;
            this.DonGiaSP = DonGiaSP;
            this.LinkSP = LinkSP;
            this.StatusSP = StatusSP;
        }
        public SanPham(DataRow row)
        {
            this.MaSP = row["MASP"].ToString();
            this.TenSP = row["TENSP"].ToString();
            this.DVT = row["DVT"].ToString();
            this.NuocSX = row["NUOCSX"].ToString();
            this.DonGiaSP = row["GIA"].ToString();
            this.LinkSP = row["LINK_ANH"].ToString();
            this.StatusSP = row["TRANGTHAI"].ToString();
        }
    }
}
