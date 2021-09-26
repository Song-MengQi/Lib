namespace Lib
{
    public class Result
    {
        public int State { get; set; }
        public Result() : this(0) { }
        public Result(int state)
        {
            State = state;
        }
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
        public Result() : this(0) { }
        public Result(int state) : base(state)
        {
            Data = default(T);
        }
        public Result(T data) : base()
        {
            Data = data;
        }
    }
}