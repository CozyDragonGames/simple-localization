using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Kaynir.Localization.Tools
{
    public static class CSVReader
    {
        private static string SPLIT_REGEX = @";";
        private static string LINE_SPLIT_REGEX = @"\r\n|\n\r|\n|\r";
        private static char[] TRIM_CHARS = { '\"' };

        public static List<Dictionary<string, string>> FromCSV(TextAsset file)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            string[] lines = Regex.Split(file.text, LINE_SPLIT_REGEX);
            
            if (lines.Length <= 1) return list;

            string[] header = Regex.Split(lines[0], SPLIT_REGEX);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = Regex.Split(lines[i], SPLIT_REGEX);

                if (values.Length == 0 || values[0] == string.Empty) continue;

                list.Add(CreateEntry(header, values));
            }

            return list;
        }

        private static Dictionary<string, string> CreateEntry(string[] header, string[] values)
        {
            Dictionary<string, string> entry = new Dictionary<string, string>();
            
            for (int i = 0; i < header.Length && i < values.Length; i++)
            {
                entry[header[i]] = values[i].TrimStart(TRIM_CHARS)
                                            .TrimEnd(TRIM_CHARS)
                                            .Replace("\\", string.Empty);
            }

            return entry;
        }
    }
}