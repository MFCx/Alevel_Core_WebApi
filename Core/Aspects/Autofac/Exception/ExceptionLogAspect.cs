﻿using Castle.DynamicProxy;
using Core.CrosCuttingConcerns.Logging;
using Core.CrosCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect
        : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public ExceptionLogAspect(Type loggerServiceBase)
        {
            if (loggerServiceBase.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception("Hata Alıdınız");
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBase);
        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments.GetType().Name
                });
            }
            var logDetailWithException = new LogDetailWithException()
            {
                LogParameters = logParameters,
                RunTime = DateTime.Now,
                MethodName = invocation.Method.Name,
            };
            return logDetailWithException;
        }
    }
}
