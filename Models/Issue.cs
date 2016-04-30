namespace HelloMvc.Models
{
    public class Issue
    {
        public int GitHubIssueNumber { get; set; }
        public string Title { get; set; }
        public string HtmlUrl { get; set; }
        public string Milestone { get; set; }
        public int? Priority { get; set; }
        public int? StoryPoints { get; set; }
    }
}