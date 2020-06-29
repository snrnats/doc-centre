const baseUrl = document.getElementById("docfx-style:rel").content;

function switchTheme(e) {
    let theme = "";
    if (e.target.checked) {
        theme = "dark";
    } else {
        theme = "light";
    }

    window.localStorage.setItem("theme", theme);
    window.themeElement.href = getUrl(theme);
}

function getUrl(slug) {
    return baseUrl + "styles/" + slug + ".css";
}

function setInitialTheme(theme) {
    const themeSwitcher = document.getElementById("theme-switcher");
    if (theme == "dark") {
        themeSwitcher.checked = true;
    } else {
        themeSwitcher.checked = false;
    }
}

const themeElement = document.createElement("link");
themeElement.rel = "stylesheet";

const theme = window.localStorage.getItem("theme") || "light";
themeElement.href = getUrl(theme);

document.head.appendChild(themeElement);
window.themeElement = themeElement;

setInitialTheme(theme);

document.addEventListener("DOMContentLoaded", function() {
    const themeSwitcher = document.getElementById("theme-switcher");
    themeSwitcher.addEventListener('change', switchTheme, false);
}, false);