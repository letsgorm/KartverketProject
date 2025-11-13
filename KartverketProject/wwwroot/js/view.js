let currentObstacleId = 0;
let obstacleMap;

async function openViewPanel(obstacleId) {
    currentObstacleId = obstacleId;

    // hent opp json fra GetObstacleDetails
    const response = await fetch(`/Account/GetObstacleDetails?obstacleId=${obstacleId}`);
    const data = await response.json();

    // fyll ut data
    document.getElementById('panelObstacleName').innerText = data.obstacleName;
    document.getElementById('panelObstacleDetails').innerHTML = `
        <p><strong>Department:</strong> ${data.department}</p>
        <p><strong>User:</strong> ${data.username}</p>
        <p><strong>Submitted:</strong> ${data.date}</p>
        <p><strong>Status:</strong> ${data.status}</p>
        <p><strong>Description:</strong> ${data.description}</p>
        <p><strong>Shared with:</strong> ${data.sharedWith.join(', ') || '—'}</p>
    `;

    // vis panel
    const panel = document.getElementById('viewPanel');
    panel.classList.remove('translate-y-full');

    // lag kart
    const mapContainer = document.getElementById('panelObstacleMap');
    mapContainer.innerHTML = '';
    obstacleMap = L.map(mapContainer).setView([0, 0], 2);
    const group = L.layerGroup().addTo(obstacleMap);

    // offline kart
    L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
        maxZoom: 18,
        attribution: 'OpenStreetMap'
    }).addTo(obstacleMap);

    // hvis json eksisterer
    if (data.obstacleJSON) {
        try {
            const jsonData = JSON.parse(data.obstacleJSON);
            // sjekk om kart har data
            if (jsonData.features && jsonData.features.length > 0) {
                const geoLayer = L.geoJSON(jsonData).addTo(group);
                obstacleMap.fitBounds(geoLayer.getBounds(), { padding: [20, 20] });
            }
        } catch (err) {
            console.error('Invalid ObstacleJSON', err);
        }
    }

    // godkjenn eller avvis rapport
    document.getElementById('approveBtn').onclick = () => {
        document.getElementById('statusReportIdInput').value = currentObstacleId;
        document.getElementById('statusNewStatusInput').value = 'Approved';
        document.getElementById('updateStatusForm').submit();
    };

    document.getElementById('rejectBtn').onclick = () => {
        document.getElementById('statusReportIdInput').value = currentObstacleId;
        document.getElementById('statusNewStatusInput').value = 'Rejected';
        document.getElementById('updateStatusForm').submit();
    };

    // del rapport
    document.getElementById('shareBtn').onclick = () => {
        openShareInline();
    };

    // skriv inn begrunnelse
    const reasonBox = document.getElementById('ReportReason')
    if (reasonBox) {
        reasonBox.value = data.reportReason || "";
    }

}

// lukk ned rapporten smooothly
function closeViewPanel() {
    document.getElementById('viewPanel').classList.add('translate-y-full');
    closeShareInline();
}

// oppdater status
function submitStatus(newStatus) {
    const form = document.getElementById('updateStatusForm');
    document.getElementById('statusReportIdInput').value = currentObstacleId;
    document.getElementById('statusNewStatusInput').value = newStatus;
    form.submit();
}

// gjor deling synlig
async function openShareInline() {
    const form = document.getElementById('shareFormInline');
    form.classList.remove('hidden');

    document.getElementById('reportIdInput').value = currentObstacleId;

    // hent opp reviewers
    const response = await fetch(`/Account/GetReviewersForSharing?obstacleId=${currentObstacleId}`);
    const reviewers = await response.json();

    // hent opp valgte reviewers
    const select = document.getElementById('reviewersSelect');
    select.innerHTML = '';

    // legg til reviewers
    reviewers.forEach(r => {
        const option = document.createElement('option');
        option.value = r.id;
        option.text = r.username;
        select.appendChild(option);
    });
}

// gjem share
function closeShareInline() {
    document.getElementById('shareFormInline').classList.add('hidden');
}