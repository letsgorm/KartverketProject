var map = L.map('map').fitWorld();

// hent offline kart fra lokal tileserver-gl
L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
    maxZoom: 18,
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

// globale variabler
var points = [];
var group = L.layerGroup().addTo(map);
var poly = null;

function addPoint(latlng) {
    // legg til lat og lng for polyline
    points.push(latlng);

    // oppdater polyline
    updatePolyline();

    // legg til marker med click-event
    addMarker(latlng);

    // oppdater geojson
    updateGeoJSON();

    // sjekk at lengden er over 50
    checkLength();
}

function updatePolyline() {
    if (!poly) {
        poly = L.polyline(points, { color: "green" });
        group.addLayer(poly);
    } else {
        poly.setLatLngs(points);
    }
}

function addMarker(latlng) {
    const marker = L.marker(latlng);

    // when marker is clicked, remove marker + polyline
    marker.on('click', function () {
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
    if (points.length >= 50) {
        group.clearLayers();
        points = [];
        poly = null;
    }
}

// legg til punkt hvis draw mode er aktivert
map.on('click', function (e) {
    addPoint(e.latlng);
});
