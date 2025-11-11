using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace KartverketProject.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public string? UserId { get; set; } // FK, null siden rapport kan eksistere uten bruker

        public int ObstacleId { get; set; } // FK

        public string? ReportReason { get; set; }

        public bool ReportReasonSeen { get; set; } = false; // bruker har ikke sitt rapport


        [JsonIgnore]
        public User User { get; set; } 

        [JsonIgnore]
        public Obstacle Obstacle { get; set; }

        public ICollection<ReportShare> SharedWith { get; set; } = new List<ReportShare>();
    }
}
