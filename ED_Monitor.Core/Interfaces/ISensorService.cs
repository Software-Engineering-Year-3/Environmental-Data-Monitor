using System;
using System.Collections.Generic;
using ED_Monitor.Core.Models;

namespace ED_Monitor.Core.Interfaces
{
    public interface ISensorService
    {
        IEnumerable<Sensor> GetSensors();
        Sensor? GetSensorById(Guid id);
        void AddSensor(Sensor sensor);
        void RemoveSensor(Guid id);
        void UpdateSensor(Sensor sensor);
    }
}
