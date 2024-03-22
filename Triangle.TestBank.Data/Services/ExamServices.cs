namespace Triangle.TestBank.Data.Services;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Triangle.TestBank.Data.Migrations;
using Triangle.TestBank.Data.Models;
[Coalesce]
[Service]
public class ExamServices(AppDbContext dbContext)
{

    [Coalesce]
    public string HealthCheck()
    {
        return "Hello, World!";
    }

    [Coalesce]
    public async Task<Exam> PostExam(string name, Subjects subject, Terms term, IFormFile file, [Inject] BlobClient blobStorageClient)
    {
        var uploadedFileUri = await blobStorageClient.UploadAsync(file.OpenReadStream(), true);
        var pdfPath = uploadedFileUri.ToString();
        Exam exam = new Exam { Name = name, PdfPath = pdfPath,Subject=subject,Term = term};
        dbContext.Add(exam);
        await dbContext.SaveChangesAsync();
        return exam;
    }



}
