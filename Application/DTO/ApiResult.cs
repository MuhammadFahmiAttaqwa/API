﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.DTO
{
    public class ApiResult<T>
    {
        public object OtherData { get; set; } = null;
        public bool Status { get; set; } = false;
        public string Msg { get; set; } = "successful";
        public int Code { get; set; } = 0;
        public string MethodDescription { get; set; } = "";
        public T Data { get; set; }

        public ApiResult() { }

        public ApiResult(bool status, string msg = "successful", int code = 200, object otherData = null, string methodDescription = null, T data = default)
        {
            Status = status;
            Msg = msg;
            Code = code;
            OtherData = otherData;
            MethodDescription = methodDescription ?? "";
            Data = data;
        }

        public ApiResult(bool status, string msg, T data)
        {
            Status = status;
            Msg = msg;
            Data = data;
        }

       
    }
}
