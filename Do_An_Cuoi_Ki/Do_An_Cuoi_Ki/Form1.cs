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
    public partial class fMain : Form
    {
        private string user, pass;
        public bool home = false;
        public fMain()
        {
            InitializeComponent();
        }

        public fMain(string user, string pass)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hideOnPanelForm()
        {
            panelTitle.Visible = false;
            picTongQuan.Visible = false;
        }
        private void showOnPanelForm()
        {
            panelTitle.Visible = true;
            picTongQuan.Visible = true;
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if(panelAccount.Visible == true)
                panelAccount.Visible = false;
            else
                panelAccount.Visible = true;
        }
        private Form activeForm = null;
        private void openChildForm(Form chidlForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = chidlForm;
            chidlForm.TopLevel = false;
            chidlForm.FormBorderStyle = FormBorderStyle.None;
            chidlForm.Dock = DockStyle.Fill;
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(chidlForm);
            panelChildForm.Tag = chidlForm;
            chidlForm.BringToFront();
            chidlForm.Show();   
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            NhanVien idNhanVien = NhanVienDAO.Instance.SearchEmployee_WithName(btnAccount.Text);
            fbanHang f = new fbanHang(idNhanVien.MaNV);
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            showOnPanelForm();
            panelMenu.Visible = true;
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            openChildForm(new fDonHang());
            panelMenu.Visible = true;
            hideOnPanelForm();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new fKhachHang());
            panelMenu.Visible = true;
            hideOnPanelForm();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new fSanPham());
            panelMenu.Visible = true;
            hideOnPanelForm();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            openChildForm(new fBaoCao());
            panelMenu.Visible = true;
            hideOnPanelForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAccount.Text = this.user;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            fHoSo fHS = new fHoSo(this.user);
            fHS.Show();
        }
    }
}
