using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AuthService( IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
 
        public User FindUser(UserLoginRequest user)
        {
            var send=mapper.Map<UserLogin>(user);
            User temp = unitOfWork.AuthRepo.Find(send);

            return temp;

        }
        public bool RegisterUser(RegisterUserRequest user)
        {
            var temp=mapper.Map<User>(user);
            unitOfWork.AuthRepo.Add(temp);
            unitOfWork.SaveChanges();
            return true;
            
            
        }
    }
}
