using Application.DTO;
using Application.DTO.Response;
using Application.Repository.Interfaces;
using Application.Service.Interface;
using AutoMapper;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constant;

namespace Application.Service.Implementation
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public FunctionService(IFunctionRepository functionRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _functionRepository = functionRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<SidebarResponse> GetAllPermision(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SidebarResponse>> GetSideBar()
        {
            var user = _httpContextAccessor.HttpContext.User;

            if (user == null) throw new UnauthorizedAccessException("User tidak temukan");

            var roles = user.FindFirst("Roles")?.Value ?? string.Empty;

            List<Function> functions;
            if (roles.Split(";").Contains(CommonConstant.AppRole.AdminRole))
            {
                functions = await _functionRepository.getAll(string.Empty);
            }
            else
            {
                functions = await _functionRepository.getAll(string.Empty);
            }

            return _mapper.Map<List<SidebarResponse>>(functions);
        }
    }
}
