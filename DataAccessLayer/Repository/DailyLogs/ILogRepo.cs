using DataAccessLayer.Repository.General;
using DomainLayer.Model;

namespace DataAccessLayer.Repository.DailyLogs
{
    public interface ILogRepo:IRepo
    {
        void AddLog(DailyLog log);
        void RemoveLog(DailyLog log);
        DailyLog GetLog(string Name);

        List<TViewModel> GetAllLogs<TModel, TViewModel>() where TModel : class;

    }
}
