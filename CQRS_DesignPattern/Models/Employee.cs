using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS_DesignPattern.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
