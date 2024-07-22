using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Enum;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Incident
{
    public class IncidentService : Service, IIncidentService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public IncidentService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }
        public void AddAttempt(IncidentResolvingHistoryRequest request, Guid currentUserId)
        {
            var sendModel = mapper.Map<IncidentAttempt>(request);
            sendModel.AttemptedBy = currentUserId;
            //sendModel.AttemptNumber++;
            unit.IncidentRepo.Add(sendModel);
            unit.SaveChanges();
        }


        public void AssignToLowLevel(Guid IncidentId)
        {
            unit.IncidentRepo.AssignToLowLevel(IncidentId);
            unit.SaveChanges();
        }
        public void AssignToMediumLevel(Guid IncidentId)
        {
            unit.IncidentRepo.AssignToMediumLevel(IncidentId);
            unit.SaveChanges();

        }
        public void AssignToHighLevel(Guid IncidentId)
        {
            unit.IncidentRepo.AssignToHighLevel(IncidentId);
            unit.SaveChanges();

        }

        public void StatusChangeToPassedOn(Guid IncidentResolverId)
        {
            unit.IncidentRepo.StatusChangeToPassedOn(IncidentResolverId);
            unit.SaveChanges();

        }

        public void StatusChangeToSolved(Guid IncidentResolverId)
        {
            unit.IncidentRepo.StatusChangeToSolved(IncidentResolverId);
            unit.SaveChanges();

        }


        public bool CurrentUserAssignedToIncident(Guid IncidentId, Guid CurrentUserId)
        {
           
           if( unit.IncidentRepo.CurrentUserAssignedToIncident(IncidentId, CurrentUserId))
           {
                return true;
           }
           return false;
        }

        public bool IncidentIsActive(Guid IncidentId)
        {
            if(unit.IncidentRepo.IncidentIsActive(IncidentId)) 
            {
                return true;
            } return false;
        }

        //Assigns to higher Level Resolver and Decreases Active Cases for CurrentResolver.
        public void AssignToHigherLevel(Guid IncidentResolverId)
        {
            var currentAssignedResolverLevel=unit.IncidentRepo.GetAssignedResolverLevel(IncidentResolverId) ;


            switch (((int)currentAssignedResolverLevel))
            {
                case 0:

                    {
                        var IncidentId = unit.IncidentRepo.GetIncidentId(IncidentResolverId);
                        unit.IncidentRepo.AssignToMediumLevel(IncidentId);
                        //
                        var resolverId=unit.IncidentRepo.GetResolverId(IncidentResolverId);
                        var oldresolver=unit.IncidentRepo.GetByID<Resolver>(resolverId);
                        oldresolver.ActiveCases--;
                        unit.IncidentRepo.Update<Resolver>(oldresolver);
                        //
                        unit.IncidentRepo.StatusChangeToPassedOn(IncidentResolverId);
                    }

                    break;
                case 1:

                    {
                        var IncidentId = unit.IncidentRepo.GetIncidentId(IncidentResolverId);
                        unit.IncidentRepo.AssignToHighLevel(IncidentId);

                        var resolverId = unit.IncidentRepo.GetResolverId(IncidentResolverId);
                        var oldresolver = unit.IncidentRepo.GetByID<Resolver>(resolverId);
                        oldresolver.ActiveCases--;
                        unit.IncidentRepo.Update<Resolver>(oldresolver);
                        unit.IncidentRepo.StatusChangeToPassedOn(IncidentResolverId);
                    }
                    break;

                    //think of what you can do for high level as well

            }
            unit.SaveChanges();
            //if(currentAssignedResolverLevel==Level.Low)
            //{
            //    var IncidentId=unit.IncidentRepo.GetIncidentId(IncidentResolverId) ;
            //    unit.IncidentRepo.AssignToMediumLevel(IncidentId);
            //    unit.IncidentRepo.StatusChangeToPassedOn(IncidentResolverId);
            //}
            //if(currentAssignedResolverLevel== Level.High)
            //{
            //    var IncidentId = unit.IncidentRepo.GetIncidentId(IncidentResolverId);
            //    unit.IncidentRepo.AssignToHighLevel(IncidentId);
            //    unit.IncidentRepo.StatusChangeToPassedOn(IncidentResolverId);

            //}
            
        }
        public Guid GetResolverId(Guid IncidentResolverId)
        {
           return unit.IncidentRepo.GetResolverId(IncidentResolverId);
        }
        public Guid GetIncidentId(Guid IncidentResolverId)
        {
            return unit.IncidentRepo.GetIncidentId(IncidentResolverId);
        }

    }
}
