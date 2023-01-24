namespace Kaynir.Localization.Localizers
{
    public interface ILocalizer
    {
        string GetString(string key);
        void LoadLanguage(Language language);
    }
}