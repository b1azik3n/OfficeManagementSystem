using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Clients
{
    public class ClientService : Service, IClientService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public ClientService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }
        

    }
}
