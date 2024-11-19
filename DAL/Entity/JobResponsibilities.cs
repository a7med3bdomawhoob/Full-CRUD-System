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
    public class JobResponsibilities
    {
        [Key]
        public int JobResponsibilities_Id { get; set; }
        [NotMapped]
        public int job_Id { get; set; }  // This will not be included in migration
        [JsonIgnore] // Avoid circular reference
        public Job job { get; set; }
        public string Res1 { get; set; }
        public string? Res2 { get; set; }
        public string? Res3 { get; set; }
        public string? Res4 { get; set; }
        public string? Res5 { get; set; }
        public string? Res6 { get; set; }
        public string? Res7 { get; set; }
        public string? Res8 { get; set; }
        public string? Res9 { get; set; }
        public string? Res10 { get; set; }
    }
}
