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
    public partial class fNewPerson : Form
    {
        public delegate void ShareData(string codePerson, string name, string dateOfBirth, string phone, string address, bool addNewPerson);
        public ShareData shareDT;
            
        public fNewPerson()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtAddress.Text != "" && txtCodeCustomer.Text != "" && txtNamePerson.Text != "" && txtPhone.Text != "")
            {
                if(shareDT != null)
                {
                    string date = dtpDateOfBirth.Value.Date.ToString("dd/MM/yyyy");
                    shareDT(txtCodeCustomer.Text, txtNamePerson.Text, date, txtPhone.Text, txtAddress.Text, true);
                    this.Close();
                }    
            }    
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fNewPerson_Load(object sender, EventArgs e)
        {
            List<KhachHang> newCustomer = KhachHangDAO.Instance.LoadCustomerList();
            txtCodeCustomer.Text = "KH" + (newCustomer.Count + 1).ToString();
        }
    }
}
