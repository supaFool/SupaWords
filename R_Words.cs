using System;

namespace supadev.RandomWords
{
    public class R_Words
    {
        private FileLoader fl;

        public R_Words()
        {
            fl = new FileLoader();
            Console.WriteLine(fl.GetName(true));
        }
    }
}