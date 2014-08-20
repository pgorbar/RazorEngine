using System.Collections.Generic;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace RazorEngine
{
    /// <summary>
    /// Default configuration.
    /// </summary>
    public class RazorConfiguration : TemplateServiceConfiguration
    {
        public RazorConfiguration(ITemplateResolver templateResolver)
        {
            BaseTemplateType = typeof(RazorTemplate<>);
            EncodedStringFactory = new RawStringFactory();
            Namespaces = new HashSet<string>
            {
                "System",
                "RazorEngine"

            };
            Resolver = templateResolver;
        }
    }
}