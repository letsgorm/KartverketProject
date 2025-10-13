// Handles DataForm submission and validation
(function () {
  const form = document.querySelector('form[method="post"][asp-action="DataForm"], form[action*="DataForm"]') || document.querySelector('form');
  if (!form) return;

  function updateObstacleJSON() {
    try {
      const geo = typeof layers !== 'undefined' ? layers : {};
      document.getElementById('ObstacleJSON').value = JSON.stringify(geo);
    } catch { /* ignore */ }
  }

  function updateObstacleDate() {
    document.getElementById('ObstacleSubmittedDate').value = new Date().toISOString();
  }

  form.addEventListener('submit', async function (e) {
    if (!e.target.checkValidity()) {
      return;
    }
    e.preventDefault();

    updateObstacleJSON();
    updateObstacleDate();

    const geoJsonString = document.getElementById('ObstacleJSON').value;
    const errorMarker = document.getElementById('noMarker');
    if (!geoJsonString.length || geoJsonString === '{}') {
      if (errorMarker) errorMarker.innerText = 'Please add at least two markers';
      return;
    } else if (errorMarker) {
      errorMarker.innerText = '';
    }

    const data = {
      ObstacleName: form.ObstacleName?.value,
      ObstacleHeight: form.ObstacleHeight?.value,
      ObstacleDescription: form.ObstacleDescription?.value,
      ObstacleJSON: form.ObstacleJSON?.value,
      ObstacleSubmittedDate: form.ObstacleSubmittedDate?.value
    };

    try {
      const response = await fetch('/api/Kartverket', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
      });
      if (response.ok) {
        form.submit();
      } else {
        if (errorMarker) errorMarker.innerText = 'Submission failed. Please try again.';
      }
    } catch {
      if (errorMarker) errorMarker.innerText = 'Network error. Please try again.';
    }
  });
})();
