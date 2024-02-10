# edi.deviceinfo

## Installation

```bash
npm install edi.deviceinfo
```

## Usage

```javascript
const deviceInfo = require('edi.deviceinfo');

const info = await deviceInfo.getDeviceInfo();

// Result example:
// {
//     canvasFingerprint: 'a1b2c3d4',
//     screenResolution: {
//         w: 1920,
//         h: 1080
//     },
//     screenTotalPixels: 2073600,
//     timeZone: 'America/New_York',
//     userAgent: 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36',
//     platform: 'Windows',
//     platformVersion: '15.0',
//     architecture: 'x86'
// }

```