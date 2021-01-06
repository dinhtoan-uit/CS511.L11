using Do_An_Cuoi_Ki.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DAO
{
    class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        internal static ChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonDAO();
                return ChiTietHoaDonDAO.instance;
            }
            private set => instance = value;
        }
        private ChiTietHoaDonDAO() { }
        public List<ChiTietHoaDon> LoadCTHDList()
        {
            List<ChiTietHoaDon> CTHDList = new List<ChiTietHoaDon>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT* FROM CTHD");
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDon CTHD = new ChiTietHoaDon(item);
                CTHDList.Add(CTHD);
            }
            return CTHDList;
        }
        public List<ChiTietHoaDon> LoadCTHDList(string idHD)
        {
            List<ChiTietHoaDon> CTHDList = new List<ChiTietHoaDon>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT* FROM CTHD WHERE SOHD = " + idHD);
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDon CTHD = new ChiTietHoaDon(item);
                CTHDList.Add(CTHD);
            }
            return CTHDList;
        }
        public List<ChiTietHoaDon> searchBillDetail(string idHD)
        {
            List<ChiTietHoaDon> CTHDList = new List<ChiTietHoaDon>();
            List<ChiTietHoaDon> loadBillDetail = ChiTietHoaDonDAO.instance.LoadCTHDList();
            foreach (ChiTietHoaDon item in loadBillDetail)
            {
                if(item.MaHD == idHD)
                {
                    CTHDList.Add(item);
                }    
            }
            return CTHDList;
        }
        public bool InsertBillDetail(string idBill, string idProduct, string soLuong)
        {
            string query = string.Format("INSERT dbo.CTHD VALUES ( '{0}', '{1}', {2})",
                                                                idBill, idProduct, soLuong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //public bool DeleteBillDetailWithIdBill(string idBill)
        //{
        //    string query = string.Format("DELETE FROM CHITIETHOADON WHERE MaHoaDon = '{0}'", idBill);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return result > 0;
        //}
        //public bool DeleteBillDetailWithIdYogurt(string idyogurt)
        //{
        //    string query = string.Format("DELETE FROM CHITIETHOADON WHERE MaHang = '{0}'", idyogurt);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return result > 0;
        //}
        public DataTable TopProductBusiness()
        {
            
            DataTable data = DataProvider.Instance.ExcuteQuery("select top 3 sum(SL) SLBANRA, SANPHAM.TENSP" +
                                                                " from SANPHAM, CTHD" +
                                                                " where SANPHAM.MASP = CTHD.MASP" +
                                                                " group by TENSP" +
                                                                " order by sum(SL) desc");
            return data;
        }
    }
}
