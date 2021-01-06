using Do_An_Cuoi_Ki.DAO;
using Do_An_Cuoi_Ki.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Cuoi_Ki
{
    public partial class fPrint : Form
    {
        private string idBill, discount, payMoney;
        public fPrint()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
        
            CaptureScreen();
            printPreviewDialog1.ShowDialog();
            this.Close();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public fPrint(string data, string discount, string payMoney)
        {
            InitializeComponent();
            this.idBill = data;
            this.discount = discount;
            this.payMoney = payMoney;
        }


        private void fPrint_Load(object sender, EventArgs e)
        {
            HoaDon billSearch = HoaDonDAO.Instance.SearchHoaDon(idBill);
            KhachHang customerSearch = KhachHangDAO.Instance.SearchCustomer_WithID(billSearch.MaKhach);
            List<ChiTietHoaDon> billDetailTable = ChiTietHoaDonDAO.Instance.searchBillDetail(idBill);
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

            labTenKh.Text = customerSearch.TenKH;
            labDiaChi.Text = customerSearch.DiaChiKH;
            labSDT.Text = customerSearch.SoDienThoaiKH;
            labMaHD.Text = idBill;
            labNgay.Text = billSearch.NgayBan;

            labChietKhau.Text = discount + " %";
            labTongTien.Text = double.Parse(billSearch.TongTien).ToString("#,###", cul.NumberFormat) + " vnđ";
            labTienKhachTra.Text = double.Parse(payMoney).ToString("#,###", cul.NumberFormat) + " vnđ";
            labTienThua.Text = double.Parse((int.Parse(payMoney) - int.Parse(billSearch.TongTien)).ToString()).ToString("#,###", cul.NumberFormat) + " vnđ";

            foreach (ChiTietHoaDon row in billDetailTable)
            {
                SanPham sp = SanPhamDAO.Instance.SearchProduct(row.MaHang);
                double tong = double.Parse(sp.DonGiaSP) * double.Parse(row.SoLuong.ToString());
                dataGridView1.Rows.Add(sp.TenSP, row.SoLuong.ToString(), sp.DonGiaSP, tong);
            }
        }

    }
}
