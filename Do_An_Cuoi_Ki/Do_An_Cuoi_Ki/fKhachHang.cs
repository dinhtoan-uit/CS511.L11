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
    public partial class fKhachHang : Form
    {

        private KhachHang newSoldier;
        public bool addNewPerson = false;
        public fKhachHang()
        {
            InitializeComponent();
        }
        private void createColDGV()
        {
            dgvCustomer.ColumnCount = 6;
            dgvCustomer.Columns[0].Name = "Mã khách hàng";
            dgvCustomer.Columns[1].Name = "Ngày đăng ký";
            dgvCustomer.Columns[2].Name = "Tên khách hàng";
            dgvCustomer.Columns[3].Name = "Ngày sinh";
            dgvCustomer.Columns[4].Name = "Số điện thoại";
            dgvCustomer.Columns[5].Name = "Địa chỉ";

            dgvCustomer.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void fallDataDGV()
        {
            List<KhachHang> khList = KhachHangDAO.Instance.LoadCustomerList();
            foreach (KhachHang item in khList)
            {
                dgvCustomer.Rows.Add(item.MaKH, item.NgayDangKyKH, item.TenKH, item.NgaySinhKH, item.SoDienThoaiKH, item.DiaChiKH);
            }
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            newSoldier = new KhachHang();
            createColDGV();
            fallDataDGV();
        }
        private void LoadData(string codePerson, string name, string dateOfBirth, string phone, string address, bool boolNewPerson)
        {
            newSoldier.MaKH = codePerson;
            newSoldier.TenKH = name;
            newSoldier.NgaySinhKH = dateOfBirth;
            newSoldier.SoDienThoaiKH = phone;
            newSoldier.DiaChiKH = address;
            addNewPerson = boolNewPerson;
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            fNewPerson f = new fNewPerson();
            f.shareDT = new fNewPerson.ShareData(LoadData);
            f.ShowDialog();

            if (addNewPerson == true)
            {
                var dateString = DateTime.Now.ToString("d", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                if (KhachHangDAO.Instance.InsertCustomer(newSoldier.MaKH, newSoldier.TenKH,
                    newSoldier.DiaChiKH, newSoldier.SoDienThoaiKH, newSoldier.NgaySinhKH, 0, dateString))
                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBill_TextChanged(object sender, EventArgs e)
        {
            dgvCustomer.Rows.Clear();

            List<KhachHang> khList = KhachHangDAO.Instance.LoadCustomerList();

            foreach (KhachHang item in khList)
            {
                if (item.TenKH.Contains(txtSearchCustomers.Text) || item.MaKH.Contains(txtSearchCustomers.Text))
                {
                    dgvCustomer.Rows.Add(item.MaKH, item.NgayDangKyKH, item.TenKH, item.NgaySinhKH, item.SoDienThoaiKH, item.DiaChiKH);
                }
            }

            if (txtSearchCustomers.Text == "")
                fallDataDGV();
        }
    }
}
