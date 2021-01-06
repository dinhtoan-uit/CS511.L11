using Do_An_Cuoi_Ki.DAO;
using Do_An_Cuoi_Ki.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Cuoi_Ki
{
    public partial class fDonHang : Form
    {
        public fDonHang()
        {
            InitializeComponent();
        }
        private void createColDGV()
        {
            dgvBillList.ColumnCount = 5;
            dgvBillList.Columns[0].Name = "Mã đơn hàng";
            dgvBillList.Columns[1].Name = "Ngày tạo đơn";
            dgvBillList.Columns[2].Name = "Mã khách hàng";
            dgvBillList.Columns[3].Name = "Mã nhân viên";
            dgvBillList.Columns[4].Name = "Khách phải trả";

        }
        private void fallDataDGV()
        {
            List<HoaDon> spList = HoaDonDAO.Instance.LoadBillList();
            foreach (HoaDon item in spList)
            {
                dgvBillList.Rows.Add(item.MaHD, item.NgayBan, item.MaKhach, item.MaNV, item.TongTien);
            }
        }
        private void fDonHang_Load(object sender, EventArgs e)
        {
            createColDGV();
            fallDataDGV();
        }

        private void txtSearchBill_TextChanged(object sender, EventArgs e)
        {
            dgvBillList.Rows.Clear();

            List<HoaDon> spList = HoaDonDAO.Instance.LoadBillList();

            foreach (HoaDon item in spList)
            {
                if (item.MaHD.Contains(txtSearchBill.Text) || item.MaKhach.Contains(txtSearchBill.Text) || item.MaNV.Contains(txtSearchBill.Text))
                {
                    dgvBillList.Rows.Add(item.MaHD, item.NgayBan, item.MaKhach, item.MaNV, item.TongTien);
                }
            }

            if (txtSearchBill.Text == "")
                fallDataDGV();
        }
    }
}
