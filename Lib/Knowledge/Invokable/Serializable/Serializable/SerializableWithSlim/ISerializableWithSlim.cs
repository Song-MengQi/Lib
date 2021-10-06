namespace Lib
{
    //每个原子操作后面增加一个信号量等待
    public interface ISerializableWithSlim : ISerializable
    {
        void Pause();
        void Continue();
        //Wait For Continue
        void Wait();
    }
}