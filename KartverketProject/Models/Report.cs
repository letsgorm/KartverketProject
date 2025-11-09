using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace KartverketProject.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public string UserId { get; set; } // FK

        public int ObstacleId { get; set; } // FK

        // stopp stack overflow 
        [JsonIgnore]
        public User User { get; set; } // navigering egenskap

        // stopp stack overflow 
        [JsonIgnore]
        public Obstacle Obstacle { get; set; } // navigering egenskap
    }
}
