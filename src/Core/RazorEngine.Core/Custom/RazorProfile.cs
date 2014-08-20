using System.Reflection;

namespace RazorEngine
{
    public abstract class RazorProfile
    {
        public virtual string ProfileName { get { return "RazorProfile"; } }
       
        public virtual string TemplateFolder { get { return "RazorTemplates"; } }

        public virtual Assembly DefiningAssembly
        {
            get { return GetType().Assembly; }
        }
    }
}