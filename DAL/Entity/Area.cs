using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public  class Area
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Area_Image { get; set; }
        public string Area_Description { get; set; }
        public string Area_Description_ar { get; set; }

        // Foreign key for Service
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        // Navigation property
        public ICollection<Project> Projects { get; set; }

    }
}
