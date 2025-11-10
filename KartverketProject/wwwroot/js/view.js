let currentObstacleId = 0;
let obstacleMap;

async function openViewPanel(obstacleId) {
    currentObstacleId = obstacleId;

    // Fetch obstacle details from server
    const response = await fetch(`/Account/GetObstacleDetails?obstacleId=${obstacleId}`);
    const data = await response.json();

    document.getElementById('panelObstacleName').innerText = data.obstacleName;
    document.getElementById('panelObstacleDetails').innerHTML = `
        <p><strong>Department:</strong> ${data.department}</p>
        <p><strong>User:</strong> ${data.email}</p>
        <p><strong>Submitted:</strong> ${data.date}</p>
        <p><strong>Status:</strong> ${data.status}</p>
        <p><strong>Description:</strong> ${data.description}</p>
        <p><strong>Shared with:</strong> ${data.sharedWith.join(', ') || '—'}</p>
    `;

    const panel = document.getElementById('viewPanel');
    panel.classList.remove('translate-y-full');

    // Render map
    // Render Leaflet map inside openViewPanel()
    const mapContainer = document.getElementById('panelObstacleMap');
    mapContainer.innerHTML = '';

    // Create map and a LayerGroup
    obstacleMap = L.map(mapContainer).setView([0, 0], 2);
    const group = L.layerGroup().addTo(obstacleMap);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(obstacleMap);

    if (data.obstacleJSON) {
        try {
            const jsonData = JSON.parse(data.obstacleJSON);

            // Check that there are features
            if (jsonData.features && jsonData.features.length > 0) {
                const geoLayer = L.geoJSON(jsonData).addTo(group);
                obstacleMap.fitBounds(geoLayer.getBounds(), { padding: [20, 20] });
            }
        } catch (err) {
            console.error('Invalid ObstacleJSON', err);
        }
    }

    // Buttons
    document.getElementById('approveBtn').onclick = async () => {
        const dto = {
            id: currentObstacleId,
            newStatus: "Approved",
            reportReason: null
        };

        await fetch('/Account/ReportStatus', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dto)
        });

        window.location.reload();
    };

    document.getElementById('rejectBtn').onclick = async () => {
        const reason = prompt("Enter reason for rejection:");
        const dto = {
            id: currentObstacleId,
            newStatus: "Rejected",
            reportReason: reason
        };

        await fetch('/Account/ReportStatus', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dto)
        });

        window.location.reload();
    };

}

function closeViewPanel() {
    const panel = document.getElementById('viewPanel');
    panel.classList.add('translate-y-full');
    closeShareInline();
}

async function openShareInline() {
    const form = document.getElementById('shareFormInline');
    form.classList.remove('hidden');

    // Set the current report ID for both Share and Stop Sharing
    document.getElementById('reportIdInput').value = currentObstacleId;

    // Fetch reviewers dynamically
    const response = await fetch(`/Account/GetReviewersForSharing?obstacleId=${currentObstacleId}`);
    const reviewers = await response.json();

    const select = document.getElementById('reviewersSelect');
    select.innerHTML = '';
    reviewers.forEach(r => {
        const option = document.createElement('option');
        option.value = r.id;
        option.text = r.email;
        select.appendChild(option);
    });
}

function closeShareInline() {
    document.getElementById('shareFormInline').classList.add('hidden');
}