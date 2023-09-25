using Microsoft.AspNetCore.Http;

namespace TPlus.Domain.FormFile
{
    public class FormFileBlob
    {
        public byte[] Blob { get; set; }
        public string MimeType { get; set; }
        public string OriginFile { get; set; }

        private FormFileBlob()
        {
        }


        public static FormFileBlob Create(byte[] blob, string mimeType, string originFile)
        {
            return new FormFileBlob()
            {
                Blob = blob,
                MimeType = mimeType,
                OriginFile = originFile
            };
        }

        public static FormFileBlob Create(IFormFile formFile)
        {
            using (var fstream = formFile.OpenReadStream())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fstream.CopyTo(ms);
                    byte[] image = ms.ToArray();

                    return new FormFileBlob()
                    {
                        Blob = image,
                        MimeType = formFile.ContentType,
                        OriginFile = formFile.FileName
                    };
                }
            }
        }
    }
}
