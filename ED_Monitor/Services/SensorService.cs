using System;
using System.Collections.Generic;
using System.Linq;
using ED_Monitor.Interfaces;
using ED_Monitor.Models;

namespace ED_Monitor.Services
{
    public class SensorService : ISensorService
    {
        // In-memory list to simulate a database
        private readonly List<Sensor> _sensors = new();

        public IEnumerable<Sensor> GetSensors()
        {
            return _sensors;
        }

        public Sensor? GetSensorById(Guid id)
        {
            return _sensors.FirstOrDefault(s => s.Id == id);
        }

        public void AddSensor(Sensor sensor)
        {
            _sensors.Add(sensor);
        }

        public void RemoveSensor(Guid id)
        {
            var sensor = _sensors.FirstOrDefault(s => s.Id == id);
            if (sensor != null)
                _sensors.Remove(sensor);
        }

        public void UpdateSensor(Sensor updatedSensor)
        {
            var existing = _sensors.FirstOrDefault(s => s.Id == updatedSensor.Id);
            if (existing != null)
            {
                existing.Model = updatedSensor.Model;
                existing.Location = updatedSensor.Location;
            }
        }
    }
}
