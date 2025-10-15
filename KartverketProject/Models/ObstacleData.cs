using System.ComponentModel.DataAnnotations;

public class ObstacleData
{
    public int obstacleId { get; set; }

    [Required(ErrorMessage = "Field is required")]
    [MaxLength(100)]
    public string obstacleName { get; set; }

    [Required(ErrorMessage = "Field is required")]
    [Range(0, 200)]
    public double obstacleHeight { get; set; }

    [Required(ErrorMessage = "Field is required")]
    [MaxLength(1000)]
    public string obstacleDescription { get; set; }

    public DateTime obstacleSubmittedDate { get; set; }

    [Required(ErrorMessage = "Field is required")]
    public string obstacleJson { get; set; }
}
