var mapElement = document.getElementById('map');
if (!mapElement) {
    // No map on this page; nothing to do
    return;
}

var map = L.map('map').fitWorld();

// Lys base
var lightTiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; OpenStreetMap contributors'
});

// Mørk base (CartoDB Dark Matter)
var darkTiles = L.tileLayer('https://{s}.basemaps.cartocdn.com/dark_all/{z}/{x}/{y}{r}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="https://carto.com/">CartoDB</a>'
});

// Velg starttema basert på dark mode
var isDark = document.body.classList.contains('darkmode') ||
             localStorage.getItem('darkmode') === 'active';
var baseLayer = isDark ? darkTiles : lightTiles;
baseLayer.addTo(map);

var points = [];
var markers = [];
var group = null;
let checkpoint = false;

map.on('click', function (e) {
    // hvis allerede satt, fjern alt
    if (checkpoint) {
        map.removeLayer(group);
        points = [];
        markers = [];
        group = null;
        checkpoint = false;
    }
    // legg til ny marker, og legg de til arrays
    var marker = L.marker(e.latlng).addTo(map);
    markers.push(marker);
    points.push(e.latlng);

    // hvis to markers er satt
    if(points.length == 2) {
        var polyline = L.polyline(points, {color: "red"}).addTo(map);
        group = L.layerGroup([markers[0], markers[1], polyline]).addTo(map);
        checkpoint = true;
        // lagre til geojson som vi lagrer etterpo i hidden field
        if (typeof layers !== 'undefined') {
            layers = group.toGeoJSON();
        }
    }
});

// Finn brukerposisjon
map.locate({ setView: true, maxZoom: 16 });

function onLocationFound(e) {
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

// 🟢 Bytt karttema når dark mode endres
window.addEventListener('themechange', function (e) {
    var theme = e.detail && e.detail.theme;
    var next = theme === 'dark' ? darkTiles : lightTiles;
    if (map.hasLayer(next)) return;
    if (map.hasLayer(lightTiles)) map.removeLayer(lightTiles);
    if (map.hasLayer(darkTiles)) map.removeLayer(darkTiles);
    next.addTo(map);
});