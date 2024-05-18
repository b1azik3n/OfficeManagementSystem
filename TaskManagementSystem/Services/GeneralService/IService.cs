using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.GeneralService
{
    public interface IService
    {
        void AddNew<Tmodel, TViewModel>(TViewModel tmodel,Guid Id) where Tmodel : BaseClass;
        bool Remove<Tmodel, TViewModel>(Guid Id) where Tmodel : BaseClass;
        List<TViewModel> GetAll<Tmodel,TViewModel>() where Tmodel : BaseClass;
        TviewModel GetByID<Tmodel, TviewModel>(Guid name) where Tmodel : BaseClass;
        void Edit<Tmodel,TViewModel>(TViewModel tmodel, Guid Id,Guid UserId) where Tmodel : BaseClass;

    }
}
