namespace Lib
{
    public abstract class LogBase : ILog
    {
        protected abstract string FileName { get; }
        protected readonly ISerializable serializable;
        protected LogBase()
        {
            serializable = new Serializable();
        }
        protected void AppendDirectly(string log)
        {
            FileExtends.AppendLine(FileName, log);
        }
        public virtual void Append(string log)
        {
            serializable.InvokeBackground(() => AppendDirectly(log));
        }
    }
}