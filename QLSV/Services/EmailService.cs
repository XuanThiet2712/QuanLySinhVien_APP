using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using QLSV.Helpers;

namespace QLSV.Services
{
    public class EmailService
    {
        public Result Gui(string den, string tieuDe, string noiDung)
        {
            string user = ConfigurationManager.AppSettings["SmtpUser"];
            string pass = ConfigurationManager.AppSettings["SmtpPass"];
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                return Result.Fail("Chưa cấu hình SmtpUser và SmtpPass trong App.config.");

            try
            {
                using (var msg = new MailMessage(user, den, tieuDe, noiDung))
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    msg.SubjectEncoding = Encoding.UTF8;
                    msg.BodyEncoding = Encoding.UTF8;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(user, pass);
                    smtp.Send(msg);
                }
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Không gửi được email: " + ex.Message);
            }
        }
    }
}