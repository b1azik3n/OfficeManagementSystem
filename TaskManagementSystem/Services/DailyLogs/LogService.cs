using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.DailyLogs
{
    public class LogService : Service, ILogService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public LogService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNew<Tmodel, TViewModel>(TViewModel viewModel, string UserId) where Tmodel : BaseClass
        {
            var log = mapper.Map<DailyLog>(viewModel);
            log.UserId = Guid.Parse(UserId);
            unit.LogRepo.AddLog(log);
            unit.SaveChanges();

        }
  

        public DailyLogResponse ViewLog(Guid Id) 
        {
            var log = unit.LogRepo.GetByID<DailyLog>(Id);
            var vm = mapper.Map<DailyLogResponse>(log);
            var name= unit.LogRepo.GetNameFromId<User>(log.UserId);
            vm.UserName = name;
            return vm;
        }

        //public List<DailyLogResponse> GetAllLogs()
        //{
        //    var list = unit.LogRepo.GetAllLogs<DailyLog, DailyLogResponse>();
        //    //List<DailyLogVM> newlist= new List<DailyLogVM>();
        //    //foreach (var log in list)
        //    //{
        //    //   var newlog=mapper.Map<DailyLogVM>(log);
        //    //    newlist.Add(newlog);

        //    //}
        //    return list;
        //}
    }
}
