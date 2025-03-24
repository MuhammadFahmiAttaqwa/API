using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class SidebarResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string ParentId { get; set; }
        public string IconCss { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
    }
}
