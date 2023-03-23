namespace EmployeeWebApi.Models
{
    public class Project
    {
       public int  projectId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; } 
        public float budget { get; set; }

    }
}
