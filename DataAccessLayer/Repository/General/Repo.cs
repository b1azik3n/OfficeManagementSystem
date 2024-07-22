using AutoMapper;
using DataAccessLayer.Data;
using DomainLayer.Model;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.Repository.General
{
    public class Repo : IRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public Repo(TaskDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Add<TModel>(TModel tmodel) where TModel : class
        {
            context.Set<TModel>().Add(tmodel);

        }
        

        public List<TViewModel> GetAll<T,TViewModel>() where T : class
        {
            var query = context.Set<T>();
            var nextquery = mapper.ProjectTo<TViewModel>(query);
            return nextquery.ToList();
        }

        public virtual Tmodel GetByID<Tmodel>(Guid id) where Tmodel : BaseGuid
        {
            var project = context.Set<Tmodel>().FirstOrDefault(x => x.Id == id); 
            if (project == null)
            {
                return null;
            }
            return project;
        }

        public bool Remove<Tmodel>(Guid Id) where Tmodel : BaseGuid
        {
            
            var del = context.Set<Tmodel>().FirstOrDefault(x => x.Id == Id);
            if (del==null)
            {
                return false;
               
            }
            context.Set<Tmodel>().Remove(del);
            return true;
        }

        public void Update<Tmodel>(Tmodel project) where Tmodel : class
        {
            context.Set<Tmodel>().Update(project);
        }
        public string GetNameFromId<Tmodel>(Guid id) where Tmodel: BaseActor
        {
            var name = context.Set<Tmodel>().FirstOrDefault(x => x.Id == id).Name;
            return name;
        }
        public bool EmailExist<Tmodel>(Tmodel tmodel) where Tmodel : BaseActor
        {
           if(context.Set<Tmodel>().FirstOrDefault(x=> x.Email == tmodel.Email)!=null)
            {
                return true;

            }
           return false;
        }
        public bool PhoneNumberExist<Tmodel>(Tmodel tmodel) where Tmodel : BaseActor
        {
            if (context.Set<Tmodel>().FirstOrDefault(x => x.PhoneNumber == tmodel.PhoneNumber) != null)
            {
                return true;

            }
            return false;
        }
        public bool IdExist<Tmodel>(Guid Id) where Tmodel : BaseGuid
        {
            if (context.Set<Tmodel>().FirstOrDefault(x => x.Id == Id) != null)
            {
                return true;

            }
            return false;
        }
        //public Guid SendLatestEntryId<Tmodel>(Tmodel tmodel) where Tmodel : BaseClass
        //{
        //    var latestId=context.Set<Tmodel>().

        //} 
    }
}
