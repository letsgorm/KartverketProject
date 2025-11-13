using KartverketProject.Models;
using System.Text.Json.Serialization;

public class ReportShare
{
    public int ReportShareId { get; set; }

    public int ReportId { get; set; }        // FK
    public string? SharedWithUserId { get; set; }  // FK

    [JsonIgnore]
    public Report? Report { get; set; }

    [JsonIgnore]
    public User? SharedWithUser { get; set; }
}
