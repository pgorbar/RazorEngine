using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using RazorEngine.Templating;

namespace RazorEngine
{
    public class ResourceStreamTemplateResolver : ITemplateResolver
    {
        private readonly Dictionary<string, AssemblyResource> _registeredTemplates = new Dictionary<string, AssemblyResource>();

        public string Resolve(string name)
        {
            var key = name.ToLowerInvariant();

            if (!_registeredTemplates.ContainsKey(key))
                throw new NullReferenceException(string.Format("Embedded resource with the specified name ({0}) doesn't exist.", key));
            
            var assemblyResource = _registeredTemplates[key];

            using (var stream = assemblyResource.GetManifestResourceStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public void AddProfile<T>() where T : RazorProfile, new()
        {
            AddProfile(new T());
        }

        public void AddProfile(RazorProfile profile)
        {
            var pattern = string.Format(@"[\w\.]+\.{0}\.(?<key>[\w\.]+).cshtml", profile.TemplateFolder);
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            var resourceNames = from resourceName in Assembly.GetAssembly(profile.GetType()).GetManifestResourceNames()
                                let match = regex.Match(resourceName)
                                where match.Success
                                select new {Key = match.Groups["key"].Value.ToLowerInvariant(), ResourceName = resourceName};

            foreach (var pair in resourceNames)
            {
                _registeredTemplates[pair.Key] = new AssemblyResource
                {
                    Key = pair.Key,
                    DefiningAssembly = profile.DefiningAssembly,
                    ResourceName = pair.ResourceName
                };
            }
        }

        private class AssemblyResource
        {
            public string Key { get; set; }
            public Assembly DefiningAssembly { get; set; }
            public string ResourceName { get; set; }

            public Stream GetManifestResourceStream()
            {
                return DefiningAssembly.GetManifestResourceStream(ResourceName);
            }
        }
    }
}