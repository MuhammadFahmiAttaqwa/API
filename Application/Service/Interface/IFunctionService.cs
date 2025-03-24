using Application.DTO;
using Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IFunctionService
    {
        Task<List<SidebarResponse>> GetSideBar();
        Task<SidebarResponse> GetAllPermision(Guid userId);
    }
}
