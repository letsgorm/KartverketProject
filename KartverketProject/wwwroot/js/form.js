document.querySelector('form').addEventListener('submit', async function (e) {
    // sjekk at markere er satt i gruppen
    if (!group) {
        // stopp formen
        e.preventDefault();
        return;
    }

    // sett dato
    const currentDate = new Date();
    document.getElementById('obstacleSubmittedDate').value = currentDate.toISOString();

    // stringify layers
    const geoJsonString = JSON.stringify(layers);
    document.getElementById('obstacleJson').value = geoJsonString;

    // hent ut verdier
    const form = e.target;
    const data = {
        obstacleName: form.obstacleName.value,
        obstacleHeight: form.obstacleHeight.value,
        obstacleDescription: form.obstacleDescription.value,
        obstacleJson: form.obstacleJson.value,
        obstacleSubmittedDate: form.obstacleSubmittedDate.value
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