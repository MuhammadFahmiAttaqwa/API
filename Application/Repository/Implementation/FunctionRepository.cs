using Application.DTO.Response;
using Application.Repository.Interfaces;
using Data.Entity;
using Data.Enums;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Implementation
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly IRepository<Function, string> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public FunctionRepository(IRepository<Function, string> repository, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _repository = repository; 
        }

        public async Task<List<Function>> getAll(string filter)
        {
            return await _repository.FindAll(x => x.Status == Status.Active)
            .Where(x => string.IsNullOrEmpty(filter) || x.Name.Contains(filter))
            .ToListAsync();
        }

        public Task<SidebarResponse> getAllByPermission()
        {
            throw new NotImplementedException();
        }
    }
}
