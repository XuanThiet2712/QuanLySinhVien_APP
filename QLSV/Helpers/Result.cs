using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Helpers
{
    //Lớp mô tả thao tác của Service, có thể thành công hoặc thất bại, kèm theo thông báo
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } // lời nhắn


        // constructor 
        public Result()
        {
            Success = true;
            Message = "";
        }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        // static methods
        //Result.Ok() và Result.Fail()
        //là các phương thức tiện lợi để tạo ra các đối tượng Result
        //thành công hoặc thất bại mà không cần phải gọi constructor trực tiếp.
        public static Result Ok(string message = "")
        {
            return new Result { Success = true, Message = message };
        }

        public static Result Fail(string message)
        {
            return new Result { Success = false, Message = message };
        }
    }
    //Generic -- > như template c++ , T là kiểu dữl iệu truyền vào
    public class Result<T> : Result
    {
        public T Data { get; set; }
        public bool IsSuccess { get; internal set; }

        // T ví dụ là NguoiDung, SinhVien, LopHoc, MonHoc, Diem, ...

        //ví dụ
        //cú pháp : Result<NguoiDung>.Ok(nguoiDung, "Đăng nhập thành công")
        public static Result<T> Ok(T data, string message = "")
        {
            return new Result<T> { Success = true, Data = data, Message = message };
        }

        public new static Result<T> Fail(string message)
        {
            return new Result<T> { Success = false, Message = message };
        }
    }


}
