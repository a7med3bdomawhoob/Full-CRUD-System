using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Job
    {
        [Key]
        public int Job_Id { get; set; } 
        public string Job_Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Job_Description { get; set; }
        public string Time_Type { get; set;}
      
      public  ICollection<JobRequirements> JobRequirements { get; set;}
      public ICollection<JobResponsibilities> JobResponsibilities { get; set; }


    }
}
