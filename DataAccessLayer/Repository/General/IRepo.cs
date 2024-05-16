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
        bool Remove<Tmodel>(Guid Id) where Tmodel : BaseClass;
        List<TViewModel> GetAll<T,TViewModel>() where T : class;
        Tmodel GetByID<Tmodel>(Guid Id) where Tmodel : BaseClass;
        void Update<Tmodel>(Tmodel project) where Tmodel : class;
        string GetNameFromId<Tmodel>(Guid id) where Tmodel : BaseNameClass;

    }
}
