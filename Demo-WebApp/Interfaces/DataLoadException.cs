using System;
using System.Runtime.Serialization;

namespace Demo_WebApp.Interfaces {
    [System.Serializable]
    public class DataLoadException : Exception
    {
        public DataLoadException() { }
        public DataLoadException(string message) : base(message) { }
        public DataLoadException(string message, Exception inner) : base(message, inner) { }
        protected DataLoadException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}