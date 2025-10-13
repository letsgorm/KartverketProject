let darkmode = localStorage.getItem('darkmode');
const themeSwitch = document.getElementById('theme-switch');

function enableDarkmode() {
  document.body.classList.add('darkmode');
  localStorage.setItem('darkmode', 'active');
  themeSwitch?.setAttribute('aria-pressed', 'true');
  themeSwitch?.setAttribute('title', 'Enable light mode');
  // notify listeners (e.g., map) that theme changed
  window.dispatchEvent(new CustomEvent('themechange', { detail: { theme: 'dark' } }));
}

function disableDarkmode() {
  document.body.classList.remove('darkmode');
  localStorage.setItem('darkmode', '');
  themeSwitch?.setAttribute('aria-pressed', 'false');
  themeSwitch?.setAttribute('title', 'Enable dark mode');
  // notify listeners (e.g., map) that theme changed
  window.dispatchEvent(new CustomEvent('themechange', { detail: { theme: 'light' } }));
}

// Apply on load (default light unless user chose dark)
if (darkmode === 'active') {
  enableDarkmode();
} else {
  // ensure proper title on page load
  themeSwitch?.setAttribute('title', 'Enable dark mode');
}

// Toggle on click
if (themeSwitch) {
  themeSwitch.addEventListener('click', () => {
    darkmode = localStorage.getItem('darkmode');
    darkmode !== 'active' ? enableDarkmode() : disableDarkmode();
  });
}
