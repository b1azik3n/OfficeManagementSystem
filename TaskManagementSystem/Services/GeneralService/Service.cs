
using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.GeneralService
{
    public class Service : IService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public Service(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNew<Tmodel, TViewModel>(TViewModel viewModel,Guid Id) where Tmodel : BaseClass
        {

            var project = mapper.Map<Tmodel>(viewModel);
            project.CreatedBy= Id;
            unit.Repo.Add(project);
            unit.SaveChanges();
        }

        public void Edit<Tmodel, TViewModel>(TViewModel tmodel, Guid Id,Guid UserId) where Tmodel : BaseClass
        {

            var model = unit.Repo.GetByID<Tmodel>(Id);
            mapper.Map(tmodel, model);
            model.LastModifiedBy = UserId;
            model.LastModifiedOn=DateTime.Now;
            unit.Repo.Update(model);
            unit.SaveChanges();
        }

        public List<TViewModel> GetAll<Tmodel,TViewModel>() where Tmodel : BaseClass
        {
            var list = unit.Repo.GetAll<Tmodel, TViewModel>();
            return list;

        }

        public virtual TviewModel GetByID<Tmodel, TviewModel>(Guid id) where Tmodel : BaseClass
        {
            Tmodel project = unit.Repo.GetByID<Tmodel>(id);
            var vm = mapper.Map<TviewModel>(project);
            return vm;
        }

        public bool Remove<Tmodel, TViewModel>(Guid Id) where Tmodel : BaseClass
        {
            var send= unit.Repo.Remove<Tmodel>(Id);
            unit.SaveChanges();
            return send;
         

        }
        
    }
}
