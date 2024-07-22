using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Incident
{
    public interface IIncidentService:IService
    {
        //public override void AddWithoutGuidId<Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : class;

        public void AddAttempt(IncidentResolvingHistoryRequest request, Guid currentUserId);

        public void AssignToLowLevel(Guid IncidentId);
        public void AssignToMediumLevel(Guid IncidentId);
        public void AssignToHighLevel(Guid IncidentId);
        //bool IsWithinTimeLimit(Guid IncidentResolverId, TimeSpan TimeLimit);
        public void StatusChangeToPassedOn(Guid IncidentResolverId);
        public void StatusChangeToSolved(Guid IncidentResolverId);
        public bool CurrentUserAssignedToIncident(Guid IncidentResolverId, Guid CurrentUserId);
        public bool IncidentIsActive(Guid IncidentId);

        public void AssignToHigherLevel(Guid IncidentResolverId);
        public Guid GetIncidentId(Guid IncidentResolverId);
        public Guid GetResolverId(Guid IncidentResolverId);






    }
}
