using RazorEngine.Templating;

namespace RazorEngine
{
    public abstract class RazorTemplate<T> : TemplateBase<T>
    {
        //just some example of helper method
        public string ToUpperCase(string name)
        {
            return name.ToUpperInvariant();
        }
    }
}