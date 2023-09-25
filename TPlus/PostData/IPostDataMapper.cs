namespace TPlus.PostData
{
    public interface IPostDataMapper<in TInput, TOutput> where TInput : class where TOutput : class, new()
    {
        IPostDataGetResult<TOutput> Create(TInput formdata);
    }
}
