using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using DAL.Entity;

namespace NamaaWebSite.Dto
{
   
    public class AreaDto
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Area_Image { get; set; }

        // Foreign key for Service
        public int ServiceId { get; set; }
        public string Area_Description { get; set; }
        public string Area_Description_ar { get; set; }

        public Service? service { get; set; } 



    }
}
