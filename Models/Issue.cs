using System.ComponentModel.DataAnnotations;

namespace HelloMvc.Models
{
    public enum Theme
    {
        AnalyzerExperience = 1,
        CodeStyle,
        RefactoringsAndFixes,
        Productivity,
        Navigation,
        CrossLanguage,
    }

    public enum Release
    {
        Dev14Update = 1,
        Dev15,
        Dev16,
        Bucket,
        Eventually,
    }

    public class Issue
    {
        [Key]
        public int GitHubIssueNumber { get; set; }
        public string Title { get; set; }
        public string HtmlUrl { get; set; }
        public Release Milestone { get; set; }
        public Theme Theme { get; set; }
        public int? Priority { get; set; }
        public int? StoryPoints { get; set; }
    }
}