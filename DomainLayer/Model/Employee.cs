using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Model
{
    public class Employee:BaseClass
    {
        [Column(Order =1)]
        public string Name {  get; set; }
        [Column(Order =2)]
        public string JoinedDate { get; set; }
        [Column(Order =3)]
        public Position Position { get; set; }
        [Column(Order =4)]
        public EmployeeStatus Status { get; set; }
        [Column (Order =5)]
        public string LeftDate { get; set; }
        [Column(Order =6)]
        public string DOB {  get; set; }
        [Column(Order =7)]
        public Gender Gender { get; set; }
        [Column(Order =8)]
        public string EmailAddress { get; set; }

        //Many more properties..

        
        
    }
}
