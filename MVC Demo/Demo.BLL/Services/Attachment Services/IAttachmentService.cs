using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.Attachment_Services
{
    public interface IAttachmentService
    {
        public string? Upload(IFormFile file, string FolderName);
        public bool Delete(string filePath);

    }
}
