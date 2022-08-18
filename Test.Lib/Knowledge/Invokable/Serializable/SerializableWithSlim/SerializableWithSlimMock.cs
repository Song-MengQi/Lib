using Lib;

namespace Test.Lib
{
    public class SerializableWithSlimMock : SerializableMock, ISerializableWithSlim
    {
        public void Pause() { }
        public void Continue() { }
        public void WaitForRun() { }
    }
}