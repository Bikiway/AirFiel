using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Employees : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string EmployeeFullName => $"{FirstName} {LastName}";

        [Display(Name = "Age")]
        public string Age { get; set; }

        [Display(Name = "Category")]
        public string Experience { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }
    }
}
