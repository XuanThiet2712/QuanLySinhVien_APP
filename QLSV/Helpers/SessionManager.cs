using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;

namespace QLSV.Helpers
{
    // Quản lý session người dùng hiện tại
    public static class SessionManager
    {
        //quyen của người dùng hiện tại, vd : QL_USER, QL_ROLE, QL_KHOA, ...
        private static HashSet<string> _quyen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        ///Người dùng đang đăng nhập ,null nếu chưa đăng nhập
        public static NguoiDung CurrentUser { get; private set; }

        //check đăng nhập hay chưa, vd : if (!SessionManager.IsLoggedIn) { ... }
        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        //Lưu session sau khi đăng nhập thành công
        public static void Login(NguoiDung user, IEnumerable<string> dsQuyen)
        {
            CurrentUser = user;
            if (dsQuyen == null)
            {
                dsQuyen = new string[0];
            }

            _quyen = new HashSet<string>(dsQuyen,StringComparer.OrdinalIgnoreCase);
        }

        //Xóa session khi đăng xuất
        public static void Logout()
        {
            CurrentUser = null;
            _quyen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

  
        // Người dùng hiện tại có quyền này không?
        // Dùng để ẩn/hiện (Visible) hoặc bật/tắt (Enabled) menu và nút
        // vd : btnXoa.Enabled = SessionManager.HasPermission(MaChucNang.QL_KHOA)

        public static bool HasPermission(string maChucNang)
        {
            return CurrentUser != null 
                && maChucNang != null 
                && _quyen.Contains(maChucNang);
        }

        //Người dùng hiện tại thuộc nhóm này không?
        //vd  IsInRole(MaNhom.GV)
        public static bool IsInRole(string maNhom)
        {
            return CurrentUser != null 
                && string.Equals(CurrentUser.MaNhom, maNhom, 
                StringComparison.OrdinalIgnoreCase);
        }
    }
}