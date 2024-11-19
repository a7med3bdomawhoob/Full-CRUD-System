using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class JobRequirements
    {
        [Key]
        public int JobRequirements_Id { get; set; }
        [NotMapped]
        public int job_Id { get; set; }  // This will not be included in migration
        [JsonIgnore] // Avoid circular reference
        public Job job { get; set; }
        public string Req1 { get; set; }
        public string? Req2 { get; set; }
        public string? Req3 { get; set; }
        public string? Req4 { get; set; }
        public string? Req5 { get; set; }
        public string? Req6 { get; set; }
        public string? Req7 { get; set; }
        public string? Req8 { get; set; }
        public string? Req9 { get; set; }
        public string? Req10 { get; set; }


    }
}
