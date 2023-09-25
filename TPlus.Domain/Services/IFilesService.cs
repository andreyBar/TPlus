using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlus.Domain.FormFile;

namespace TPlus.Domain.Services
{
    public interface IFilesService
    {
        Task<bool> FilesLoadAsync(FormFileBlob File);
    }
}
