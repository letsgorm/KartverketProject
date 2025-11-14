using KartverketProject.Models;
using System.ComponentModel.DataAnnotations;


namespace KartverketProject.Dtos
{
    public class ObstacleRequest
    {
        // hindre
        public int ObstacleId { get; set; }

        [MaxLength(100)]
        public string? ObstacleName { get; set; }

        [MaxLength(1000)]
        public string? ObstacleDescription { get; set; }

        public DateTime ObstacleSubmittedDate { get; set; }

        // rapporter
        public int ReportId { get; set; }

        [MaxLength(50)]
        public string ReportStatus { get; set; } = "Pending";

        public string? ReportReason { get; set; }

        // bruker
        public string UserName { get; set; } = "";

        public string? Department { get; set; }

        public ICollection<Report> ReportEntries { get; set; } = new List<Report>();
    }
}