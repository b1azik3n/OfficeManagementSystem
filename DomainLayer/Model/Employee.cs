using System.Reflection.Metadata;

namespace DomainLayer.Model
{
    public class Employee:BaseClass
    {
        public string Name;
        public string JoinedDate;
        public string JobTitle;
        //Many more properties..
        public User User {  get; set; }

        
        
    }
}
