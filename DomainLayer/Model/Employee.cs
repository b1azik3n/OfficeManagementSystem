using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Model
{
    public class Employee:BaseActor
    {
        
        
        public string JoinedDate { get; set; }
       
        public Position Position { get; set; }
        
        public EmployeeStatus Status { get; set; }
    
        public string LeftDate { get; set; }
       
        public string DOB {  get; set; }
        
        public Gender Gender { get; set; }
        

        //Many more properties..

        
        
    }
}
