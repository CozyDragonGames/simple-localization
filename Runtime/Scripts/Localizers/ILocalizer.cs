namespace Kaynir.Localization.Localizers
{
    public interface ILocalizer
    {
        bool TryGetString(string key, out string value);
        void SetLanguage(string language);
    }
}