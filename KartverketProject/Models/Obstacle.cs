using System.ComponentModel.DataAnnotations;


namespace KartverketProject.Models
{
    public class Obstacle
    {
        public int ObstacleId { get; set; }

        [MaxLength(100)]
        public string? ObstacleName { get; set; }

        [Range(0.0, 200.0)]
        public double? ObstacleHeight { get; set; }

        [MaxLength(1000)]
        public string? ObstacleDescription { get;  set; }

        public DateTime ObstacleSubmittedDate { get; set; }

        public string? ObstacleJSON { get; set; }

        public ICollection<Report> ReportEntries { get; set; } = new List<Report>();
    }
}