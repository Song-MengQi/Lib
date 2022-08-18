namespace Lib
{
    public abstract class LogBase : ILog
    {
        protected abstract string FileName { get; }
        private readonly ISerializable serializable = new Serializable();
        protected virtual void AppendLineDirectly(string log)
        {
            FileExtends.AppendLine(FileName, log);
        }
        protected void AppendLine(string log)
        {
            serializable.InvokeBackground(()=>AppendLineDirectly(log));
        }
    }
}