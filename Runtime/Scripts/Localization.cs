using System;
using System.Collections.Generic;

namespace CozyDragon.Localization
{
    [Serializable]
    public struct Localization
    {
        public List<LocalizationString> strings;

        public Localization(string defaultKey, string defaultValue)
        {
            strings = new List<LocalizationString>()
            {
                new LocalizationString(defaultKey, defaultValue)
            };
        }
    }
}