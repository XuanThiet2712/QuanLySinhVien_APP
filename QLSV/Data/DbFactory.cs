using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using QLSV.Helpers;

namespace QLSV.Data
{
    // Mỗi hàm Service gọi DbFactory.Create() đúng một lần
    // bọc trong using, rồi truyền DataContext đó xuống các Repository
    public static class DbFactory
    {
        public static QLSVDataContext Create()
        {
            string cs = AppConfig.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
            {
                throw new InvalidOperationException(
                    "Chưa có chuỗi kết nối \"QLSV\" trong App.config. " +
                    "Hãy kiểm tra thẻ <connectionStrings>.");
            }
            return new QLSVDataContext(cs);
        }
    }
}