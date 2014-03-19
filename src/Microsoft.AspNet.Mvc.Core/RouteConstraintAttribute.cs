using System;

namespace Microsoft.AspNet.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class RouteConstraintAttribute : Attribute
    {
        protected RouteConstraintAttribute([NotNull]string routeKey, [NotNull]string routeValue, bool blockNonAttributedActions)
        {
            RouteKey = routeKey;
            RouteValue = routeValue;
            BlockNonAttributedActions = blockNonAttributedActions;
        }

        public string RouteKey { get; private set; }
        public string RouteValue { get; private set; }
        public bool BlockNonAttributedActions { get; private set; }
    }
}
