using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using BarcodeLib;

using ZXing;
using Do_An_Cuoi_Ki.DTO;
using Do_An_Cuoi_Ki.DAO;
using AForge.Video.DirectShow;
using AForge.Video;

namespace Do_An_Cuoi_Ki
{
    public partial class fbanHang : Form
    {
        #region variable

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        KhachHang newSoldier;
        bool addNewPerson = false;

        private string idStaff;
        #endregion
        

        public fbanHang()
        {
            InitializeComponent();
        }
        public fbanHang(string idNhanVien)
        {
            InitializeComponent();
            this.idStaff = idNhanVien;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string nameDevice = null;
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            // chuyển đổi sang quét mã barcode
            if(panelChoose.Visible == true)
            {
                panelChoose.Visible = false;
                panelScan.Visible = true;
                picBarCode.Visible = true;
                btnSwitch.Text = "Chuyển đổi sang chọn thủ công";

                
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo device  in filterInfoCollection)
                {
                    if (device.Name != null)
                        nameDevice = device.Name;
                }

                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString); 
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();

                timer1.Start();
            }
            else // chuyển đổi sang chọn thủ công
            {
                if(videoCaptureDevice != null)
                {
                    if (videoCaptureDevice.IsRunning)
                        videoCaptureDevice.Stop();
                }    
                panelChoose.Visible = true;
                panelScan.Visible = false;
                picBarCode.Visible = false;
                btnSwitch.Text = "Chuyển đổi sang quét mã BarCode";
            }    
        }
        Bitmap bitmap;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmap = (Bitmap)eventArgs.Frame.Clone();
            picBarCode.Image = bitmap;
        }


        private void LoadBarcode()
        {
            Bitmap imgBarCode = (Bitmap)picBarCode.Image;
            if (imgBarCode != null)
            {

                ZXing.BarcodeReader Reader = new ZXing.BarcodeReader();
                Result result = Reader.Decode(imgBarCode);
                string decoded = result.ToString();//.Trim();
                txtDiscount.Text = decoded;
                imgBarCode.Dispose();

                
            }
        }

        private void fbanHang_Load(object sender, EventArgs e)
        {
            newSoldier = new KhachHang();
            labIdNhanVien.Text = idStaff;

            loadComboBoxs();

            createColDGV();
        }

        private void createColDGV()
        {
            dgvAddProduct.ColumnCount = 5;
            dgvAddProduct.Columns[0].Name = "Mã sản phẩm";
            dgvAddProduct.Columns[0].ReadOnly = true;
            dgvAddProduct.Columns[1].Name = "Tên sản phẩm";
            dgvAddProduct.Columns[1].ReadOnly = true;
            dgvAddProduct.Columns[2].Name = "Số lượng";
            dgvAddProduct.Columns[2].ReadOnly = true;
            dgvAddProduct.Columns[3].Name = "Đơn giá";
            dgvAddProduct.Columns[3].ReadOnly = true;
            dgvAddProduct.Columns[4].Name = "Thành tiền";
            dgvAddProduct.Columns[4].ReadOnly = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (panelChoose.Visible == true)
            {
                SanPham item = SanPhamDAO.Instance.SearchProductWithName(comboBoxProduct.Text);

                for (int i = 0; i < dgvAddProduct.Rows.Count - 1; i++)
                {
                    if (dgvAddProduct.Rows[i].Cells[0].Value.ToString() == item.MaSP)
                    {
                        dgvAddProduct.Rows[i].Cells[2].Value = int.Parse(dgvAddProduct.Rows[i].Cells[2].Value.ToString())  + 1;
                        dgvAddProduct.Rows[i].Cells[4].Value = double.Parse(dgvAddProduct.Rows[i].Cells[4].Value.ToString()) * 2;
                        return;
                    }
                }
                dgvAddProduct.Rows.Add(item.MaSP, item.TenSP, "1", item.DonGiaSP, item.DonGiaSP);
            }
        }

        private void dgvAddProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (dgvAddProduct.Rows[e.RowIndex].Cells[0].Value == null ||
            //    dgvAddProduct.Rows[e.RowIndex].Cells[1].Value == null ||
            //    dgvAddProduct.Rows[e.RowIndex].Cells[2].Value == null ||
            //    dgvAddProduct.Rows[e.RowIndex].Cells[3].Value == null) return;

            double sumMoney = 0;
            for (int i = 0; i < dgvAddProduct.Rows.Count - 1; i++)
            {
                sumMoney += double.Parse(dgvAddProduct.Rows[i].Cells[4].Value.ToString());
            }
            txtSumMoney.Text = sumMoney.ToString();
        }

        private void dgvAddProduct_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sumMoney = 0;
            for (int i = 0; i < dgvAddProduct.Rows.Count - 1; i++)
            {
                sumMoney += double.Parse(dgvAddProduct.Rows[i].Cells[4].Value.ToString());
            }
            txtSumMoney.Text = sumMoney.ToString();
        }

        private void dgvAddProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double sumMoney = 0;
            for (int i = 0; i < dgvAddProduct.Rows.Count - 1; i++)
            {
                sumMoney += double.Parse(dgvAddProduct.Rows[i].Cells[4].Value.ToString());
            }
            txtSumMoney.Text = sumMoney.ToString();
        }

        private void txtSumMoney_TextChanged(object sender, EventArgs e)
        {
            double payMoneyPerson = double.Parse(txtSumMoney.Text) * (100 - double.Parse(txtDiscount.Text));
            txtMoneyOfPerson.Text = (payMoneyPerson / 100).ToString();
        }

        private void txtMoneyGivenByPerson_TextChanged(object sender, EventArgs e)
        {
            if (txtMoneyGivenByPerson.Text == "")
                return;
            txtExcessCash.Text = (double.Parse(txtMoneyGivenByPerson.Text) - double.Parse(txtMoneyOfPerson.Text)).ToString();
        }

        private void txtExcessCash_Leave(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtExcessCash.Text, System.Globalization.NumberStyles.AllowThousands);
            txtExcessCash.Text = String.Format(culture, "{0:N0}", value);
            txtExcessCash.Select(txtExcessCash.Text.Length, 0);
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
        private void btnAddPerson_Click(object sender, EventArgs e)
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
            loadComboBoxs();
            comboboxPerson.SelectedIndex = comboboxPerson.Items.Count - 1;
        }
        private void loadComboBoxs()
        {
            List<KhachHang> customerList = KhachHangDAO.Instance.LoadCustomerList();
            List<SanPham> productList = SanPhamDAO.Instance.LoadProductList_MaySell();

            comboboxPerson.DataSource = customerList;
            comboboxPerson.DisplayMember = "TenKH";

            comboBoxProduct.DataSource = productList;
            comboBoxProduct.DisplayMember = "TenSP";
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            dgvAddProduct.Rows.Clear();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPham spSearch = SanPhamDAO.Instance.SearchProductWithName(comboBoxProduct.Text);
            picImageProduct.Image = Image.FromFile(spSearch.LinkSP);
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtMoneyOfPerson.Text = txtSumMoney.Text;
                return;
            }    
            double payMoneyPerson = double.Parse(txtSumMoney.Text) * (100 - double.Parse(txtDiscount.Text));
            txtMoneyOfPerson.Text = (payMoneyPerson / 100).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMoneyGivenByPerson.Text == "") return;
            if (dgvAddProduct.Rows.Count < 0) return;
            if (dgvAddProduct.Rows[0].Cells[0].Value == null) return;

            //Lưu hóa đơn trước
            bool a = false, b = false;
            List<HoaDon> billList = HoaDonDAO.Instance.LoadBillList();
            string idBillNew = (int.Parse(billList[billList.Count - 1].MaHD) + 1).ToString();
            KhachHang khID = KhachHangDAO.Instance.SearchCustomer_WithName(comboboxPerson.Text);
            if (HoaDonDAO.Instance.InsertBill(idBillNew, DateTime.Now.ToString("dd/mm/yyyy"), khID.MaKH, labIdNhanVien.Text, txtMoneyOfPerson.Text, txtNote.Text)) 
                a = true;
            for (int i = 0; i < dgvAddProduct.Rows.Count - 1; i++)
            {
                if (ChiTietHoaDonDAO.Instance.InsertBillDetail(idBillNew, dgvAddProduct.Rows[i].Cells[0].Value.ToString(), dgvAddProduct.Rows[i].Cells[2].Value.ToString())) ;
                b = true;
            }
            if (a == true && b == true)
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK);
            //---------------------

            //Truyền mã hóa đơn mới lưu sang formPrint
            fPrint printBill = new fPrint(idBillNew, txtDiscount.Text, txtMoneyGivenByPerson.Text);
            printBill.ShowDialog();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            if (bitmap != null)
            {
                Result result = Reader.Decode(bitmap);
                if (result != null)
                {
                    
                    SanPham spScan = SanPhamDAO.Instance.SearchProduct(result.ToString().Trim());
                    if (spScan != null)
                    {
                        DialogResult aa = MessageBox.Show(spScan.TenSP, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (aa == DialogResult.OK)
                        {
                            bool ProductAdded = false;
                            for (int i = 0; i < dgvAddProduct.Rows.Count - 1; i++)
                            {
                                if (dgvAddProduct.Rows[i].Cells[0].Value.ToString() == spScan.MaSP)
                                {
                                    dgvAddProduct.Rows[i].Cells[2].Value = int.Parse(dgvAddProduct.Rows[i].Cells[2].Value.ToString()) + 1;
                                    dgvAddProduct.Rows[i].Cells[4].Value = double.Parse(dgvAddProduct.Rows[i].Cells[4].Value.ToString()) * 2;
                                    ProductAdded = true;
                                    break;
                                }
                            }
                            if(ProductAdded == false ) dgvAddProduct.Rows.Add(spScan.MaSP, spScan.TenSP, "1", spScan.DonGiaSP, spScan.DonGiaSP);
                        }
                    }
                }
            }
        }


        private void dgvAddProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.RowIndex > dgvAddProduct.Rows.Count) return;
            //if (dgvAddProduct.Rows[e.RowIndex].Cells[0].Value == null ||
            //    dgvAddProduct.Rows[e.RowIndex].Cells[1].Value == null ||
            //    dgvAddProduct.Rows[e.RowIndex].Cells[2].Value == null ||
            //    dgvAddProduct.Rows[e.RowIndex].Cells[3].Value == null) return;

            //if (e.ColumnIndex == 2)
            //{
            //    int gps = e.RowIndex;
            //    dgvAddProduct.Rows[gps].Cells[4].Value = double.Parse(dgvAddProduct.Rows[gps].Cells[3].Value.ToString()) * 2;
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBarCode_Click(object sender, EventArgs e)
        {

        }
    }
}
