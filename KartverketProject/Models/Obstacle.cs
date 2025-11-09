using System.ComponentModel.DataAnnotations;


namespace KartverketProject.Models
{
    public class Obstacle
    {
        public int ObstacleId { get; set; }

        [Required(ErrorMessage = "Please set a name")]
        [MaxLength(100)]
        public string ObstacleName { get; set; }

        [Required(ErrorMessage = "Please set a height")]
        [Range(0, 200)]
        public double ObstacleHeight { get; set; }

        [Required(ErrorMessage = "Please set a description")]
        [MaxLength(1000)]
        public string ObstacleDescription { get; set; }

        public DateTime ObstacleSubmittedDate { get; set; }

        public string ObstacleJSON { get; set; }

        [Required]
        [MaxLength(50)]
        public string ObstacleStatus { get; set; } = "Pending";

        public ICollection<Report> ReportEntries { get; set; } = new List<Report>();
        public ICollection<User> AssignedReviewers { get; set; } = new List<User>();
    }
}