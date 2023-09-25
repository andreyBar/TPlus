
namespace TPlus.Domain
{
    public class CustomServiceException : System.Exception, IResponseError
    {
        public string[] Messages { get; private set; }

        public string ResponseErrorMessage 
        { 
            get; 
            private set; 
        } // "Данные отсутствуют.";

        public ResponseErrorCode ResponseErrorCode => ResponseErrorCode.CustomServiceError;

        public CustomServiceException(System.Exception ex) : base(ex.Message, ex)
        {
            ResponseErrorMessage = ex.Message;
        }

        public CustomServiceException(string message, params string[] messages)
        {
            ResponseErrorMessage = message;
            Messages = new string[] { message }.Union(messages).ToArray();
        }
    }

}
