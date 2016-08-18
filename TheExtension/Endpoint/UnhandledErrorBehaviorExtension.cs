using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace TheExtension.Endpoint
{
    public class UnhandledErrorBehaviorExtension : BehaviorExtensionElement
    {
        /// <summary>Creates a behavior extension based on the current configuration settings.</summary>
        /// <returns>The behavior extension.</returns>
        protected override object CreateBehavior()
        {
            return new UnhandledErrorEndpointBehavior();
        }

        /// <summary>Gets the type of behavior.</summary>
        /// <returns>The type of behavior.</returns>
        public override Type BehaviorType => typeof(UnhandledErrorEndpointBehavior);
    }
}
