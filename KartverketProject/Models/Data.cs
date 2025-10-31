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
        public ObstacleData Obstacle { get; set; } // navigering egenskap
    }
}
