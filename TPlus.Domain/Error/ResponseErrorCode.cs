namespace TPlus.Domain
{
    public enum ResponseErrorCode
    {
        IntrenalServerError = 500,
        EmailAlreadyExists = 4010,
        SystemError = 4011,
        UserNotFound = 4012,
        WrongPassword = 4013,
        InvalidToken = 4014,
        AccessTokenExpired = 4015,
        InvalidRegistrationToken = 4016,
        RegistrationTokenExpired = 4017,
        MailboxUnavailable = 4018,
        InvalidAuthorizationHeader = 4019,
        DataNotFound = 404, /// это типа ошибка на клиенте
        EmptyRequestResult = 4404, /// это типа не ошибка на клиенте, а просто сигнал, что пустой запрос
        BadRequest = 400,
        DDoSEmail = 4020,
        InvalidData = 4021,
        KeyNotFound = 4022,
        CustomServiceError = 4023, /// может возвращается сервисом, если нужна сложная обработка ошибки по степени серьёзности и т.д.
        DuplicateKey = 4024
    }
}