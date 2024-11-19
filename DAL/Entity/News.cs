using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class News
    {
        public int Id { get; set; } 
        public string News_Title { get; set; }
        public string News_Title_ar { get; set; }
        public string News_Description { get; set; }
        public string News_Description_ar { get; set; }
        public string Date {  get; set; }   
        public string Image_Name { get; set;}
    }
}
