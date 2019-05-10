// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// gets all urls for the current browser
async function getUrls() {
    const response = await fetch('/api/v1/short-url/all/' + getBrowserId());
    
    return await response.json();
}

// creates shortened url for specific url
async function getSlug(url) {
    const response = await fetch('/api/v1/short-url/', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ url: url, userId: getBrowserId() })
    });

    if (!response.ok) {
        return null;
    }

    return await response.text();
}

// get's browser ID
function getBrowserId() {
    return getCookie('Browser-Id');
}

// reads a single cookie
function getCookie(name) {
    const v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return v ? v[2] : null;
}