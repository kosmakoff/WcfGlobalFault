using System;
using System.Runtime.Serialization;

namespace TheContracts
{
    [DataContract]
    public class UnhandledError
    {
        [DataMember]
        public string ExceptionType { get; set; }

        [DataMember]
        public string Message { get; set; }

        public UnhandledError(Exception error)
        {
            ExceptionType = error.GetType().FullName;
            Message = error.Message;
        }
    }
}
