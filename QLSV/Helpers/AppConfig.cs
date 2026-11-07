using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QLSV.Helpers
{
    // Đọc cấu hình từ App.config
    //D bổ sung Save(...) và TestConnection(...) cho frmConnectionConfig
    public static class AppConfig
    {
        //Chuỗi kết nối tới CSDL QLSV ,khóa "QLSV" trong App.config
        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["QLSV"];
                return cs == null ? null : cs.ConnectionString;
            }
        }
    }
}