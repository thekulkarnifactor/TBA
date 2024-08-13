namespace TBA.Model
{
    public class Teams
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int ManagerId { get; set; }

        //public virtual Employee Manager { get; set; }
        //public virtual ICollection<Employee> Members { get; set; }
    }
}
