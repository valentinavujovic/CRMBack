namespace CRMSYSTEMBACK.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String ProjectTitle { get; set; }
        public String ProjectDescription { get; set; }
        public String Projectdeadline { get; set; }    
        public String ProjectStatus { get; set; }
        public string users_id { get; set; }
    }
}
