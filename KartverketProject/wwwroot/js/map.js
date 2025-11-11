var map = L.map('map').fitWorld();

// offline kart
L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
    maxZoom: 18,
    attribution: 'OpenStreetMap'
}).addTo(map);

// finn posisjon
map.locate({ setView: true, maxZoom: 18, timeout: 10000 }); // timeout for sikkerhet

// poisjson aktivert
map.on('locationfound', function (e) {
    var radius = e.accuracy;

    L.marker(e.latlng).addTo(map)
        .bindPopup("Du er her").openPopup();

    L.circle(e.latlng, radius).addTo(map);
});

// globale variabler for tegning
var points = [];
var group = L.layerGroup().addTo(map);
var poly = null;

// kegg til punkt ved klikk hvis draw-mode er aktivert
map.on('click', function (e) {
    addPoint(e.latlng);
});

function addPoint(latlng) {
    points.push(latlng);      // legg til i polyline
    updatePolyline();         // oppdater linje
    addMarker(latlng);        // legg til markor med click-handler
    updateGeoJSON();          // oppdater geojson
    checkLength();            // auto-clear hvis for mange punkter
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
    // klikk på markør sletter alle punkter og polyline
    marker.on('click', function () {
        group.clearLayers();
        points = [];
        poly = null;
    });
    group.addLayer(marker);
}

function updateGeoJSON() {
    var layers = group.toGeoJSON(); // lagre/oppdater geojson om nødvendig
}

function checkLength() {
    if (points.length >= 50) {
        group.clearLayers();
        points = [];
        poly = null;
    }
}
