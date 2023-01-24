namespace Kaynir.Localization
{
    public static class LocalizationExtensions
    {
        public static string Localize(this string key)
        {
            return LocalizationSystem.GetString(key);
        }
    }
}