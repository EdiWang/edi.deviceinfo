function getCanvasFingerprint() {
    var canvas = document.createElement('canvas');
    var ctx = canvas.getContext('2d');

    canvas.width = 2000;
    canvas.height = 200;
    canvas.style.display = 'inline';

    ctx.fillStyle = 'rgb(102, 204, 0)';
    ctx.fillRect(0, 0, 2000, 100);
    ctx.fillStyle = 'rgb(0, 153, 255)';
    ctx.fillRect(0, 100, 2000, 100);

    ctx.textBaseline = 'top';
    ctx.font = '14px \'Arial\'';
    ctx.fillStyle = '#f60';
    ctx.fillRect(125, 1, 62, 20);
    ctx.fillStyle = '#069';
    ctx.fillText('Hello, world!', 2, 15);
    ctx.fillStyle = 'rgba(102, 204, 0, 0.7)';
    ctx.fillText('Hello, world!', 4, 17);

    var dataURL = canvas.toDataURL();
    return hashCanvasData(dataURL);
}

function hashCanvasData(data) {
    var hashObject = new TextEncoder().encode(data);
    return crypto.subtle.digest('SHA-256', hashObject).then(function (hashBuffer) {
        var hashArray = Array.from(new Uint8Array(hashBuffer));
        var hashHex = hashArray.map(b => b.toString(16).padStart(2, '0')).join('');
        return hashHex;
    });
}

function getScreenResolution() {
    return {
        w: screen.width,
        h: screen.height
    }
}

function getTimeZone() {
    return Intl.DateTimeFormat().resolvedOptions().timeZone;
}

async function getDeviceFingerprint() {
    var cf = await getCanvasFingerprint();
    return {
        canvas: cf,
        resolution: getScreenResolution(),
        timezone: getTimeZone()
    };
}