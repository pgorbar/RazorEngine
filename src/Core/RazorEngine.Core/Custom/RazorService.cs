using System;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace RazorEngine
{
    public class RazorService : IRazorService
    {
        private readonly TemplateService _templateService;

        public RazorService(ITemplateServiceConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            _templateService = new TemplateService(configuration);
        }

        public string Parse(string templateName, object model)
        {
            var template = _templateService.Resolve(templateName, model);
            return _templateService.Run(template, new DynamicViewBag());
        }

        public void AddProfile<T>() where T : RazorProfile, new()
        {
            _templateService.Configuration.Resolver.AddProfile<T>();
        }

        public void AddProfile(RazorProfile profile)
        {
            _templateService.Configuration.Resolver.AddProfile(profile);
        }
    }
}