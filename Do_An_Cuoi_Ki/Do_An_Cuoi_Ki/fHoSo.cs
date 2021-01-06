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
    public partial class fHoSo : Form
    {
        private string user;
        private List<NhanVien> userList = NhanVienDAO.Instance.LoadEmployeeList();
        public fHoSo()
        {
            InitializeComponent();
        }
        public fHoSo(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fHoSo_Load(object sender, EventArgs e)
        {
            foreach (NhanVien item in userList)
            {
                if(item.NameNV == this.user)
                {
                    txtName.Text = user;
                    txtPhoneNumber.Text = item.DienThoai;
                    txtPassWord.Text = "admin";
                    txtStatus.Text = "Đang hoạt động.";
                }    
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
