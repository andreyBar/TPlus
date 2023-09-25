using TPlus.Domain;


namespace TPlusDrive
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface InputRequest<TResult>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class InputHandler<TRequest, TResult> where TRequest : InputRequest<TResult> /// where TResult : new()
    {
        protected abstract TResult? GetNullResult();


        /// <summary>
        /// Этот метод реализовать в наследниках. Здесь вызываются сервисы и диспетчеры.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected abstract Task<TResult> HandleRequest(TRequest request);


        public async Task<InputHandlerResponse<TResult>> HandleInput(TRequest request)
        {
            try
            {
                TResult result = await this.HandleRequest(request);

                InputHandlerResponseOk<TResult> ret = new InputHandlerResponseOk<TResult>(result);

                return ret;
            }
            catch (CustomServiceException ex)
            {
                return new InputHandlerResponseCustomError<TResult>(GetNullResult(), ex);
            }
            catch (Exception ex)
            {
                return new InputHandlerResponseError<TResult>(GetNullResult(), ex);
            }
        }

        public InputHandler()
        {

        }
    }
}
