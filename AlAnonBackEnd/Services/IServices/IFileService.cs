
using Microsoft.AspNetCore.Components.Forms;

namespace AlAnon.Services.IServices
{
    public interface IFileService 
    {
        public Task<string> UploadFile(IBrowserFile file, string fileName = "default");
        public Task DeleteFile(string imageUrl);
    }
}
