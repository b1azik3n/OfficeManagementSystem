

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
        public async System.Threading.Tasks.Task Initializer()
        {

            if (context.Users.FirstOrDefault(x=> x.Role=="Admin")==null)
            {
                var user = new User
                {
                    PhoneNumber = "9847035197",
                    Email = "Ultimatetester@gmail.com",
                    Name = "Admin",
                    Role = "Admin",
                    Password = "Asdfghjkl12@"


                };
                 context.Users.AddAsync(user).GetAwaiter().GetResult();
                context.SaveChangesAsync().GetAwaiter().GetResult();

            }
            
            

           



        }
    }
}
