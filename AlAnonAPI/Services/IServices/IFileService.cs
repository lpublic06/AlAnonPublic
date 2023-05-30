
using Microsoft.AspNetCore.Components.Forms;

namespace AlAnonAPI.Services.IServices
{
    public interface IFileService 
    {
        public Task<string> UploadFile(IBrowserFile file);
        public Task DeleteFile(string imageUrl);
    }
}
