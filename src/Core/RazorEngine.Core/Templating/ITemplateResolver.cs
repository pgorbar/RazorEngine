namespace RazorEngine.Templating
{
    /// <summary>
    /// Defines the required contract for implementing a template resolver.
    /// </summary>
    public interface ITemplateResolver
    {
        /// <summary>
        /// Resolves the template content with the specified name.
        /// </summary>
        /// <param name="name">The name of the template to resolve.</param>
        /// <returns>The template content.</returns>
        string Resolve(string name);

        void AddProfile<T>() where T : RazorProfile, new();

        void AddProfile(RazorProfile profile);
    }
}