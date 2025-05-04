using Moq;
using NUnit.Framework;
using ED_Monitor.Core.Models;
using ED_Monitor.Core.Interfaces;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Tests;

[TestFixture]
public class SensorDetailViewModelTests
{
    [Test]
    public void SaveCommand_CallsUpdateSensor()
    {
        // Arrange
        var mockService = new Mock<ISensorService>();
        var sensor = new Sensor { Id = 1, Name = "Temp Sensor", Status = "Active" };
        var viewModel = new SensorDetailViewModel(sensor, mockService.Object);

        // Act
        viewModel.SaveCommand.Execute(null);

        // Assert
        mockService.Verify(s => s.UpdateSensor(sensor), Times.Once);
    }
}
