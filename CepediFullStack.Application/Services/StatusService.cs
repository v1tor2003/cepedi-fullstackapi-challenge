using AutoMapper;
using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application.Services
{
    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(IRepository<Status> repository, IMapper mapper) 
        : base(repository, mapper) 
        {}
    }
}