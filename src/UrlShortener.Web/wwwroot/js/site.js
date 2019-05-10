// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function getUrls() {
    const response = await fetch('/api/v1/short-url/all/' + getBrowserId());
    
    let data = await response.json();
    return data;
}

async function getShortUrl(url) {
    const response = await fetch('/api/v1/short-url/', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ url: url, browserId: getBrowserId() })
    });

    if (!response.ok) {
        return null;
    }

    let data = await response.text();
    return data;
}

function getBrowserId() {
    return getCookie('Browser-Id');
}

function getCookie(name) {
    var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return v ? v[2] : null;
}