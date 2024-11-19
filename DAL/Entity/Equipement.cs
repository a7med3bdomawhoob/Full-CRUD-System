using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Equipement
    {
        public int Id { get; set; } 
        public string Equipement_Name { get; set; }
        public string Equipement_Name_ar { get; set; }
        public string Equipement_Description { get; set; }
        public string Equipement_Description_ar { get; set; }
        public string Image_Name { get; set; }
        public string Equipement_Parts { get; set; }
        public string Equipement_Parts_ar { get; set; }
        public string Equipement_Functions { get; set; }
        public string Equipement_Functions_ar { get; set; }
    }
}
