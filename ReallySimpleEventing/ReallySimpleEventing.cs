﻿using ReallySimpleEventing.ActivationStrategies;
using ReallySimpleEventing.EventHandling;

namespace ReallySimpleEventing
{
    public class ReallySimpleEventing
    {
        public static IEventHandlerResolver EventHandlerResolver { get; set; }
        public static IHandlerActivationStrategy ActivationStrategy { get; set; }

        static ReallySimpleEventing()
        {
            EventHandlerResolver = new EventHandlerResolver();
            ActivationStrategy = new ActivatorActivation();
        }

        public static IEventBus CreateEventBus(bool async = false)
        {
            return new EventBus(EventHandlerResolver, ActivationStrategy, async); 
        }
    }
}