namespace RazorEngine
{
    public interface IRazorService
    {
        string Parse(string templateName, object model);

        void AddProfile<T>() where T : RazorProfile, new();
        void AddProfile(RazorProfile profile);
    }
}