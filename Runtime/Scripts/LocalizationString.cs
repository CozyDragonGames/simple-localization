using System;

namespace CozyDragon.Localization
{
    [Serializable]
    public struct LocalizationString
    {
        public string key;
        public string value;

        public LocalizationString(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}