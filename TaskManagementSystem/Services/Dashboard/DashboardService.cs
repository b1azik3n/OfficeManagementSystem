using Dapper;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using System.Data;

namespace TaskManagementSystem.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IDbConnection  _dbConnection;

        public DashboardService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public List<DashCurrentProjectsResponse> GetCurrentProjects(Guid UserId)
        {
            _dbConnection.Open();
            var parameters = new { UserId = UserId };
            var employee = _dbConnection.Query<DashCurrentProjectsResponse>("GetAllCurrentProjects",
            commandType: CommandType.StoredProcedure);
            return employee.ToList();

        }
        public List<DashCompletedProjectsResponse> GetCompletedProjects(Guid UserId)
        {
            _dbConnection.Open();
            var parameters = new { UserId = UserId };
            var employee = _dbConnection.Query<DashCompletedProjectsResponse>("GetAllCompletedProjects", 
                 commandType: CommandType.StoredProcedure);
            return employee.ToList();
        }
       
        public List<DashCompletedTasksResponse> GetCompletedTasks(Guid UserId)
        {

            _dbConnection.Open();
            var parameters = new { UserId = UserId };

            var employee = _dbConnection.Query<DashCompletedTasksResponse>("GetAllCompletedTasks",
                 commandType: CommandType.StoredProcedure);
            return employee.ToList();
        }
        public List<DashPendingTasksResponse> GetPendingTasks(Guid UserId)
        {

            _dbConnection.Open();
            var parameters = new { UserId = UserId };

            var employee = _dbConnection.Query<DashPendingTasksResponse>("GetAllPendingTasks",
                parameters, commandType: CommandType.StoredProcedure);
            return employee.ToList();
        }
        public List<AllUsersSummaryResponse> GetAllUsersSummary()
        {

            _dbConnection.Open();
            var employee = _dbConnection.Query<AllUsersSummaryResponse>("GetAllUsersSummary",
                 commandType: CommandType.StoredProcedure);
            return employee.ToList();
        }



    }
}
