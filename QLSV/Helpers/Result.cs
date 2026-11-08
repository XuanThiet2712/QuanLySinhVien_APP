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

        public static Result Ok(string message = "")
        {
            return new Result { Success = true, Message = message };
        }

        public static Result Fail(string message)
        {
            return new Result { Success = false, Message = message };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

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
