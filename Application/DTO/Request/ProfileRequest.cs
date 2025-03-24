using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class ProfileRequest
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
