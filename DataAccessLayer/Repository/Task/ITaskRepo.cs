using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Task
{
    public interface ITaskRepo : IRepo
    {
        void AddTask(TaskModel task);
        bool CheckAssignment(TaskUserRequest task);
         TaskResponse GetByID(Guid id);


    }
}
