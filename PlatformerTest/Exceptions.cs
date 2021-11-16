using System;
using System.Collections.Generic;
using System.Text;

namespace PlatformerTest
{
    [Serializable]
    public class InvalidEffectException : Exception
    {
        public InvalidEffectException() : base() { }
        public InvalidEffectException(string message) : base(message) { }
        public InvalidEffectException(string message, Exception inner) : base(message, inner) { }

        protected InvalidEffectException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class InvalidConditionException : Exception
    {
        public InvalidConditionException() : base() { }
        public InvalidConditionException(string message) : base(message) { }
        public InvalidConditionException(string message, Exception inner) : base(message, inner) { }

        protected InvalidConditionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
