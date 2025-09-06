namespace Portfolio.Web.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; } 
        public string GithubUrl { get; set; }          
        public string LinkedInUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
