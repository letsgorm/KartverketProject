function dismissReportReason(reportId) {
    const alertDiv = document.getElementById(`report-${reportId}`);
    if (!alertDiv) return;

    // Smooth fade-out før fjerning
    alertDiv.style.transition = "opacity 0.3s ease, transform 0.3s ease";
    alertDiv.style.opacity = 0;
    alertDiv.style.transform = "translateX(20px)";

    setTimeout(() => alertDiv.remove(), 300);
}