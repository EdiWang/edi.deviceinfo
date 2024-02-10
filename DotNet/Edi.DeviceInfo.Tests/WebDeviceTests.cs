using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Edi.DeviceInfo.Tests;

[TestClass]
public class WebDeviceTests
{
    [TestMethod]
    public void GetDeviceHash_IgnoreScreenRotationAndPlatformVersion_ReturnsExpectedHash()
    {
        // Arrange
        var webDevice = new WebDevice
        {
            CanvasFingerprint = "abc123",
            ScreenResolution = new ScreenResolution(1920, 1080),
            ScreenTotalPixels = 2073600,
            TimeZone = "UTC",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            Platform = "Windows",
            PlatformVersion = "10.0",
            Architecture = "x64"
        };

        var expectedHash = "iqhIHfv3LEm4gc4mNQ/sDvG7f9yBT/SDzcPKBgSSO2I=";

        // Act
        var actualHash = webDevice.GetDeviceHash();

        // Assert
        Assert.AreEqual(expectedHash, actualHash);
    }

    [TestMethod]
    public void GetDeviceHash_WithScreenRotation_ExpectedHash()
    {
        // Arrange
        var webDevice = new WebDevice
        {
            CanvasFingerprint = "abc123",
            ScreenResolution = new ScreenResolution(1920, 1080),
            ScreenTotalPixels = 2073600,
            TimeZone = "UTC",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            Platform = "Windows",
            PlatformVersion = "10.0",
            Architecture = "x64"
        };

        var expectedHash = "z8AY7gny9Z4o605s13PsGXwkR6lP+KWAzbkMcFrie4g=";

        // Act
        var actualHash = webDevice.GetDeviceHash(ignoreScreenRotation: false);

        // Assert
        Assert.AreEqual(expectedHash, actualHash);
    }

    [TestMethod]
    public void GetDeviceHash_WithPlatformVersion_ReturnsExpectedHash()
    {
        // Arrange
        var webDevice = new WebDevice
        {
            CanvasFingerprint = "abc123",
            ScreenResolution = new ScreenResolution(1920, 1080),
            ScreenTotalPixels = 2073600,
            TimeZone = "UTC",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            Platform = "Windows",
            PlatformVersion = "10.0",
            Architecture = "x64"
        };

        var expectedHash = "5USsFCIMPfAC9WF4Paa9ZVeZSs7dUuInoXPM79ke4xY=";

        // Act
        var actualHash = webDevice.GetDeviceHash(ignorePlatformVersion: false);

        // Assert
        Assert.AreEqual(expectedHash, actualHash);
    }
}