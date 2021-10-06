namespace Lib
{
    public sealed class ResultState
    {
        private enum InternalResultState
        {
            Success,
            Fail = 0x01,
            Error = 0x02,
            Invalid = 0x03,
            Exist = 0x04,
            NotExist = 0x05,
            Timeout = 0x06,
            Refuse = 0x07,
            Repeat = 0x08,
            NoRight = 0x09,
            NotFound = 0x0a,
            NotSupport = 0x0b,
            LostConnect = 0x0c,
            Other = 0x0d
        }

        public const int Success = (int)InternalResultState.Success;
        public const int Fail = (int)InternalResultState.Fail;
        public const int Error = (int)InternalResultState.Error;
        public const int Invalid = (int)InternalResultState.Invalid;
        public const int Exist = (int)InternalResultState.Exist;
        public const int NotExist = (int)InternalResultState.NotExist;
        public const int Timeout = (int)InternalResultState.Timeout;
        public const int Refuse = (int)InternalResultState.Refuse;
        public const int Repeat = (int)InternalResultState.Repeat;
        public const int NoRight = (int)InternalResultState.NoRight;
        public const int NotFound = (int)InternalResultState.NotFound;
        public const int NotSupport = (int)InternalResultState.NotSupport;
        public const int LostConnect = (int)InternalResultState.LostConnect;
        public const int Other = (int)InternalResultState.Other;
    }
}