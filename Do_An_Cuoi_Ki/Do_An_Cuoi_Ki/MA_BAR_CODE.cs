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
using BarcodeLib;
using ZXing;

namespace Do_An_Cuoi_Ki
{
    public partial class MA_BAR_CODE : Form
    {
        public MA_BAR_CODE()
        {
            InitializeComponent();
        }
        BarcodeLib.Barcode code128;

        private ImageList displayBarcode()
        {
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(180, 45);
            List<SanPham> spList = SanPhamDAO.Instance.LoadProductList();
            foreach(SanPham item in spList)
            {
                Image barcode = code128.Encode(BarcodeLib.TYPE.CODE128, item.MaSP);
                imgs.Images.Add(barcode);
            }    
            
            return imgs;
        }
        private void MA_BAR_CODE_Load(object sender, EventArgs e)
        {
            code128 = new Barcode();

            List<SanPham> spList = SanPhamDAO.Instance.LoadProductList();

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "MA";

            foreach (SanPham item in spList)
            {
                dataGridView1.Rows.Add(item.MaSP);
            }    
                listView1.SmallImageList = displayBarcode();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), i);
            }
        }
    }
}
