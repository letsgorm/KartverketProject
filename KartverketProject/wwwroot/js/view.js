let currentObstacleId = 0;
let obstacleMap;

async function openViewPanel(obstacleId) {
    currentObstacleId = obstacleId;

    // Fetch obstacle details
    const response = await fetch(`/Account/GetObstacleDetails?obstacleId=${obstacleId}`);
    const data = await response.json();

    document.getElementById('panelObstacleName').innerText = data.obstacleName;
    document.getElementById('panelObstacleDetails').innerHTML = `
        <p><strong>Department:</strong> ${data.department}</p>
        <p><strong>User:</strong> ${data.username}</p>
        <p><strong>Submitted:</strong> ${data.date}</p>
        <p><strong>Status:</strong> ${data.status}</p>
        <p><strong>Description:</strong> ${data.description}</p>
        <p><strong>Shared with:</strong> ${data.sharedWith.join(', ') || '—'}</p>
    `;

    // Show panel
    const panel = document.getElementById('viewPanel');
    panel.classList.remove('translate-y-full');

    // Render map
    const mapContainer = document.getElementById('panelObstacleMap');
    mapContainer.innerHTML = '';
    obstacleMap = L.map(mapContainer).setView([0, 0], 2);
    const group = L.layerGroup().addTo(obstacleMap);

    L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
        maxZoom: 18,
        attribution: 'OpenStreetMap'
    }).addTo(obstacleMap);

    if (data.obstacleJSON) {
        try {
            const jsonData = JSON.parse(data.obstacleJSON);
            if (jsonData.features && jsonData.features.length > 0) {
                const geoLayer = L.geoJSON(jsonData).addTo(group);
                obstacleMap.fitBounds(geoLayer.getBounds(), { padding: [20, 20] });
            }
        } catch (err) {
            console.error('Invalid ObstacleJSON', err);
        }
    }

    // Approve / Reject buttons submit form
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

    // Add this to hook up share button
    document.getElementById('shareBtn').onclick = () => {
        openShareInline();
    };

    const reasonBox = document.getElementById('ReportReason')
    if (reasonBox) {
        reasonBox.value = data.reportReason || "";
    }

}

function closeViewPanel() {
    document.getElementById('viewPanel').classList.add('translate-y-full');
    closeShareInline();
}

function submitStatus(newStatus) {
    const form = document.getElementById('updateStatusForm');
    document.getElementById('statusReportIdInput').value = currentObstacleId;
    document.getElementById('statusNewStatusInput').value = newStatus;
    form.submit();
}

async function openShareInline() {
    const form = document.getElementById('shareFormInline');
    form.classList.remove('hidden');

    document.getElementById('reportIdInput').value = currentObstacleId;

    // Fetch reviewers dynamically
    const response = await fetch(`/Account/GetReviewersForSharing?obstacleId=${currentObstacleId}`);
    const reviewers = await response.json();

    const select = document.getElementById('reviewersSelect');
    select.innerHTML = '';
    reviewers.forEach(r => {
        const option = document.createElement('option');
        option.value = r.id;
        option.text = r.username;
        select.appendChild(option);
    });
}

function closeShareInline() {
    document.getElementById('shareFormInline').classList.add('hidden');
}