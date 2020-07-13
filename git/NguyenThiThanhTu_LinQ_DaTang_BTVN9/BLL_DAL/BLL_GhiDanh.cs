using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BLL_DAL
{
    public class BLL_GhiDanh
    {
        QLGDDataContext qlgd = new QLGDDataContext();
        public BLL_GhiDanh()
        {

        }
        public IQueryable<MonHoc> layMonHoc()
        {
            return qlgd.MonHocs.Select(mh => mh);
        }
        public bool kTraKhoaChinh(string ma)
        {
            GhiDanh gh = qlgd.GhiDanhs.Where(g => g.maGhiDanh == ma).FirstOrDefault();
            if (gh == null)
                return true;
            else
                return false;
        }
        public void them_GhiDanh(string ma,string hoten, string ngaysinh,string gioitinh, string dt, string email, string maMh, int buoihoc, bool thiXL)
        {
            GhiDanh gh = new GhiDanh();
            gh.maGhiDanh = ma;
            gh.hoVaTen = hoten;
            gh.ngaySinh = DateTime.Parse(ngaysinh);
            gh.gioiTinh = gioitinh;
            gh.dienThoai = dt;
            gh.email = email;
            gh.maMonHoc = maMh;
            gh.buoiHoc = buoihoc;
            gh.thiXepLoai = thiXL;

            qlgd.GhiDanhs.InsertOnSubmit(gh);
            qlgd.SubmitChanges();
        }
    }
}
