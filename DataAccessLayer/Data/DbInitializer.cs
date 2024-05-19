

using DomainLayer.Model;

namespace DataAccessLayer.Data
{
    public class DbInitializer: IDbInitializer
    {
        private readonly TaskDbContext context;

        public DbInitializer(TaskDbContext context)
        {
            this.context = context;
        }
        public async Task Initializer()
        {

            if ((context.Users.FirstOrDefault(x=> x.UserType==0))==null)
            {
                var user = new User
                {
                    PhoneNumber = "9847035197",
                    Email = "Ultimatetester@gmail.com",
                    Name = "Admin",
                    UserType= 0,
                    Password = "Asdfghjkl12@",
                    OrgID= "AdminThisIs"


                };
                 context.Users.AddAsync(user).GetAwaiter().GetResult();
                context.SaveChangesAsync().GetAwaiter().GetResult();

            }
            
            

           



        }
    }
}
