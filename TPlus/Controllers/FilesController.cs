using Microsoft.AspNetCore.Mvc;
using TPlus.Controllers.Extension;
using TPlus.PostData;
using TPlusDrive;
using TPlusDrive.InputRequest;

namespace TPlus.Controllers
{
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly InputHandler<FilesInputRequest, bool> _Handler;
        private readonly IPostDataMapper<FilesPostData, FilesDataModel> _Mapper;

        [HttpPost]
        [Route("/api/v1//post_file")]
        public async Task<ActionResult> PostFile(IFormCollection requestBody)
        {
            var postData = _Mapper.Create(new FilesPostData()
            {
                Form = requestBody
            });

            if (postData.Success)
            {
                var result = await _Handler.HandleInput(postData.PostData);

                return ControllerBaseExtender.ReturnActionResultInputHandlerResponse<bool>(this, result);
            }
            else
            {
                return BadRequest(postData);
            }

        }

        public FilesController(InputHandler<FilesInputRequest, bool> handler, IPostDataMapper<FilesPostData, FilesDataModel> mapper)
        {
            _Handler = handler;
            _Mapper = mapper;
        }
    }
}
