using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ApiResponse
    {
        public string Message { get; set; }

        public int Code { get; set; }

        public ApiResponse()
        {
            Code = 200;
            Message = "Success";
        }

    }
    public class ApiResponse<T> : ApiResponse
    {
        public T ResultData { get; set; }
    }
}
