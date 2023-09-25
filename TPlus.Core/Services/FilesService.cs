using System.IO;
using TPlus.Domain.FormFile;
using TPlus.Domain.Services;
using TPlus.Files;

namespace TPlus.Core.Services
{
    public class FilesService : IFilesService
    {
        private readonly IWebSiteFile _File;

        public Task<bool> FilesLoadAsync(FormFileBlob file)
        {
            bool result = false;
            try
            {
                result = _File.UploadFile(file.Blob).Result; //// 
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public FilesService(IWebSiteFile file)
        {
            _File = file;
        }
    }
}
