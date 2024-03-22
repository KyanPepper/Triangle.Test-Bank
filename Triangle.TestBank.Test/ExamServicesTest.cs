using System;
using Xunit;
using Moq;
using Triangle.TestBank.Data.Services;
using Triangle.TestBank.Data;
using Azure.Storage.Blobs;
using Triangle.TestBank.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Triangle.TestBank.Test
{
    public class ExamServicesTest
    {


        [Fact]
        public void HealthTest()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>();

            //act
            var examServices = new ExamServices(mockDbContext.Object);
            string result = examServices.HealthCheck();
            // assert
            Assert.Equal("Hello, World!", result);
        }
        [Fact]
        public async Task PostExam_UploadsFileAndReturnsExam()
        {
            // Arrange
            var dbContextMock = new Mock<AppDbContext>();

          
            var envioConnectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            var envioContainerName = Environment.GetEnvironmentVariable("AZURE_CONTAINER");
            var envioBlobName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT");
            var blobClient = new BlobClient(connectionString: envioConnectionString, blobContainerName: envioContainerName, blobName: envioBlobName);

            
            var formFile = new FormFile(new MemoryStream(), 0, 0, "file", "testfile.pdf");

            var examServices = new ExamServices(dbContextMock.Object);

            // Act
            Exam result = await examServices.PostExam(name: "Test 3", subject: Subjects.MATH, term: Terms.Spring2022, file: formFile, blobStorageClient: blobClient);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test 3", result.Name);
            Assert.Equal(Subjects.MATH, result.Subject);
            Assert.Equal(Terms.Spring2022, result.Term);
            Assert.NotNull(result.PdfPath);


            dbContextMock.Verify(x => x.Add(It.IsAny<Exam>()), Times.Once);

        }
    }
}