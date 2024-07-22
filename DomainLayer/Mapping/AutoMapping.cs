using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using System.Xml.Serialization;

namespace DomainLayer.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserRequest>().ReverseMap();
                
            CreateMap<UserLogin, UserLoginRequest>().ReverseMap();
            CreateMap<DailyLog, DailyLogRequest>().ReverseMap();
            CreateMap<Project, ProjectRequest>().ReverseMap();
            CreateMap<Project, ProjectResponse>().ReverseMap();
            CreateMap<ProjectUser, ProjectUserResponse>().ReverseMap();
            CreateMap<DailyLog, DailyLogRequest>().ReverseMap();
            CreateMap<DailyLogRequest, DailyLogRequest>().ReverseMap();
            CreateMap<Designation, DesignationRequest>().ReverseMap();
            CreateMap<TaskModel, TaskRequest>().ReverseMap();
            CreateMap<ProjectUser,ProjectSingleUserRequest>().ReverseMap();  
            CreateMap<Client, ClientRequest>().ReverseMap();
            CreateMap<TaskUser, TaskUserRequest>().ReverseMap();
            CreateMap<TaskModel,TaskAllResponse>().ReverseMap();
            CreateMap<TaskModel,TaskStatusRequest>().ReverseMap();
            CreateMap<TaskModel,TaskStatusResponse>().ReverseMap();
            CreateMap<EmployeeRequest,Employee>().ReverseMap();
            CreateMap<Auditor, AuditorVM>().ReverseMap();
            CreateMap<MailData,MailDataRequest>().ReverseMap();
            CreateMap<Resolver,ResolverRequest>().ReverseMap();
            CreateMap<Resolver,ResolverResponse>().ReverseMap();
            CreateMap<Incident, IncidentRequest>().ReverseMap();    
            CreateMap<IncidentAttempt,IncidentResolvingHistoryRequest>().ReverseMap();
           
        }
    }
}
