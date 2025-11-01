using System.Text.Json.Serialization;

namespace KartverketProject.Models
{
    public class Data
    {
        public int DataId { get; set; }
        public string ObstacleJSON { get; set; }
        public int ObstacleId { get; set; } // FK

        // stopp stack overflow 
        [JsonIgnore]
        public Obstacle Obstacle { get; set; } // navigering egenskap
    }
}
