using DeviceId;
using DeviceId.Encoders;
using DeviceId.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeviceIdBugRepro.Services
{
    public class DebugService
    {
        public DebugService()
        {
            DeviceId = new DeviceIdBuilder()
                .AddMachineName()
                .AddMacAddress()
                .AddSystemDriveSerialNumber()
                .AddOSInstallationID()
                .UseFormatter(new HashDeviceIdFormatter(() => SHA256.Create(), new Base64UrlByteArrayEncoder()))
                .ToString();
        }

        public string DeviceId { get; }
    }
}
