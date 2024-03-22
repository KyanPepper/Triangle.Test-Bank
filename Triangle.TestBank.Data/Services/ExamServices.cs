namespace Triangle.TestBank.Data.Services;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Triangle.TestBank.Data.Migrations;

[Coalesce]
[Service]
public class ExamServices(AppDbContext dbContext, [Inject] BlobClient blobStorageClient)
{

    [Coalesce]
    public string HealthCheck()
    {
        return "Hello, World!";
    }

    
  
}
