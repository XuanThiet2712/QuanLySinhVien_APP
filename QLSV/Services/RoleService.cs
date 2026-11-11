using QLSV.Data;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public class RoleService
    {
        public List<NhomQuyen> GetAllNhom()
        {
            using (var db = DbFactory.Create())
            {
                return new NhomQuyenRepository(db).GetAllNhom();
            }
        }

        public List<ChucNang> GetAllChucNang()
        {
            using (var db = DbFactory.Create())
            {
                return new NhomQuyenRepository(db).GetAllChucNang();
            }
        }

        public List<string> GetQuyenCuaNhom(string maNhom)
        {
            using (var db = DbFactory.Create())
            {
                return new PhanQuyenRepository(db).GetMaChucNangByNhom(maNhom);
            }
        }

        public Result LuuQuyen(string maNhom, List<string> dsMaCN)
        {
            if (!SessionManager.HasPermission(MaChucNang.QL_ROLE))
                return Result.Fail("Bạn không có quyền phân quyền.");
            if (string.IsNullOrEmpty(maNhom)) return Result.Fail("Vui lòng chọn nhóm quyền.");

            dsMaCN = (dsMaCN ?? new List<string>()).Distinct().ToList();

            // ADMIN phải giữ 2 quyền này, nếu không sẽ không ai
            // vào được form phân quyền nữa
            if (maNhom == MaNhom.ADMIN
                && (!dsMaCN.Contains(MaChucNang.QL_USER) || !dsMaCN.Contains(MaChucNang.QL_ROLE)))
                return Result.Fail("Nhóm ADMIN phải giữ quyền Quản lý người dùng và Phân quyền.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var nhomRepo = new NhomQuyenRepository(db);
                    if (!nhomRepo.ExistsNhom(maNhom)) return Result.Fail("Không tìm thấy nhóm quyền.");
                    if (nhomRepo.LocMaChucNangHopLe(dsMaCN).Count != dsMaCN.Count)
                        return Result.Fail("Có mã chức năng không hợp lệ.");

                    new PhanQuyenRepository(db).SetQuyen(maNhom, dsMaCN);
                    db.SubmitChanges();
                }

                // Vừa sửa quyền của chính nhóm mình
                // thì cập nhật luôn session hiện tại.
                if (SessionManager.IsInRole(maNhom))
                    SessionManager.Login(SessionManager.CurrentUser, dsMaCN);

                return Result.Ok("Đã lưu phân quyền. Người dùng đang đăng nhập cần đăng nhập lại để áp dụng.");
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            
            }
    }
}
}
