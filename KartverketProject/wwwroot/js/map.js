var map = L.map('map').fitWorld();

// hent offline kart fra lokal tileserver-gl
L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
    maxZoom: 18, // originalt 13 zoom
    attribution: 'OpenStreetMap'
}).addTo(map);

// finn brukers sted
map.locate({ setView: true, maxZoom: 18 });

function onLocationFound(e) {
    // bruker innen stedet
    var radius = e.accuracy;

    L.marker(e.latlng).addTo(map)
        .bindPopup("You are here").openPopup();

    L.circle(e.latlng, radius).addTo(map);
}

map.on('locationfound', onLocationFound);

function onLocationError(e) {
    alert(e.message);
}

map.on('locationerror', onLocationError);

// globale variabler
var points = [];
var group = L.layerGroup().addTo(map);
var draw = false;
var poly = null;

function addPoint(latlng) {
    if (draw) {
        // legg til lat og lng for polyline
        points.push(latlng);
        // oppdater polyline
        updatePolyline();
        // legg til marker med egen ikon
        addMarker(latlng);
        // oppdater geojson
        updateGeoJSON();
        // sjekk at lengden er over 50
        checkLength();
    } else {
        return;
    }
};

function updatePolyline() {
    if (!poly) {
        poly = L.polyline(points, { color: "green" });
    } else {
        poly.setLatLngs(points);
    }
};

function addMarker(latlng) {
    const dotIcon = L.divIcon({
        iconSize: [10, 10],
        iconAnchor: [5, 5]
    });

    var marker = L.marker(latlng, {
        icon: dotIcon
    });

    // legg til lag i gruppen
    group.addLayer(poly);
    group.addLayer(marker);
};

function updateGeoJSON() {
    // lagre objektet til json
    layers = group.toGeoJSON();
};

function checkLength() {
    if (points.length == 50) {
        // fjern alle lag
        group.clearLayers();
        points = [];
    }
};

// legg til punkt hvis draw mode er aktivert
map.on('click', function (e) {
    addPoint(e.latlng);
});

const markTool = document.getElementById('markerIcon');
const trashTool = document.getElementById('trashIcon');

markTool.addEventListener("click", function () {
    // hvis draw er true, sett draw til false og motsatt
    draw = !draw;
    this.classList.toggle('fade-out');
});

trashTool.addEventListener("click", function () {
    // fjern alle lag
    group.clearLayers();
    points = [];
    markerUndone();
});