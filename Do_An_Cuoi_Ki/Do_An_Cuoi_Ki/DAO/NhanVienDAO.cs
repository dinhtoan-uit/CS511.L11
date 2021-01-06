using Do_An_Cuoi_Ki.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Cuoi_Ki.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return NhanVienDAO.instance;
            }
            private set
            {
                NhanVienDAO.instance = value;
            }
        }
        private NhanVienDAO() { }
        public List<NhanVien> LoadEmployeeList()
        {
            List<NhanVien> nhanVienList = new List<NhanVien>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT* FROM NHANVIEN");
            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanVien = new NhanVien(item);
                nhanVienList.Add(nhanVien);
            }
            return nhanVienList;
        }
        public bool InsertEmployee(string MaNV, string NameNV, string DienThoai, string NgayVaoLam)
        {
            string query = string.Format("INSERT dbo.NHANVIEN VALUES ( '{0}', N'{1}', '{2}', '{3}')",
                                                                MaNV, NameNV, DienThoai, NgayVaoLam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //public bool UpdateEmployee(string MaNV, string NameNV, string DienThoai, string NgayVaoLam)
        //{
        //    string query = string.Format("UPDATE dbo.NHANVIEN SET TenNhanVien = N'{0}', DienThoai = '{1}', NgaySinh = '{2}' WHERE MaNhanVien = '{3}'",
        //                                  NameNV, DienThoai, NgayVaoLam, MaNV);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return result > 0;
        //}
        //public bool DeleteEmployee(string idNV)
        //{

        //    //Xóa Chi tiết hóa đơn liên quan tới nhân viên.
        //    HoaDon billOfEmployee = HoaDonDAO.Instance.SearchHoaDonWithIdEmployee(idNV);
        //    ChiTietHoaDonDAO.Instance.DeleteBillDetailWithIdBill(billOfEmployee.MaHD);

        //    //Xóa hóa đơn liên quan tới nhân viên.
        //    HoaDonDAO.Instance.DeleteBillWithIdBill(billOfEmployee.MaHD);

        //    //Xóa Nhân Viên.
        //    string query = string.Format("DELETE FROM NHANVIEN WHERE MaNhanVien = '{0}'", idNV);
        //    int resultDeleteEmployee = DataProvider.Instance.ExecuteNonQuery(query);

        //    return resultDeleteEmployee > 0;
        //}
        public int GetMaxIdEmployee()
        {
            int idmax = 0;
            List<NhanVien> nhanVienList = NhanVienDAO.Instance.LoadEmployeeList();
            foreach (NhanVien item in nhanVienList)
            {
                int id = int.Parse(item.MaNV.Substring(2));
                if (id > idmax)
                    idmax = id;
            }
            return idmax;
        }
        public NhanVien SearchEmployee(string idEmployee)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNV = idEmployee;
            List<NhanVien> nhanVienList = NhanVienDAO.Instance.LoadEmployeeList();
            foreach (NhanVien item in nhanVienList)
            {
                if (nhanVien.MaNV == item.MaNV)
                {
                    nhanVien.NameNV = item.NameNV;
                    nhanVien.NgayVaoLam = item.NgayVaoLam;
                    nhanVien.DienThoai = item.DienThoai;
                }
            }
            return nhanVien;
        }
        public NhanVien SearchEmployee_WithName(string nameEmployee)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.NameNV = nameEmployee;
            List<NhanVien> nhanVienList = NhanVienDAO.Instance.LoadEmployeeList();
            foreach (NhanVien item in nhanVienList)
            {
                if (nhanVien.NameNV == item.NameNV)
                {
                    nhanVien.MaNV = item.MaNV;
                    nhanVien.NgayVaoLam = item.NgayVaoLam;
                    nhanVien.DienThoai = item.DienThoai;

                }
            }
            return nhanVien;
        }
        public DataTable Top3Employee()
        {

            DataTable data = DataProvider.Instance.ExcuteQuery("select top 3 with ties SUM(TRIGIA) TONG, HOTEN, NHANVIEN.MANV" +
                                                                " from NHANVIEN, HOADON" +
                                                                " where NHANVIEN.MANV = HOADON.MANV" +
                                                                " group by NHANVIEN.MANV, HOTEN" +
                                                                " order by SUM(TRIGIA) desc");
            return data;
        }
    }
}
