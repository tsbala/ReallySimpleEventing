﻿using System;
using ReallySimpleEventing.EventHandling;

namespace ReallySimpleEventing.ActivationStrategies
{
    public class DelegatedExecution : IHandlerExecutionStrategy
    {
        private readonly Func<Type, object> _createHandler;

        public DelegatedExecution(Func<Type, object> createHandler)
        {
            _createHandler = createHandler;
        }

        public void ExecuteHandler<TEventType>(Type type, Action<IHandle<TEventType>> handle)
        {
            var handler = (IHandle<TEventType>)_createHandler(type);
            handle(handler);
        }
    }
}
