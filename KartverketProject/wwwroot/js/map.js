document.addEventListener("DOMContentLoaded", function () {
    var mapElement = document.getElementById('map');
    if (!mapElement) {
        // Ingen kart på denne siden
        return; // ✅ Nå lovlig
    }


    var map = L.map('map').fitWorld();

    // Lys base
    var lightTiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; OpenStreetMap contributors'
    });

    // Mørk base
    var darkTiles = L.tileLayer('https://{s}.basemaps.cartocdn.com/dark_all/{z}/{x}/{y}{r}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="https://carto.com/">CartoDB</a>'
    });

    // Velg tema basert på dark mode
    var isDark = document.body.classList.contains('darkmode') ||
                 localStorage.getItem('darkmode') === 'active';
    var baseLayer = isDark ? darkTiles : lightTiles;
    baseLayer.addTo(map);

    var points = [];
    var markers = [];
    var group = null;
    let checkpoint = false;

    map.on('click', function (e) {
        if (checkpoint) {
            map.removeLayer(group);
            points = [];
            markers = [];
            group = null;
            checkpoint = false;
        }
        var marker = L.marker(e.latlng).addTo(map);
        markers.push(marker);
        points.push(e.latlng);

        if (points.length == 2) {
            document.getElementById("noMarker").innerText = "";
            var polyline = L.polyline(points, { color: "red" }).addTo(map);
            group = L.layerGroup([markers[0], markers[1], polyline]).addTo(map);
            checkpoint = true;

            if (typeof layers !== 'undefined') {
                layers = group.toGeoJSON();
            }
        }
    });

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

    window.addEventListener('themechange', function (e) {
        var theme = e.detail && e.detail.theme;
        var next = theme === 'dark' ? darkTiles : lightTiles;
        if (map.hasLayer(next)) return;
        if (map.hasLayer(lightTiles)) map.removeLayer(lightTiles);
        if (map.hasLayer(darkTiles)) map.removeLayer(darkTiles);
        next.addTo(map);
    });
});
