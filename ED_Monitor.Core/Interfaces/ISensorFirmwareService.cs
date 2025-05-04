using System.IO;
using System.Threading.Tasks;

namespace ED_Monitor.Core.Interfaces
{
    public interface ISensorFirmwareService
    {
        Task<bool> UploadFirmwareAsync(Guid sensorId, Stream firmwareStream);
    }
}
