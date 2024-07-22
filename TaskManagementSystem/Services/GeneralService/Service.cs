
using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;

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

        public virtual void AddNew<Tmodel, TViewModel>(TViewModel viewModel, Guid Id) where Tmodel : BaseDetailed
        {

            var project = mapper.Map<Tmodel>(viewModel);
            project.CreatedBy = Id;
            unit.Repo.Add(project);
            unit.SaveChanges();
        }
        //Anyone can Add here without Authentication and It sends latest entry Id(Guid).
        public Guid AddWithoutLogin <Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : BaseGuid
        {

            var project = mapper.Map<Tmodel>(viewModel);
            unit.Repo.Add<Tmodel>(project);
            unit.SaveChanges();
            //Id is automatically updated by EF or so it says: IT DOES SEND LATEST ENTRY ID.
            return project.Id;
        }
        //Add with Int as key
        public virtual void AddWithoutGuidId<Tmodel, TViewModel>( TViewModel viewModel) where Tmodel:class
        {
            var mapped = mapper.Map<Tmodel>(viewModel);
            unit.Repo.Add<Tmodel>(mapped);
        }

        public void Edit<Tmodel, TViewModel>(TViewModel tmodel, Guid Id, Guid UserId) where Tmodel : BaseDetailed
        {

            var model = unit.Repo.GetByID<Tmodel>(Id);
            mapper.Map(tmodel, model);
            model.LastModifiedBy = UserId;
            model.LastModifiedOn = DateTime.Now;
            unit.Repo.Update(model);
            unit.SaveChanges();
        }

        public List<TViewModel> GetAll<Tmodel, TViewModel>() where Tmodel : BaseGuid
        {
            var list = unit.Repo.GetAll<Tmodel, TViewModel>();
            return list;

        }

        public virtual TviewModel GetByID<Tmodel, TviewModel>(Guid id) where Tmodel : BaseGuid
        {
            Tmodel project = unit.Repo.GetByID<Tmodel>(id);
            var vm = mapper.Map<TviewModel>(project);
            return vm;
        }

        public bool Remove<Tmodel, TViewModel>(Guid Id) where Tmodel : BaseGuid
        {
            var send = unit.Repo.Remove<Tmodel>(Id);
            unit.SaveChanges();
            return send;


        }
        public bool CheckIfDuplicateEmail<Tmodel, TViewModel>(TViewModel tviewmodel) where Tmodel : BaseActor
        {
            var mapped= mapper.Map<Tmodel>(tviewmodel);
            if (unit.Repo.EmailExist<Tmodel>(mapped)) {return true;}
            return false;
           
        }
        public bool CheckIfDuplicatePhoneNumber<Tmodel, TViewModel>(TViewModel tviewmodel) where Tmodel : BaseActor
        {
            var mapped = mapper.Map<Tmodel>(tviewmodel);
            if (unit.Repo.PhoneNumberExist<Tmodel>(mapped)) { return true; }
            return false;

        }

        public bool CheckIfIdExists<Tmodel>(Guid Id) where Tmodel : BaseGuid
        {
           
            if (unit.Repo.IdExist<Tmodel>(Id)) { return true; }
            return false;
        }
        
    }
}
