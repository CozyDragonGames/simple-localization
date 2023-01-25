namespace Kaynir.Localization
{
    public static class LocalizationExtensions
    {
        public static string Localize(this string key)
        {
            return LocalizationSystem.GetString(key);
        }

        public static string Localize(this string key, params object[] args)
        {
            return LocalizationSystem.GetString(key, args);
        }
    }
}