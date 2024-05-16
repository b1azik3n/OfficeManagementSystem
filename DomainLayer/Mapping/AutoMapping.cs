﻿using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace DomainLayer.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserLogin, UserLoginRequest>().ReverseMap();
            CreateMap<DailyLog, DailyLogRequest>().ReverseMap();
            CreateMap<Project, ProjectRequest>().ReverseMap();
            CreateMap<Project, ProjectResponse>().ReverseMap();
            CreateMap<ProjectUser, ProjectUserResponse>().ReverseMap();
            CreateMap<RegisterUserRequest, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"))
                .ReverseMap();
            CreateMap<DailyLog, DailyLogRequest>().ReverseMap();
            CreateMap<DailyLogRequest, DailyLogRequest>().ReverseMap();
            CreateMap<Designation, DesignationRequest>().ReverseMap();
            CreateMap<TaskModel, TaskRequest>().ReverseMap();
            CreateMap<ProjectUser,ProjectUserRequest>().ReverseMap();  
            CreateMap<Client, ClientRequest>().ReverseMap();
            CreateMap<TaskUser, TaskUserRequest>().ReverseMap();
            CreateMap<TaskModel,TaskAllResponse>().ReverseMap();
            CreateMap<TaskModel,TaskStatusRequest>().ReverseMap();
            CreateMap<TaskModel,TaskStatusResponse>().ReverseMap();
            
        }
    }
}