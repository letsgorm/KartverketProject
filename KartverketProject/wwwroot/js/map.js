const mapDiv = document.getElementById('map')
if (mapDiv) {
    var map = L.map('map').fitWorld();
    var drawEnabled = map.getContainer().dataset.draw == "true";

    // hent offline kart fra lokal tileserver-gl
    L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
        maxZoom: 18,
        maxNativeZoom: 13,
        attribution: 'OpenStreetMap'
    }).addTo(map);

    // finn brukers sted
    map.locate({ setView: true, maxZoom: 18 });

    function onLocationFound(e) {
        var radius = e.accuracy;

        L.marker(e.latlng).addTo(map)
            .bindPopup("You are here").openPopup();

        L.circle(e.latlng, radius).addTo(map);
    }

    map.on('locationfound', onLocationFound);
    map.on('locationerror', function (e) { alert(e.message); });
}

// globale variabler
var points = [];
var group = L.layerGroup().addTo(map);
var poly = null;
var drawMode = false; // draw mode flag

function addPoint(latlng) {
    points.push(latlng);
    updatePolyline();
    addMarker(latlng);
    updateGeoJSON();
    checkLength();
}

// hvis koordinater sendt
function updatePolyline() {
    if (!poly) {
        poly = L.polyline(points, { color: "green" });
        group.addLayer(poly);
    } else {
        poly.setLatLngs(points);
    }
}

// legg til marker
function addMarker(latlng) {
    const marker = L.marker(latlng);
    marker.bindTooltip("Click to remove marker", { permanent: false, direction: 'top' });
    marker.on('click', function () {
        // fjern alle hvis marker trykket
        group.clearLayers();
        points = [];
        poly = null;
    });
    group.addLayer(marker);
}

function updateGeoJSON() {
    layers = group.toGeoJSON();
}

function checkLength() {
    // hvis mer enn 50 markers
    if (points.length >= 50) {
        group.clearLayers();
        points = [];
        poly = null;
    }
}

if (drawEnabled) {
    // kun legg til punkt hvis draw er true
    map.on('click', function (e) {
        if (drawMode) addPoint(e.latlng);
});


// tegn kontroll
var DrawControl = L.Control.extend({
    onAdd: function (map) {
        var div = L.DomUtil.create('div', 'draw-toggle leaflet-bar');

        // svg pen for ikon
        div.innerHTML = `
        <svg viewBox="0 0 24 24">
            <path d="M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 17.25zM20.71 7.04a1.003 1.003 0 0 0 0-1.41l-2.34-2.34a1.003 1.003 0 0 0-1.41 0l-1.83 1.83 3.75 3.75 1.83-1.83z"/>
        </svg>
        `;

        // forhindre kart fra zoom 
        L.DomEvent.disableClickPropagation(div);

        div.onclick = function () {
            drawMode = !drawMode;
            if (drawMode) {
                div.classList.add('active');
            } else {
                div.classList.remove('active');
            }
        }

        return div;
    },
    onRemove: function (map) { }
});

    map.addControl(new DrawControl({ position: 'topright' }));
}