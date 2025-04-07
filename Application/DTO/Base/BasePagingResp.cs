using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Base
{
    public abstract class BasePagingResp<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public IList<T> Result { get; set; }

        public int FirstRowPage { get { return (CurrentPage - 1) * PageSize + 1; } }

        public int LastRowPage { get { return Math.Min(CurrentPage * PageSize, Count); } }

        public int PageCount { get { var pageCount = (double)Count / PageSize;
                return (int)Math.Ceiling(pageCount);
            } set { PageCount = value; } }

    }
}
