using System;
using System.Runtime.Serialization;

namespace Demo_WebApp.Services {
    [System.Serializable]
    public class DataLoadExceptionException : Exception
    {
        public DataLoadExceptionException() { }
        public DataLoadExceptionException(string message) : base(message) { }
        public DataLoadExceptionException(string message, Exception inner) : base(message, inner) { }
        protected DataLoadExceptionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}