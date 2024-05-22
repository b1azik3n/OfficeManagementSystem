﻿using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.GeneralService
{
    public interface IService
    {
        public virtual void AddNew<Tmodel, TViewModel>(TViewModel tmodel, Guid Id) where Tmodel : BaseClass
        {

        }
        bool Remove<Tmodel, TViewModel>(Guid Id) where Tmodel : BaseClass;
        List<TViewModel> GetAll<Tmodel,TViewModel>() where Tmodel : BaseClass;
        TviewModel GetByID<Tmodel, TviewModel>(Guid name) where Tmodel : BaseClass;
        void Edit<Tmodel,TViewModel>(TViewModel tmodel, Guid Id,Guid UserId) where Tmodel : BaseClass;
        bool CheckIfDuplicateEmail<Tmodel, TViewModel>(TViewModel tviewmodel) where Tmodel : BaseActor;
        bool CheckIfDuplicatePhoneNumber<Tmodel, TViewModel>(TViewModel tviewmodel) where Tmodel : BaseActor;

        bool CheckIfIdExists<Tmodel>(Guid Id) where Tmodel : BaseClass;



    }
}
