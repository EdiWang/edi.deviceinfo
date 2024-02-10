using System.Security.Cryptography;
using System.Text;

namespace Edi.DeviceInfo;

public class WebDevice
{
    public string CanvasFingerprint { get; set; }
    public ScreenResolution ScreenResolution { get; set; }
    public long ScreenTotalPixels { get; set; }
    public string TimeZone { get; set; }
    public string UserAgent { get; set; }
    public string Platform { get; set; }
    public string PlatformVersion { get; set; }
    public string Architecture { get; set; }

    public string GetDeviceHash(bool ignoreScreenRotation = true, bool ignorePlatformVersion = true)
    {
        var screenInfo = ignoreScreenRotation ? $"{ScreenTotalPixels}" : $"{ScreenResolution.W}x{ScreenResolution.H}";
        var platformInfo = ignorePlatformVersion ? $"{Platform}" : $"{Platform}{PlatformVersion}";

        SHA256 sha256 = SHA256.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes($"{CanvasFingerprint}{screenInfo}{TimeZone}{platformInfo}");
        byte[] hash = sha256.ComputeHash(inputBytes);

        return Convert.ToBase64String(hash);
    }
}

public record ScreenResolution(int W, int H);
