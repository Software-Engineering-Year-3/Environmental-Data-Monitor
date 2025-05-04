using System.Collections.Generic;
using System.Threading.Tasks;
using ED_Monitor.Core.Models;

namespace ED_Monitor.Core.Interfaces
{
    public interface ISensorStatusService
    {
        Task<IEnumerable<SensorStatus>> GetAllStatusesAsync();
    }
}
