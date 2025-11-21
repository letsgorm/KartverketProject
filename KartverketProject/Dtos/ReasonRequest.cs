using System.ComponentModel.DataAnnotations;

namespace KartverketProject.Dtos
{
    public class ReasonRequest
    {
        public int ReportId { get; set; }

        [MaxLength(1000, ErrorMessage = "Reason is too long")]
        public string? ReportReason { get; set; }
    }
}
