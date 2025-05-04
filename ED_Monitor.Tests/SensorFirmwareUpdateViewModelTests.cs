using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ED_Monitor.Core.Interfaces;
using ED_Monitor.Core.Models;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Tests
{
    public class SensorFirmwareUpdateViewModelTests
    {
        [Test]
        public async Task UploadFirmwareAsync_WithValidSensorAndStream_UpdatesStatusMessage()
        {
            // Arrange
            var firmwareMock = new Mock<ISensorFirmwareService>();
            var sensorMock = new Mock<ISensorService>();

            firmwareMock
                .Setup(s => s.UploadFirmwareAsync(It.IsAny<Guid>(), It.IsAny<Stream>()))
                .ReturnsAsync(true);

            var viewModel = new SensorFirmwareUpdateViewModel(firmwareMock.Object, sensorMock.Object);
            var testSensor = new Sensor { Id = Guid.NewGuid(), Model = "X1", Location = "Lab" };
            viewModel.SelectedSensor = testSensor;

            using var testStream = new MemoryStream(new byte[] { 0x01, 0x02 });
            viewModel.SetSelectedFile("firmware.bin", testStream);

            // Act
            await viewModel.UploadCommand.ExecuteAsync(null);

            // Assert
            Assert.AreEqual("Upload successful.", viewModel.StatusMessage);
        }
    }
}
