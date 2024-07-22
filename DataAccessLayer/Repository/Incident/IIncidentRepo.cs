using DataAccessLayer.Repository.General;
using DomainLayer.Enum;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Incident
{
    public interface IIncidentRepo : IRepo
    {
        public void AssignToLowLevel(Guid IncidentId);
        public void AssignToHighLevel(Guid IncidentId);
        public void AssignToMediumLevel(Guid IncidentId);
        public void AddSimple<Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : class;
        public void StatusChangeToPassedOn(Guid IncidentResolverId);
        public void StatusChangeToSolved(Guid IncidentResolverId);
        public bool CurrentUserAssignedToIncident(Guid IncidentResolverId, Guid CurrentUserId);
        public bool IncidentIsActive(Guid IncidentId);
        public Level GetAssignedResolverLevel(Guid IncidentResolverId);
        public Guid GetIncidentId(Guid IncidentResolverId);
        public Guid GetResolverId(Guid IncidentResolverId);


    }

}
