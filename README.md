# edi-devicefingerprint

## Installation

```bash
npm install edi-devicefingerprint
```

## Usage

```javascript
const deviceFingerprint = require('edi-devicefingerprint');

const deviceInfo = await deviceFingerprint.getDeviceInfo();

const canvasFingerprint = await deviceFingerprint.getCanvasFingerprint();
const resolution = deviceFingerprint.getScreenResolution();
const timeZone = deviceFingerprint.getTimeZone();
```