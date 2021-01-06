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
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
        }
        private void createColDGV()
        {
            dgvProduct.ColumnCount = 6;
            dgvProduct.Columns[0].Name = "Mã sản phẩm";
            dgvProduct.Columns[1].Name = "Tên sản phẩm";
            dgvProduct.Columns[2].Name = "Đơn vị tính";
            dgvProduct.Columns[3].Name = "Nước sản xuất";
            dgvProduct.Columns[4].Name = "Giá bán";
            dgvProduct.Columns[5].Name = "Trạng thái";
        }
        private void fallDataDGV()
        {
            List<SanPham> spList = SanPhamDAO.Instance.LoadProductList();
            foreach (SanPham item in spList)
            {
                dgvProduct.Rows.Add(item.MaSP, item.TenSP, item.DVT, item.NuocSX, item.DonGiaSP, item.StatusSP);
            }
        }

        private void fSanPham_Load(object sender, EventArgs e)
        {
            createColDGV();
            fallDataDGV();
        }

        private void btnStopSellProduct_Click(object sender, EventArgs e)
        {
            int i = dgvProduct.SelectedRows.Count;
            if (i >= dgvProduct.Rows.Count - 1) return;
            bool result = false;
            foreach (DataGridViewRow item in this.dgvProduct.SelectedRows)
            {
                if (SanPhamDAO.Instance.UpdateStatusOfProduct_End(item.Cells[0].Value.ToString()))
                    result = true;
            }
            if(result)
                MessageBox.Show("Đã dừng bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi rồi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dgvProduct.Rows.Clear();
            fallDataDGV();
        }

        private void btnContinueSellProduct_Click(object sender, EventArgs e)
        {
            int i = dgvProduct.SelectedRows.Count;
            if (i >= dgvProduct.Rows.Count - 1) return;
            bool result = false;
            foreach (DataGridViewRow item in this.dgvProduct.SelectedRows)
            {
                if (SanPhamDAO.Instance.UpdateStatusOfProduct_Begin(item.Cells[0].Value.ToString()))
                    result = true;
            }
            if(result)
                MessageBox.Show("Được bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi rồi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dgvProduct.Rows.Clear();
            fallDataDGV();
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "") return;

            List<SanPham> spList = SanPhamDAO.Instance.LoadProductList();

            dgvProduct.Rows.Clear();
            foreach (SanPham item in spList)
            {
                //Contains(item.TenSP)
                if (item.TenSP.Contains(txtSearchProduct.Text))
                {
                    dgvProduct.Rows.Add(item.MaSP, item.TenSP, item.DVT, item.NuocSX, item.DonGiaSP, item.StatusSP);
                }    
            }
        }

        private void txtSearchBill_TextChanged(object sender, EventArgs e)
        { 
            dgvProduct.Rows.Clear();

            List<SanPham> spList = SanPhamDAO.Instance.LoadProductList();
           
            foreach (SanPham item in spList)
            {
                if (item.TenSP.Contains(txtSearchProduct.Text) || item.DVT.Contains(txtSearchProduct.Text) || item.MaSP.Contains(txtSearchProduct.Text)
                    || item.NuocSX.Contains(txtSearchProduct.Text) || item.DonGiaSP.Contains(txtSearchProduct.Text) || item.StatusSP.Contains(txtSearchProduct.Text))
                {
                    dgvProduct.Rows.Add(item.MaSP, item.TenSP, item.DVT, item.NuocSX, item.DonGiaSP, item.StatusSP);
                }
            }

            if (txtSearchProduct.Text == "")
                fallDataDGV();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProduct.Rows.Clear();
            if (comboBoxFilter.SelectedIndex == 0)
            {
                List<SanPham> spList = SanPhamDAO.Instance.filterDVTProductList();
                foreach (SanPham item in spList)
                {
                    dgvProduct.Rows.Add(item.MaSP, item.TenSP, item.DVT, item.NuocSX, item.DonGiaSP, item.StatusSP);
                }
            } 
            else if(comboBoxFilter.SelectedIndex == 1)
            {
                List<SanPham> spList = SanPhamDAO.Instance.filterProduceProductList();
                foreach (SanPham item in spList)
                {
                    dgvProduct.Rows.Add(item.MaSP, item.TenSP, item.DVT, item.NuocSX, item.DonGiaSP, item.StatusSP);
                }
            }    
        }
    }
}
