namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        /// <summary>
        /// The result data which comes from service call
        /// </summary>
        T Data { get; }
    }
}
