using System;

namespace supadev.RandomWords
{
    public static class WordLogic
    {
        public static string Adjectify(string word)
        {
            string[] end = new string[]
            {
                "ian",
                "ic",
                "-like",
                "ary",
                "ique"
            };
            return word + end[new Random().Next(0, end.Length)];
        }
    }
}