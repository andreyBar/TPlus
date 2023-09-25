using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TPlus.Domain;

namespace TPlusDrive
{
    public class InputHandlerResponse<TResult>
    {
        public virtual bool HasError { get; } = false;
        public TResult? Response { get; private set; }

        public InputHandlerResponse(TResult? result)
        {
            Response = result;
        }
    }

    public class InputHandlerResponse<TContainer, TResult>
    {
    }

    public class InputHandlerResponseOk<TResult> : InputHandlerResponse<TResult>
    {
        public InputHandlerResponseOk(TResult? result) : base(result) { }
    }

    public class InputHandlerResponseError<TResult> : InputHandlerResponse<TResult>
    {
        private string _GetSystemMessage(Exception? ex)
        {
            Exception? ex1 = ex;
            StringBuilder sb = new StringBuilder();

            while (ex1 != null)
            {
                sb.AppendFormat("\n{0}", ex1.Message);

                ex1 = ex1.InnerException;
            }

            return sb.ToString();
        }

        public override bool HasError { get; } = true;

        public ResponseErrorCode? CustomErrorCode { get; set; }

        public string ErrorMessage { get; private set; } = string.Empty;

        public string SystemErrorMessage { get; private set; } = string.Empty;

        public InputHandlerResponseError(TResult? result, Exception exception)
            : base(result)
        {
            SystemErrorMessage = _GetSystemMessage(exception); /// exception.Message;

            if (exception is IResponseError responseError)
            {
                CustomErrorCode = responseError.ResponseErrorCode;
                ErrorMessage = responseError.ResponseErrorMessage;
            }
            else
            {
                CustomErrorCode = ResponseErrorCode.IntrenalServerError;
                ErrorMessage = "Ошибка при выполнениии запроса";
            }
        }
    }

    public class InputHandlerResponseCustomError<TResult> : InputHandlerResponse<TResult>
    {
        public object? Errors { get; private set; }

        public override bool HasError { get; } = true;

        public ResponseErrorCode? CustomErrorCode { get; set; }

        public string ErrorMessage { get; private set; } = string.Empty;

        public string SystemErrorMessage { get; private set; } = string.Empty;

        public InputHandlerResponseCustomError(TResult? result, CustomServiceException exception) : base(result)
        {
            Errors = new
            {
                exception.Messages
            };

            CustomErrorCode = ResponseErrorCode.CustomServiceError;
            ErrorMessage = exception.ResponseErrorMessage;
            SystemErrorMessage = exception.Message;
        }
    }
}
