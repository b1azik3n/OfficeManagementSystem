using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Model;

namespace DataAccessLayer.Repository.DailyLogs
{
    public class LogRepo : Repo,ILogRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public LogRepo(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddLog(DailyLog log)
        {
            context.DailyLogs.Add(log);

        }

        public void RemoveLog(DailyLog log)
        {
            context.DailyLogs.Remove(log);
        }

        public DailyLog GetLog(string Name)
        {
            // check with id and send

            //var sendlog = context.DailyLogs.FirstOrDefault(o => o.DateTime.ToLongDateString ='dad'); 
            //if (sendlog != null)
            //{
            //    return sendlog;
            //}
            //else
            return null;
        }

        //public List<DailyLog> GetAllLogs()
        //{
        //    return context.DailyLogs.ToList();
        //}
        public List<TViewModel> GetAllLogs<TModel, TViewModel>() where TModel : class //where define necessary.
        {
            IQueryable<TModel> query = context.Set<TModel>().AsQueryable();
            IQueryable<TViewModel> vmquery = mapper.ProjectTo<TViewModel>(query);
            List<TViewModel> send = vmquery.ToList();


            //List<DailyLog> modelList = context.DailyLogs.ToList();
            //List<DailyLogDTO> vmList = mapper.Map<DailyLogDTO>(modelList);

            return send;
        }
    }
}
