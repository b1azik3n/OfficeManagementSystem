using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Authentication
{
    public interface IAuthRepo
    {
        User Find(UserLogin user);
        void Add(User user);
    }
}
