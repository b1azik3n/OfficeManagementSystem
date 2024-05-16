using DataAccessLayer.Data;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Authentication
{
    internal class AuthRepo : IAuthRepo
    {
        private readonly TaskDbContext context;

        public AuthRepo(TaskDbContext context)
        {
            this.context = context;
        }

        public User Find(UserLogin user)
        {
            var temp = context.Users.FirstOrDefault(x => x.Email == user.UserName && x.Password == user.Password);
            return temp;

        }
        public void Add(User user)
        {
            context.Users.Add(user);
        }


    }
}
