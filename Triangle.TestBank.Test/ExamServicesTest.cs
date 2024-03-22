using System;
using Xunit;
using Moq;
using Triangle.TestBank.Data.Services;
using Triangle.TestBank.Data;
using Azure.Storage.Blobs;

namespace Triangle.TestBank.Test
{
    public class ExamServicesTest
    {

     
        [Fact]
        public void HealthTest()
        {
            // Arrange
            var envioConnectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            var envioContainerName = Environment.GetEnvironmentVariable("AZURE_CONTAINER");
            var envioBlobName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT");
            var mockDbContext = new Mock<AppDbContext>();
            var mockBlob = new Mock<BlobClient>(MockBehavior.Strict, envioConnectionString, envioContainerName, envioBlobName);

            var examServices = new ExamServices(mockDbContext.Object, mockBlob.Object);

            // act
            string result = examServices.HealthCheck();
            // assert
            Assert.Equal("Hello, World!", result);
        }
    }
}
