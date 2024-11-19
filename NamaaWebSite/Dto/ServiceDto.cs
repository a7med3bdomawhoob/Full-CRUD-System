using DAL.Entity;

namespace PL.Dto
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Service_Image { get; set; }
        public string Service_Description { get; set; }
        public string Service_Description_ar { get; set; }
    }
}
