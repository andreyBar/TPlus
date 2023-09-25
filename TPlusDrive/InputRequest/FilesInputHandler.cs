using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlus.Domain.Services;

namespace TPlusDrive.InputRequest
{
    public class FilesInputHandler : InputHandler<FilesInputRequest, bool>
    {
        private IFilesService _Service;

        protected override bool GetNullResult() => false;

        protected async override Task<bool> HandleRequest(FilesInputRequest request)
        {
            return await _Service.FilesLoadAsync(request.File);
        }

        public FilesInputHandler(IFilesService service) : base()
        {
            _Service = service;
        }
    }

}
