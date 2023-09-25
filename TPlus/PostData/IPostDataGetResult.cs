using TPlus.Domain;

namespace TPlus.PostData
{
    public interface IPostDataGetResult<T>
    {
        bool Success { get; }

        string[] Errors { get; }

        T PostData { get; }

        // этот класс возрващается в ActionResult только если ошибка
        // сюда добавить такой же тип, как при возврате статуса 200
        // ?!?!?! надо как -то возвращать один объект
        //
        bool HasError { get; }

        object? Response { get; }

        ResponseErrorCode CustomErrorCode { get; }

        string ErrorMessage { get; }

        string SystemErrorMessage { get; }
    }
}