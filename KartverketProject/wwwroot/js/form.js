document.querySelector('form').addEventListener('submit', async function (e) {
    // sjekk at markere er satt i gruppen
    if (points.length == 0) {
        e.preventDefault();
        return;
    }

    // sett dato
    const currentDate = new Date();
    document.getElementById('ObstacleSubmittedDate').value = currentDate.toISOString();

    // stringify layers
    const geoJsonString = JSON.stringify(layers);
    document.getElementById('ObstacleJSON').value = geoJsonString;

    // hent ut verdier
    const form = e.target;
    const data = {
        ObstacleName: form.ObstacleName.value,
        ObstacleHeight: form.ObstacleHeight.value,
        ObstacleDescription: form.ObstacleDescription.value,
        ObstacleJSON: form.ObstacleJSON.value,
        ObstacleSubmittedDate: form.ObstacleSubmittedDate.value
    };

    try {
        // vent til api har fatt data
        const response = await fetch('/api/Kartverket', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            // send formen
            form.submit();
        } else {
            console.log("Form submission failed");
        }
    } catch (err) {
        console.log("Network error")
    }
});