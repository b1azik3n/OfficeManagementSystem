using DomainLayer.Model;
using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.General
{
    public interface IRepo
    {
        void Add<Tmodel>(Tmodel tmodel) where Tmodel : class;

        bool Remove<Tmodel>(Guid Id) where Tmodel : BaseGuid;
        List<TViewModel> GetAll<T,TViewModel>() where T : class;
        Tmodel GetByID<Tmodel>(Guid Id) where Tmodel : BaseGuid;
        void Update<Tmodel>(Tmodel project) where Tmodel : class;
        string GetNameFromId<Tmodel>(Guid id) where Tmodel : BaseActor;
         bool EmailExist<Tmodel>(Tmodel tmodel) where Tmodel : BaseActor;
         bool PhoneNumberExist<Tmodel>(Tmodel tmodel) where Tmodel : BaseActor;
        bool IdExist<Tmodel>(Guid Id) where Tmodel : BaseGuid;




    }
}
