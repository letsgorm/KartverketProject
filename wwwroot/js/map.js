// Initialiser Kartet
let map = L.map('map').setView([63.4305, 10.3951], 13);

// Definer tile layers
const lightLayer = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; OpenStreetMap contributors'
});
const darkLayer = L.tileLayer('https://{s}.basemaps.cartocdn.com/dark_all/{z}/{x}/{y}{r}.png', {
    attribution: '&copy; OpenStreetMap & CartoDB'
});

// Legg til standard (light) layer
lightLayer.addTo(map);

// Hjelper med å bytte layer
function setMapDarkMode(enabled) {
    if (enabled) {
        map.removeLayer(lightLayer);
        darkLayer.addTo(map);
    } else {
        map.removeLayer(darkLayer);
        lightLayer.addTo(map);
    }
}

// Initial check
setMapDarkMode(document.body.classList.contains('dark-mode'));

// Listen for dark mode toggle
document.getElementById('darkModeToggle')?.addEventListener('click', () => {
    setTimeout(() => { // Wait for class to be toggled
        setMapDarkMode(document.body.classList.contains('dark-mode'));
    }, 10);
});