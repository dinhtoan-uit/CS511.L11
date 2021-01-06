using Do_An_Cuoi_Ki.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Do_An_Cuoi_Ki
{
    public partial class fBaoCao : Form
    {
        public fBaoCao()
        {
            InitializeComponent();
        }
        private void drawChart()
        {
            chartLine.Series.Clear();

            chartLine.Series.Add(comboBoxReport.Text);

            Random randd = new Random();
            for(int i =0; i < dgvReport.Rows.Count -1; i++)
            {
                
                chartLine.Series[comboBoxReport.Text].Color = Color.FromArgb(randd.Next(256), randd.Next(256), randd.Next(256));
                chartLine.Series[comboBoxReport.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

                chartLine.Series[comboBoxReport.Text].Points.AddXY(dgvReport.Rows[i].Cells[1].Value.ToString(), dgvReport.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void fBaoCao_Load(object sender, EventArgs e)
        {
            drawChart();
            TongDoanhThu();
            TongLoiNhuan();
            TySuat();
        }
        private void TongDoanhThu()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   
            labDoanhThu.Text = HoaDonDAO.Instance.TongDoanhThu().ToString("#,###", cul.NumberFormat) +" vnđ";
        }
        private void TongLoiNhuan()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double Tong = HoaDonDAO.Instance.TongDoanhThu() - KhachHangDAO.Instance.TongTienTra();
            labLoiNhuan.Text = Tong.ToString("#,###", cul.NumberFormat) + " vnđ"; 
        }
        private void TySuat()
        {
            double Tong = 100 - (KhachHangDAO.Instance.TongTienTra() / HoaDonDAO.Instance.TongDoanhThu())* 100;
            LabTySuat.Text = Tong.ToString("0.00") + " %";
        }

        private void comboBoxReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.Rows.Clear();
            //---------------------------------------------------------
            if (comboBoxReport.SelectedIndex == 0)
            {
                dgvReport.ColumnCount = 3;
                dgvReport.Columns[0].Name = "Tổng tiền bán";
                dgvReport.Columns[1].Name = "Tên sản phẩm";
                dgvReport.Columns[2].Name = "Mã sản phẩm";

                dgvReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                DataTable data = SanPhamDAO.Instance.TopProductExpensive();
                foreach (DataRow item in data.Rows)
                {
                    String str = item["TONG"].ToString();
                    dgvReport.Rows.Add(str, item["TENSP"].ToString(), item["MASP"].ToString());
                }//double.Parse(str).ToString("#,###", cul.NumberFormat)
                drawChart();
            }    
            if(comboBoxReport.SelectedIndex == 1)
            {
                dgvReport.ColumnCount = 2;
                dgvReport.Columns[0].Name = "Số lượng bán ra";
                dgvReport.Columns[1].Name = "Tên sản phẩm";

                dgvReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataTable data = ChiTietHoaDonDAO.Instance.TopProductBusiness();
                foreach (DataRow item in data.Rows)
                {
                    dgvReport.Rows.Add(item["SLBANRA"].ToString(),item["TENSP"].ToString());
                }
                drawChart();
            } 
            if(comboBoxReport.SelectedIndex == 2)
            {
                dgvReport.ColumnCount = 3;
                dgvReport.Columns[0].Name = "Tiền khách bỏ ra";
                dgvReport.Columns[1].Name = "Tên khách hàng";
                dgvReport.Columns[2].Name = "Mã khách hàng";

                dgvReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                DataTable data = KhachHangDAO.Instance.Top3Customer();
                foreach (DataRow item in data.Rows)
                {
                    String str = item["DOANHSO"].ToString();
                    dgvReport.Rows.Add(str, item["HOTEN"].ToString(), item["MAKH"].ToString() );
                }
                drawChart();
            }    
            if(comboBoxReport.SelectedIndex == 3)
            {
                dgvReport.ColumnCount = 3;
                dgvReport.Columns[0].Name = "Doanh số";
                dgvReport.Columns[1].Name = "Tên nhân viên";
                dgvReport.Columns[2].Name = "Mã nhân viên";

                dgvReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                DataTable data = NhanVienDAO.Instance.Top3Employee();
                foreach (DataRow item in data.Rows)
                {
                    String str = item["TONG"].ToString();
                    dgvReport.Rows.Add(str, item["HOTEN"].ToString(), item["MANV"].ToString());
                }
                drawChart();
            }    
        }

        private void chartLine_Click(object sender, EventArgs e)
        {

        }
    }
}
