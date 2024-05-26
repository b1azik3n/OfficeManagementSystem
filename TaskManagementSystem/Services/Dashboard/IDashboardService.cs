using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.Dashboard
{
    public interface IDashboardService
    {
        List<DashCompletedProjectsResponse> GetCompletedProjects(Guid UserId);
        List<DashCurrentProjectsResponse> GetCurrentProjects(Guid UserId);
        List<DashPendingTasksResponse> GetPendingTasks(Guid UserId);
        List<DashCompletedTasksResponse> GetCompletedTasks(Guid UserId);
        List<AllUsersSummaryResponse> GetAllUsersSummary();



    }
}
