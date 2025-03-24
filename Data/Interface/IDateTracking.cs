using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDateTracking
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
