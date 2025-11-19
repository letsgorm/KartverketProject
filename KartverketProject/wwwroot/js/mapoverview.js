// lag kart
var map = L.map('map-overview').setView([0, 0], 2);

// offline kart
L.tileLayer('http://localhost:8080/styles/basic-preview/512/{z}/{x}/{y}.png', {
    maxZoom: 18,
    attribution: 'OpenStreetMap'
}).addTo(map);

// hent model
const jsonText = document.getElementById("obstacle-json").textContent

// lag ny parser
let parser = new DOMParser();

// parse string som tekst
let decoded = parser.parseFromString(jsonText, "text/html").documentElement.textContent;

// parse objektet til geojson
var geoData = JSON.parse(decoded);

// legg til kart
if (geoData && geoData.features && geoData.features.length > 0) {
    var layer = L.geoJSON(geoData).addTo(map);
    map.fitBounds(layer.getBounds(), { padding: [20, 20] });
} else {
    console.warn("No geometry data found");
}