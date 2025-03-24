using Application.DTO.Response;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Interfaces
{
    public interface IFunctionRepository
    {
        Task<List<Function>> getAll(string filter);
        Task<SidebarResponse> getAllByPermission();
    }
}
