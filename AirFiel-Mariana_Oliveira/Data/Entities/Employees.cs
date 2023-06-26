namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Employees
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string EmployeeFullName => $"{FirstName} {LastName}"; 

        public string Age { get; set; }

        public string Experience { get; set; }

        public string ProfileImage { get; set; }
    }
}
