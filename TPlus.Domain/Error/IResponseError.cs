namespace TPlus.Domain
{
    public interface IResponseError
    {
        string ResponseErrorMessage { get; }

        ResponseErrorCode ResponseErrorCode { get; }
    }
}