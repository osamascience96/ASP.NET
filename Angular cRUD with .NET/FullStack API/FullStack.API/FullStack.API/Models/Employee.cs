namespace FullStack.API.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public String? Department { get; set; }


    }
}
