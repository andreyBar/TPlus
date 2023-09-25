using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlus.Domain.FormFile;

namespace TPlusDrive.InputRequest
{
    public class FilesInputRequest : InputRequest<bool>
    {
        public FormFileBlob File { get; set; }
    }
}
