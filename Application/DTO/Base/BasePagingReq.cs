using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Base
{
    public abstract class BasePagingReq
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

    }
}
