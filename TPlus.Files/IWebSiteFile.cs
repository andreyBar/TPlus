namespace TPlus.Files
{
    public interface IWebSiteFile
    {
        Task<byte[]?> GetFileAsync(string path);

        Task<byte[]?> GetExternalFileAsync(string path);

        Task<bool> UploadFile(string path, byte[] file);

        string GetMimeType(string path);


        public Task<bool> DeleteFileAsync(string path);

    }
}