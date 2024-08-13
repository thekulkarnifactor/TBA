namespace TBA.Model
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? ManagerId { get; set; }
        public string? Role { get; set; }

        //public virtual Employee Manager { get; set; }
        //public virtual ICollection<Employee> Subordinates { get; set; }
        //public virtual ICollection<Tasks> TasksCreated { get; set; }
        //public virtual ICollection<Tasks> TasksAssigned { get; set; }
    }
}
