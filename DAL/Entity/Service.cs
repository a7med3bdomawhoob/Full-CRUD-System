using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace DAL.Entity
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Service_Image { get; set; }
        public string Service_Description { get; set; }
        public string Service_Description_ar { get; set; }
        // Navigation property
        [JsonIgnore]  // Prevent circular reference
        public ICollection<Area> Areas { get; set; }
    }
}
