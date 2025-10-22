var map = L.map('map').fitWorld();

// lag ny kart
L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

// finn brukers sted
map.locate({ setView: true, maxZoom: 16 });

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

// lag array av punkter og gruppe for lag
var points = [];
var group = L.layerGroup().addTo(map);

map.on('click', function (e) {
    points.push(e.latlng);

    var poly = L.polyline(points, { color: "blue" });
    var marker = L.marker(e.latlng);
    group.addLayer(poly);
    group.addLayer(marker);
    // lagre objektet til json
    layers = group.toGeoJSON();

    if (points.length > 0) {
        // fjern varsel
        markerWarning = document.getElementById("noMarker");
        markerWarning.innerHTML = "";
    }
    if (points.length == 50) {
        // fjern alle lag
        group.clearLayers();
        points = [];
    }
});

const reset = document.getElementById('resetMap');

reset.addEventListener("click", function () {
    // fjern alle lag
    group.clearLayers();
    points = [];
});