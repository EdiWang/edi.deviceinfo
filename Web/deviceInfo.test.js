const { getDeviceInfo } = require('./deviceInfo');
const { chromium } = require('playwright');

describe('getDeviceInfo', () => {
    let browser;
    let page;

    beforeAll(async () => {
        browser = await chromium.launch({
            channel: 'msedge'
        });
        page = await browser.newPage();
    });

    afterAll(async () => {
        await browser.close();
    });

    it('should return an object with device information', async () => {
        await page.goto('https://edi.wang');
        await page.addScriptTag({ path: './deviceInfo.js' });

        const deviceInfo = await page.evaluate(async () => {
            return getDeviceInfo();
        });

        expect(deviceInfo).toHaveProperty('canvasFingerprint');
        expect(deviceInfo).toHaveProperty('screenResolution');
        expect(deviceInfo).toHaveProperty('screenTotalPixels');
        expect(deviceInfo).toHaveProperty('timeZone');
        expect(deviceInfo).toHaveProperty('userAgent');
        expect(deviceInfo).toHaveProperty('platform');
        expect(deviceInfo).toHaveProperty('platformVersion');
        expect(deviceInfo).toHaveProperty('architecture');

        expect(deviceInfo.screenResolution).toHaveProperty('w');
        expect(deviceInfo.screenResolution).toHaveProperty('h');
        expect(deviceInfo.screenResolution.w).toBeGreaterThan(0);
        expect(deviceInfo.screenResolution.h).toBeGreaterThan(0);
        expect(deviceInfo.screenTotalPixels).toBeGreaterThan(0);

        expect(deviceInfo.timeZone).toBeDefined();
        expect(deviceInfo.timeZone).not.toBe('');

        expect(deviceInfo.userAgent).toBeDefined();
        expect(deviceInfo.userAgent).not.toBe('');

        expect(deviceInfo.platform).toBeDefined();
        expect(deviceInfo.platform).not.toBe('');

        expect(deviceInfo.platformVersion).toBeDefined();
        expect(deviceInfo.platformVersion).not.toBe('');

        expect(deviceInfo.architecture).toBeDefined();
        expect(deviceInfo.architecture).not.toBe('');

        //expect(deviceInfo.canvasFingerprint).toMatch(/^[a-f0-9]{8}$/i);
    });
});