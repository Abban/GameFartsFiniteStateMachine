using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BBX.Library.FSM.Tests.Fixtures
{
    /// <summary>
    /// Might need this later for making sure the state machine creates exception logs 
    /// </summary>
    public class TestLogHandler : ILogHandler
    {
        private Action<Exception> _exceptionCallback;

        
        public void AddLogExceptionCallback(Action<Exception> callback)
        {
            _exceptionCallback += callback;
        }

        
        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            
        }

        
        public void LogException(Exception exception, Object context)
        {
            _exceptionCallback.Invoke(exception);
        }
    }
}