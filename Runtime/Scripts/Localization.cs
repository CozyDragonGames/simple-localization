using System;
using System.Collections.Generic;

namespace Kaynir.SimpleLocalization
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