using KartverketProject.Models;
using System.Text.Json.Serialization;

public class ReportShare
{
    public int ReportShareId { get; set; }

    public int ReportId { get; set; }        // FK to Report
    public string SharedWithUserId { get; set; }  // FK to User

    [JsonIgnore]
    public Report Report { get; set; }

    [JsonIgnore]
    public User SharedWithUser { get; set; }
}
