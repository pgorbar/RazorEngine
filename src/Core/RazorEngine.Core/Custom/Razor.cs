namespace RazorEngine
{
    public static class Razor
    {
        private static readonly IRazorService RazorService = new RazorService(new RazorConfiguration(new ResourceStreamTemplateResolver()));

        public static string Parse(string templateName, object model = null)
        {
            return RazorService.Parse(templateName, model);
        }

        public static void AddProfile<T>() where T : RazorProfile, new()
        {
            RazorService.AddProfile<T>();
        }

        public static void AddProfile(RazorProfile profile)
        {
            RazorService.AddProfile(profile);
        }
    }
}
