using Do_An_Cuoi_Ki.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DAO
{
    class SanPhamDAO
    {
        private static SanPhamDAO instance;

        internal static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamDAO();
                return SanPhamDAO.instance;
            }
            private set => instance = value;
        }
        private SanPhamDAO() { }
        public List<SanPham> LoadProductList()
        {
            List<SanPham> SanPhamList = new List<SanPham>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT* FROM SANPHAM");
            foreach (DataRow item in data.Rows)
            {
                SanPham sanPham = new SanPham(item);
                SanPhamList.Add(sanPham);
            }
            return SanPhamList;
        }
        public int GetMaxIdProduct()
        {
            int idMax = 0;
            List<SanPham> SanPhamList = SanPhamDAO.instance.LoadProductList();
            foreach (SanPham item in SanPhamList)
            {
                int id = int.Parse(item.MaSP.Substring(2));
                if (id > idMax)
                    idMax = id;
            }
            return idMax;
        }
        public bool InsertProduct(string MaSP, string TenSP, string DVT, string NuocSX, float DonGiaSP, string LinkSP)
        {
            string query = string.Format("INSERT dbo.SANPHAM VALUES ( '{0}', N'{1}', N'{2}', N'{3}', {4}, '{5}', 'Được bán')",
                                                                MaSP, TenSP, DVT, NuocSX, DonGiaSP, LinkSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusOfProduct_End(string MaSP)
        {
            string query = string.Format("UPDATE dbo.SANPHAM SET TRANGTHAI = N'Ngưng bán' WHERE MASP = '{0}'", MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusOfProduct_Begin(string MaSP)
        {
            string query = string.Format("UPDATE dbo.SANPHAM SET TRANGTHAI = N'Được bán' WHERE MASP = '{0}'", MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public SanPham SearchProduct(string idProduct)
        {
            if (idProduct == null) return null;
            SanPham sp = new SanPham();
            sp.MaSP = idProduct;
            List<SanPham> spList = SanPhamDAO.Instance.LoadProductList();
            foreach (SanPham item in spList)
            {
                if (item.MaSP == sp.MaSP)
                {
                    sp.TenSP = item.TenSP;
                    sp.DVT = item.DVT;
                    sp.NuocSX = item.NuocSX;
                    sp.DonGiaSP = item.DonGiaSP;
                    sp.LinkSP = item.LinkSP;
                }
            }
            if (sp.DonGiaSP == null) return null;
            return sp;
        }
        public SanPham SearchProductWithName(string nameProduct)
        {
            SanPham sp = new SanPham();
            sp.TenSP = nameProduct;
            List<SanPham> productList = SanPhamDAO.Instance.LoadProductList();
            foreach (SanPham item in productList)
            {
                if (item.TenSP == sp.TenSP)
                {
                    sp.MaSP = item.MaSP;
                    sp.DVT = item.DVT;
                    sp.NuocSX = item.NuocSX;
                    sp.DonGiaSP = item.DonGiaSP;
                    sp.LinkSP = item.LinkSP;
                }
            }
            return sp;
        }

        public List<SanPham> filterDVTProductList()
        {
            List<SanPham> SanPhamList = new List<SanPham>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from SANPHAM order by DVT asc");
            foreach (DataRow item in data.Rows)
            {
                SanPham sanPham = new SanPham(item);
                SanPhamList.Add(sanPham);
            }
            return SanPhamList;
        }
        public List<SanPham> filterProduceProductList()
        {
            List<SanPham> SanPhamList = new List<SanPham>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from SANPHAM order by NUOCSX asc");
            foreach (DataRow item in data.Rows)
            {
                SanPham sanPham = new SanPham(item);
                SanPhamList.Add(sanPham);
            }
            return SanPhamList;
        }
        public List<SanPham> LoadProductList_MaySell()
        {
            List<SanPham> SanPhamList = new List<SanPham>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT* FROM SANPHAM WHERE TRANGTHAI = N'Được bán'");
            foreach (DataRow item in data.Rows)
            {
                SanPham sanPham = new SanPham(item);
                SanPhamList.Add(sanPham);
            }
            return SanPhamList;
        }
        public DataTable TopProductExpensive()
        {

            DataTable data = DataProvider.Instance.ExcuteQuery("select TOP 3 SUM(SL * GIA) TONG, TENSP, SANPHAM.MASP" +
                                                                " from SANPHAM, CTHD" +
                                                                " where SANPHAM.MASP = CTHD.MASP" +
                                                                " group by TENSP, SANPHAM.MASP" +
                                                                " order by SUM(SL * GIA) desc");
            return data;
        }
    }
}
