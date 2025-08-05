namespace Portfolio.Web.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }

        public string Title { get; set; }
        public int StartYear { get; set; }
        public string? EndYear { get; set; }
        public string Company { get; set; }
        public String City { get; set; }

        public String Description { get; set; }

    }
}
