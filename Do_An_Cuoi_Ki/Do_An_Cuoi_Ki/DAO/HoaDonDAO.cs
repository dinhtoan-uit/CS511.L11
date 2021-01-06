using Do_An_Cuoi_Ki.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DAO
{
    class HoaDonDAO
    {
        private static HoaDonDAO instance;

        internal static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonDAO();
                return HoaDonDAO.instance;
            }
            private set => instance = value;
        }
        private HoaDonDAO() { }

        public List<HoaDon> LoadBillList()
        {
            List<HoaDon> hoaDonList = new List<HoaDon>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT* FROM HOADON");
            foreach (DataRow item in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(item);
                hoaDonList.Add(hoaDon);
            }
            return hoaDonList;
        }
        public int GetMaxIdBill()
        {
            int id = 0;
            List<HoaDon> hoaDonList = HoaDonDAO.instance.LoadBillList();
            foreach (HoaDon item in hoaDonList)
            {
                if (int.Parse(item.MaHD) > id)
                    id = int.Parse(item.MaHD);
            }
            return id;
        }
        //public bool DeleteBillWithIdBill(string idBill)
        //{
        //    string query = string.Format("DELETE FROM HOADON WHERE MaHoaDon = '{0}'", idBill);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return result > 0;
        //}
        public bool InsertBill(string idBill, string date, string idKH, string idNV, string tongTien, string ghiChu)
        {
            string query = string.Format("INSERT dbo.HOADON VALUES ( '{0}', '{1}', '{2}', '{3}', {4}, N'{5}')",
                                                                idBill, date, idKH, idNV, tongTien, ghiChu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //public bool UpdatetBill(string idBill, string date, string idKH, string idNV, float tongTien)
        //{
        //    string query = string.Format("UPDATE dbo.HOADON SET MaNhanVien = '{0}', NgayBan = {1}, MaKhach = '{2}', TongTien = {3} WHERE MaHoaDon = '{4}'",
        //                                    idBill, date, idKH, idNV, tongTien);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return result > 0;
        //}
        //public bool DeleteBill()
        //{
        //    //string query = string.Format("DELETE FROM HOADON WHERE MaNhanVien = '{0}'");
        //    //int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return true;
        //}
        public HoaDon SearchHoaDon(string idHoaDon)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaHD = idHoaDon;
            List<HoaDon> hoaDonList = HoaDonDAO.Instance.LoadBillList();
            foreach (HoaDon item in hoaDonList)
            {
                if (item.MaHD == hoaDon.MaHD)
                {
                    hoaDon.MaNV = item.MaNV;
                    hoaDon.NgayBan = item.NgayBan;
                    hoaDon.MaKhach = item.MaKhach;
                    hoaDon.TongTien = item.TongTien;
                    hoaDon.GhiChu = item.GhiChu;
                }
            }
            return hoaDon;
        }
        public HoaDon SearchHoaDonWithIdEmployee(string idEmployee)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaNV = idEmployee;
            List<HoaDon> hoaDonList = HoaDonDAO.Instance.LoadBillList();
            foreach (HoaDon item in hoaDonList)
            {
                if (item.MaNV == hoaDon.MaNV)
                {
                    hoaDon.MaHD = item.MaHD;
                    hoaDon.NgayBan = item.NgayBan;
                    hoaDon.MaKhach = item.MaKhach;
                    hoaDon.TongTien = item.TongTien;
                    hoaDon.GhiChu = item.GhiChu;
                }
            }
            return hoaDon;
        }
        public HoaDon SearchHoaDonWithIdCustomer(string idCustomer)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaKhach = idCustomer;
            List<HoaDon> hoaDonList = HoaDonDAO.Instance.LoadBillList();
            foreach (HoaDon item in hoaDonList)
            {
                if (item.MaKhach == hoaDon.MaKhach)
                {
                    hoaDon.MaHD = item.MaHD;
                    hoaDon.NgayBan = item.NgayBan;
                    hoaDon.MaNV = item.MaNV;
                    hoaDon.TongTien = item.TongTien;
                    hoaDon.GhiChu = item.GhiChu;
                }
            }
            return hoaDon;
        }
        public double TongDoanhThu()
        {
            double sum = 0;
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT SUM(TRIGIA) FROM HOADON");
            foreach (DataRow item in data.Rows)
                sum = double.Parse(data.Rows[0][0].ToString());
            return sum;
        }
    }
}
