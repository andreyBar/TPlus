using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TPlusDrive;

namespace TPlus.Controllers.Extension
{
    public static class ControllerBaseExtender
    {
        public static ActionResult ReturnActionResultInputHandlerResponse<TResult>(ControllerBase controller, InputHandlerResponse<TResult> response)
        {

            if (!response.HasError)
            {
                return controller.Ok(response);
            }
            else
            {
                return controller.BadRequest(response);
            }
        }
    }
}
