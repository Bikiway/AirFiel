using System;
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

        public string NameAndExperience => $"{FirstName} - {Experience}";


        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Age")]
        public string Age { get; set; }


        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Category")]
        public string Experience { get; set; }


        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        public Users Users { get; set; }

        public string ProfileImageFullPath
        {
            get
            {
                if(string.IsNullOrEmpty(ProfileImage))
                { return null; }

                return $"https://localhost:44383{ProfileImage.Substring(1)}";
            }

        }
    }
}
