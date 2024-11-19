using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Project_Name { get; set; }
        public string Project_Name_ar { get; set; }
        public string Image_Name { get; set; }
        public string Client_Name { get; set; }
        public string Location { get; set; }
        public string Project_Description { get; set; }
        public string Project_Description_ar { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }


    }
}
