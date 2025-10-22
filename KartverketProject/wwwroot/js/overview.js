var map = L.map('map-overview').setView([0, 0], 2);
L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; OpenStreetMap'
}).addTo(map);

var sanitizedJson = JSON.parse('@Html.Raw(sanitizedJson.Replace("'", "\\'"))');

// legg til ny kart
if (sanitizedJson) {
    var layer = L.geoJSON(sanitizedJson).addTo(map);
    map.fitBounds(layer.getBounds());
} else {
    console.warn("No geometry data found");
}