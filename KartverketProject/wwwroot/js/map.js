var map = L.map('map').fitWorld();

// lag ny kart
L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

var points = [];
var markers = [];
var group = null;
let checkpoint = false;

map.on('click', function(e) {
    // hvis allerede satt, fjern alt
    if(checkpoint) {
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
        layers = group.toGeoJSON();
    }
});

// finn brukers sted
map.locate({setView: true, maxZoom: 16});

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