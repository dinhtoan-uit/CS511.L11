using Do_An_Cuoi_Ki.DTO;
using Do_An_Cuoi_Ki.DAO;
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
    public partial class fLogin : Form
    {
        private List<NhanVien> userList = NhanVienDAO.Instance.LoadEmployeeList();
        public fLogin()
        {
            InitializeComponent();
            comboBoxUser.DataSource = userList;
            comboBoxUser.DisplayMember = "NameNV";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int KQ = 0;

            foreach (NhanVien item in userList)
            {
                if (comboBoxUser.Text == item.NameNV)
                    KQ = 1;
            }
            if (txtPassword.Text != "admin")
                KQ = 0;

            if (KQ == 1)
            {
                MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain f = new fMain(comboBoxUser.Text, txtPassword.Text);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
