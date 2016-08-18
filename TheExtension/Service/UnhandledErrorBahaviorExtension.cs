using System;
using System.ServiceModel.Configuration;

namespace TheExtension.Service
{
    public class UnhandledErrorBahaviorExtension : BehaviorExtensionElement
    {
        /// <summary>Creates a behavior extension based on the current configuration settings.</summary>
        /// <returns>The behavior extension.</returns>
        protected override object CreateBehavior()
        {
            return new UnhandledErrorServiceBehavior();
        }

        public override Type BehaviorType => typeof(UnhandledErrorServiceBehavior);
    }
}
