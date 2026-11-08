using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using QLSV.Data;

namespace QLSV.Repositories
{
    //Đọc bảng PhanQuyen 
    public class PhanQuyenRepository
    {
        private readonly QLSVDataContext _db;

        public PhanQuyenRepository(QLSVDataContext db)
        {
            _db = db;
        }

        //Danh sách mã chức năng  mà nhóm dc dược phân quyền
        public List<string> GetMaChucNangByNhom(string maNhom)
        {
            return _db.PhanQuyens
                      .Where(p => p.MaNhom == maNhom)
                      .Select(p => p.MaCN)
                      .ToList();
        }
    }
}