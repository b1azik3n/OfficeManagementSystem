using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.DailyLogs
{
    public interface ILogService: IService
    {
        void AddNew<Tmodel, TViewModel>(TViewModel vm, string token) where Tmodel : BaseDetailed;
       DailyLogResponse ViewLog(Guid Id);
        //List<DailyLogResponse> GetAllLogs();


    }
}
