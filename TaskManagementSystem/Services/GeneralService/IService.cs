using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.GeneralService
{
    public interface IService
    {
        public virtual void AddNew<Tmodel, TViewModel>(TViewModel tmodel, Guid Id) where Tmodel : BaseDetailed
        {

        }
        public Guid AddWithoutLogin<Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : BaseGuid;
        public virtual void AddWithoutGuidId<Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : class { }



        bool Remove<Tmodel, TViewModel>(Guid Id) where Tmodel : BaseGuid;
        List<TViewModel> GetAll<Tmodel,TViewModel>() where Tmodel : BaseGuid;
        TviewModel GetByID<Tmodel, TviewModel>(Guid name) where Tmodel : BaseGuid;
        void Edit<Tmodel,TViewModel>(TViewModel tmodel, Guid Id,Guid UserId) where Tmodel : BaseDetailed;
        bool CheckIfDuplicateEmail<Tmodel, TViewModel>(TViewModel tviewmodel) where Tmodel : BaseActor;
        bool CheckIfDuplicatePhoneNumber<Tmodel, TViewModel>(TViewModel tviewmodel) where Tmodel : BaseActor;

        bool CheckIfIdExists<Tmodel>(Guid Id) where Tmodel : BaseGuid;



    }
}
