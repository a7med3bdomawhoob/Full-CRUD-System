using DAL.Entity;

namespace NamaaWebSite.Dto
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string Project_Description { get; set; }
        public string Project_Description_ar { get; set; }
        public string Image_Name { get; set; }
        public string Project_Name { get; set; }
        public string Project_Name_ar { get; set; }
        public string Client_Name { get; set; }
        public string Location { get; set; }
        public int AreaId { get; set; }



    }
}
