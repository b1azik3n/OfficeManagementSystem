using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Enum;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Incident
{
    public class IncidentRepo : Repo, IIncidentRepo
    {
        private readonly TaskDbContext context;

        public IncidentRepo(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }


        public void AddAttempt(IncidentResolvingHistoryRequest request, Guid currentUserId)
        {

        }
        public void AssignToLowLevel(Guid IncidentId)
        {
            var incidentResolver = new IncidentResolver
            {
                IncidentId = IncidentId,
                ResolverId = Guid.Parse(ResolverWithMinIncident("Low")),
                Status = 0,
                AssignedOn = DateTime.Now,
            };
            context.IncidentResolvers.Add(incidentResolver);


        }

        public void AssignToMediumLevel(Guid IncidentId)
        {

            var incidentResolver = new IncidentResolver
            {
                IncidentId = IncidentId,
                ResolverId = Guid.Parse(ResolverWithMinIncident("Medium")),
                Status = 0,
                AssignedOn = DateTime.Now,
            };
            context.Add(incidentResolver);
        }
        public void AssignToHighLevel(Guid IncidentId)
        {

            var incidentResolver = new IncidentResolver
            {
                IncidentId = IncidentId,
                ResolverId = Guid.Parse(ResolverWithMinIncident("High")),
                Status = 0,
                AssignedOn = DateTime.Now,
            };
            context.Add(incidentResolver);
        }

        //Finds the Resolver Of given level as String type which has least no. of Active Incidents and +1 to his Active cases.
        public string ResolverWithMinIncident(string resolverLevel) {

            //{
            //    var query = context.Resolvers.AsQueryable();

            //    if (User == 'user')
            //        query = query.Where(x => x.CreatedBy == 1);
            //    if (User == teamlead)
            //        query = query.Where(x => [1,2,4].contains(x.id));

            var givenLevelResolvers = context.Resolvers.AsEnumerable().
                Where(x => x.Level.ToString() == resolverLevel);
            var resolverWithMinimumActive = givenLevelResolvers.OrderBy(x => x.ActiveCases).FirstOrDefault();
            if (resolverWithMinimumActive != null)
            {
                resolverWithMinimumActive.ActiveCases++;
                context.Resolvers.Update(resolverWithMinimumActive);
                return resolverWithMinimumActive.Id.ToString();
            }
            return null;
            //    var resolverIds = context.IncidentResolvers
            //        .Include(ir => ir.Resolver)
            //        .Where(x => x.Status != 0)
            //        .AsEnumerable()  // Switch to client-side evaluation
            //        .Where(x => x.Resolver.Level.ToString() == resolverLevel)
            //        .Select(x => x.ResolverId)
            //        .ToList();

            //    var resolverIdCounts = resolverIds
            //        .GroupBy(id => id)
            //        .Select(g => new
            //        {
            //            ResolverId = g.Key,
            //            ResolverIdCounts = g.Count()
            //        });

            //    var resolverIdWithLeastCount = resolverIdCounts
            //        .OrderBy(x => x.ResolverIdCounts)
            //        .FirstOrDefault()?.ResolverId;  // Use null-conditional operator

            //    if (resolverIdWithLeastCount != null)
            //    {
            //        var data = context.Resolvers.FirstOrDefault(x => x.Id == resolverIdWithLeastCount);
            //        return data;
            //    }

            //    return null;
            //}

            //public Resolver ResolverWithMinIncident(string resolverLevel)
            //{  
            //    var resolverIds = context.IncidentResolvers.
            //        Where(x => x.Resolver.Level.ToString()== resolverLevel && x.Status!=0).Select(x=>x.ResolverId).ToList();
            //    var resolverIdCounts = resolverIds.
            //        GroupBy(Id => Id).
            //        Select(x => new
            //        {
            //            ResolverId = x.Key,
            //            ResolverIdCounts = x.Count()
            //        });
            //    var resolverIdWithLeastCount = resolverIdCounts
            //                                  .OrderBy(x => x.ResolverIdCounts)
            //                            .FirstOrDefault().ResolverId;
            //    if (resolverIdWithLeastCount != null)
            //    {
            //        var data = context.Resolvers.FirstOrDefault(x => x.Id == resolverIdWithLeastCount);
            //        return data;
            //    }
            //    return null;


            //}








        }

        public void AddSimple<Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : class
        {
            throw new NotImplementedException();
        }

        public void StatusChangeToPassedOn(Guid IncidentResolverId)
        {
            var data = context.IncidentResolvers.FirstOrDefault(x => x.Id == IncidentResolverId);
            data.Status = (IncidentStatus)1;
            context.IncidentResolvers.Update(data);
        }

        public void StatusChangeToSolved(Guid IncidentResolverId)
        {

            var data = context.IncidentResolvers.FirstOrDefault(x => x.Id == IncidentResolverId);
            data.Status = (IncidentStatus)2;
            context.IncidentResolvers.Update(data);
        }

        public bool CurrentUserAssignedToIncident(Guid IncidentId, Guid CurrentUserId)
        {
            var data = context.IncidentResolvers.
                Where(x => x.IncidentId == IncidentId && x.Status == IncidentStatus.Active).
                Select(x => x.Resolver.UserId).FirstOrDefault();

            if (CurrentUserId == data)
            {
                return true;

            }
            return false;

        }
        public bool IncidentIsActive(Guid IncidentId)
        {
            var data = context.IncidentResolvers.Where(x => x.IncidentId == IncidentId && x.Status == IncidentStatus.Active);
            if (data != null)
            {
                return true;
            }
            return false;

        }

        public Level GetAssignedResolverLevel(Guid IncidentResolverId)
        {
            var level = context.IncidentResolvers.
                Where(x => x.Id == IncidentResolverId).
            Select(x => x.Resolver.Level).FirstOrDefault();
            return level;
        }

        public Guid GetIncidentId(Guid IncidentResolverId)
        {
            return context.IncidentResolvers.FirstOrDefault(x => x.Id == IncidentResolverId).IncidentId;
        }

        public Guid GetResolverId(Guid IncidentResolverId)
        {
            return context.IncidentResolvers.FirstOrDefault(x => x.Id == IncidentResolverId).ResolverId;
        }
        //Add the IncidentResolvingAttempt by resolver

        public IncidentReportDetailedResponse GetIncidentDetailedReport(IncidentReportDetailedRequest request)
        {
            
            var incidentQuery = context.Incidents.Where(x => x.ClientId == request.ClientId && x.IncidentResolver.Status == IncidentStatus.Active);
            if (request.UserId != null)
            {
                incidentQuery = incidentQuery.Where(x => x.IncidentResolver.Resolver.UserId == request.UserId).
                    Select(x => new IncidentReportDetailedResponse
                    {
                        Name=x.Description,
                        ClientName= x.Client.Name,
                        Status=Status.Active, //manage
                        ReportedOn=x.ReportedOn,
                        forDetailedIncidents= new List<ForDetailedIncident>
                        {
                            x.
                        }
                        

                        
                        

                    }//group garera Ig..

                    


                };

            }
        } }
