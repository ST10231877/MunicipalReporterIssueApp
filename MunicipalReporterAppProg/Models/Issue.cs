using System;

namespace MunicipalReporterAppProg.Models
{
    // the different states an issue can be in
    public enum IssueStatus { Open, InProgress, Resolved }

    // the types of issues people can report
    public enum IssueCategory
    {
        WaterLeak,
        ElectricityPower,
        RoadsPotholes,
        WasteSanitation,
        Streetlights,
        ParksPublicSpaces,
        Other
    }

    // this class describes one issue that a user reports
    public class Issue
    {
        // a unique ID for this issue
        public Guid Id { get; set; } = Guid.NewGuid();

        // the date/time the issue was created
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // short title of the issue
        public string Title { get; set; }

        // location where the issue happened
        public string Location { get; set; }

        // category of the issue (chosen from the enum above)
        public IssueCategory Category { get; set; }

        // longer description of the problem
        public string Description { get; set; }

        // path to an attached file (photo/doc), if there is one
        public string AttachmentPath { get; set; }

        // the current status of the issue (default = Open)
        public IssueStatus Status { get; set; } = IssueStatus.Open;

        // makes it easy to print the issue as text (for lists/debugging)
        public override string ToString()
            => $"[{Status}] {Title} — {Category} @ {Location}";
    }
}
