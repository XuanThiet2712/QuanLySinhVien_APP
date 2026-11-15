using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QRCoder;

namespace QLSV.Helpers
{
    public static class VietQrHelper
    {
        private const string BANK_ID = "MB";
        private const string BANK_BIN = "970422"; 
        private const string SO_TAI_KHOAN = "70003690701";
        private const string TEN_TAI_KHOAN = "NGUYEN XUAN THIET";
        private const string TEMPLATE = "compact2";

        private static readonly HttpClient _http = TaoHttpClient();

        private static HttpClient TaoHttpClient()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            var c = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
            c.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) QLSV/1.0");
            c.DefaultRequestHeaders.Accept.ParseAdd("image/png,image/*;q=0.9,*/*;q=0.5");
            return c;
        }

        static VietQrHelper()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        public static string TaoNoiDung(string maSV, string maHK)
        {
            string s = BoDau($"HP {maSV} {maHK}");
            s = Regex.Replace(s, @"[^A-Za-z0-9 ]", " ");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s.Length > 50 ? s.Substring(0, 50) : s;
        }

        public static string TaoUrl(decimal soTien, string noiDung)
        {
            return $"https://img.vietqr.io/image/{BANK_ID}-{SO_TAI_KHOAN}-{TEMPLATE}.png" +
                   $"?amount={decimal.Truncate(soTien)}" +
                   $"&addInfo={Uri.EscapeDataString(noiDung)}" +
                   $"&accountName={Uri.EscapeDataString(TEN_TAI_KHOAN)}";
        }

        // Giữ nguyên tên và chữ ký để frmThuHocPhi không phải sửa
        public static Task<Image> TaiQrAsync(decimal soTien, string noiDung)
        {
            return Task.FromResult(TaoQr(soTien, noiDung));
        }

        public static Image TaoQr(decimal soTien, string noiDung)
        {
            string payload = TaoPayload(soTien, noiDung);
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.M))
            using (var qr = new QRCode(data))
            {
                return qr.GetGraphic(10);
            }
        }

        private static string Tlv(string id, string value)
        {
            return id + value.Length.ToString("00") + value;
        }

        public static string TaoPayload(decimal soTien, string noiDung)
        {
            string bank = Tlv("00", BANK_BIN) + Tlv("01", SO_TAI_KHOAN);
            string merchant = Tlv("00", "A000000727") + Tlv("01", bank) + Tlv("02", "QRIBFTTA");

            string s =
                Tlv("00", "01") +
                Tlv("01", "12") +                                  // 12 = QR động (có số tiền)
                Tlv("38", merchant) +
                Tlv("53", "704") +                                 // VND
                Tlv("54", decimal.Truncate(soTien).ToString(CultureInfo.InvariantCulture)) +
                Tlv("58", "VN") +
                Tlv("62", Tlv("08", noiDung)) +
                "6304";

            return s + Crc16(s);
        }

        private static string Crc16(string input)
        {
            ushort crc = 0xFFFF;
            foreach (byte b in Encoding.ASCII.GetBytes(input))
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                    crc = (crc & 0x8000) != 0 ? (ushort)((crc << 1) ^ 0x1021) : (ushort)(crc << 1);
            }
            return crc.ToString("X4");
        }

        private static string BoDau(string s)
        {
            s = s.Replace('đ', 'd').Replace('Đ', 'D');
            string d = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in d)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}