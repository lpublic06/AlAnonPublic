using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AlAnon.Services.IServices;
using Microsoft.AspNetCore.Components.Forms;

namespace AlAnon.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;
        private IBrowserFile selectedImage;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task DeleteFile(string imageUrl)
        {
            Uri blobUri = new Uri(imageUrl);
            StorageSharedKeyCredential storageCredentials =
            new StorageSharedKeyCredential(_configuration.GetSection("AzureStorageConfig").GetValue<string>("AccountName"), _configuration.GetSection("AzureStorageConfig").GetValue<string>("AccountKey"));
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials, new BlobClientOptions());

            await blobClient.DeleteIfExistsAsync();
		}

        public async Task<string> UploadFile(IBrowserFile file, string fileName = "default")
        {
            // Name to store
            FileInfo fileInfo = new(file.Name);
            if (fileName == "default")
            {
                fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            }

            var stream = new MemoryStream();

            Uri blobUri = new Uri("https://" +
                      _configuration.GetSection("AzureStorageConfig").GetValue<string>("AccountName") +
                      ".blob.core.windows.net/" +
                      "mango/" + fileName);

            // For key 
            StorageSharedKeyCredential storageCredentials =
            new StorageSharedKeyCredential(_configuration.GetSection("AzureStorageConfig").GetValue<string>("AccountName"), _configuration.GetSection("AzureStorageConfig").GetValue<string>("AccountKey"));
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            // For SAS
            //AzureSasCredential credential = new AzureSasCredential(_configuration.GetSection("AzureStorageConfig").GetValue<string>("AccountKey"));
            //BlobClient blobClient = new BlobClient(blobUri, credential, new BlobClientOptions());

            // Optional
            //displayProgress = true;

            stream.Position = 0;

            // Upload the file
            // Without Options
            //await blobClient.UploadAsync(stream, true);

            // With Options
            await blobClient.UploadAsync(file.OpenReadStream(),
            new BlobUploadOptions
            {
                // 5.1. define HTTP Header Content Type 
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType =
                         file.ContentType
                },
                // 5.2. THe Transfer behavior with the transfer size
                TransferOptions = new StorageTransferOptions
                {
                    InitialTransferSize = 1500 * 140
                }
            });

            return blobUri.AbsoluteUri;

        }
    }
}
