using System;
namespace Playnite.SmartLibraryManager.Utilities
{
    public static class TitleNormalizer
    {
        public static string Normalize(string title)
        {
            title = RemoveTrailingParentheses(title);
            foreach (string suffix in TitleSuffixes.Suffixes)
            {
                title = RemoveSuffixes(title, suffix);
            }
            return title.TrimEnd(' ', '-', ':');
        }

        private static string RemoveTrailingParentheses(string text)
        {
            if (text.EndsWith(")"))
            {
                int index = text.LastIndexOf('(');
                if (index >= 0)
                {
                    text = text.Substring(0,
                        index).TrimEnd();
                }
            }
            return text;
        }

        private static string RemoveSuffixes(string text, string suffix)
        {
            if (text.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
            {
                int startIndex = text.Length - suffix.Length;
                text = text.Remove(startIndex).TrimEnd();
            }
            return text;
        }
    }
}