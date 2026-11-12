using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Helpers
{
    // Đọc cấu hình từ App.config
    //D bổ sung Save(...) và TestConnection(...) cho frmConnectionConfig
    public static class AppConfig
    {
        //Chuỗi kết nối tới CSDL QLSV ,khóa "QLSV" trong App.config
        // mở file App.config, tìm thẻ <add name="QLSV" ... 
        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["QLSV"];
                return cs == null ? null : cs.ConnectionString;
            }
        }
        public static Result TestConnection(string server, string db, bool winAuth, string user, string pass)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = db;
            builder.IntegratedSecurity = winAuth;
            builder.ConnectTimeout = 5;

            if (winAuth == false)
            {
                builder.UserID = user;
                builder.Password = pass;
            }

            try
            {
                using (var conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                }
                return Result.Ok("Kết nối CSDL thành công!");
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi kết nối: " + ex.Message);
            }
        }

       //Ghi chuỗi kết nối mới vào App.config (khóa "QLSV")
        public static Result Save(string server, string db, bool winAuth, string user, string pass)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.InitialCatalog = db;
                builder.IntegratedSecurity = winAuth;

                if (winAuth == false)
                {
                    builder.UserID = user;
                    builder.Password = pass;
                }

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["QLSV"].ConnectionString = builder.ConnectionString;
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("connectionStrings");

                return Result.Ok("Đã lưu cấu hình kết nối CSDL!");
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi lưu cấu hình: " + ex.Message);
            }
        }
    }
}