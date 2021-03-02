using System;
using System.Collections.Generic;
using System.IO;

namespace supadev.RandomWords
{
    public class FileLoader
    {
        #region List of Words

        //Lists of words
        public List<string> Adjs { get => adjs; }

        public List<string> Advs { get => advs; }
        public List<string> CityNames { get => cityNames; }
        public List<string> CountyName { get => countyName; }
        public List<string> FemaleFirstName { get => femaleFirstName; }
        public List<string> LastName { get => lastName; }
        public List<string> MaleFirstName { get => maleFirstName; }
        public List<string> Nouns { get => nouns; }
        public List<string> OccDesc;
        public List<string> Occupation { get => occupation; }
        public List<string> Population { get => population; }
        public List<string> StateAbbr { get => stateAbbr; }
        public List<string> Streets { get => streets; }
        public List<string> Words { get => words; }
        public List<string> Zip { get => zip; }
        public string[] Map;

        #endregion List of Words

        #region File Getter Helpers

        //pointers, Used to get more info from the map.txt. Didn't never use it, probably is broke
        public static int CITY = 0;

        public static int CITY_ASCII = 1;
        public static int COUNTY_FIPS = 4;
        public static int COUNTY_NAME = 5;
        public static int ID = 15;
        public static int INC = 12;
        public static int LAT = 6;
        public static int LNG = 7;
        public static int POP = 8;
        public static int POP_DENSITY = 10;
        public static int POP_PROP = 9;
        public static int SOURCE = 11;
        public static int STATE_ID = 2;
        public static int STATE_NAME = 3;
        public static int TIMEZONE = 13;
        public static int ZIP = 14;

        #endregion File Getter Helpers

        #region Private Vars

        private List<string> adjs;
        private List<string> advs;
        private List<string> cityNames;
        private List<string> countyName;
        private List<string> femaleFirstName;
        private List<string> lastName;
        private List<string> maleFirstName;
        private List<string> nouns;
        private List<string> occupation;
        private List<string> population;
        private List<string> stateAbbr;
        private List<string> streets;
        private List<string> words;
        private List<string> zip;

        #endregion Private Vars

        public FileLoader()
        {
            InitLists();
            Init();
        }

        /// <summary>
        /// Inits all the lists that the corresponding .txt file in Data_xml/ will be stored in
        /// </summary>
        private void InitLists()
        {
            adjs = new List<string>();
            advs = new List<string>();
            cityNames = new List<string>();
            countyName = new List<string>();
            femaleFirstName = new List<string>();
            lastName = new List<string>();
            maleFirstName = new List<string>();
            nouns = new List<string>();
            occupation = new List<string>();
            population = new List<string>();
            stateAbbr = new List<string>();
            streets = new List<string>();
            words = new List<string>();
            zip = new List<string>();
        }

        #region Static Methods

        /// <summary>
        /// Reads a file at the given path
        /// </summary>
        /// <param name="path">location of file</param>
        /// <returns>the whole file as a string[]</returns>
        public string[] ReadFile(string path)
        {
            string[] s = File.ReadAllLines(path);

            return s;
        }

        public void Init()
        {
            #region Load Files & Format Results

            var _maleNames = ReadFile("Data_xml/male-first.txt");
            foreach (var line in _maleNames)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                MaleFirstName.Add(line);
            }

            var f = ReadFile("Data_xml/female-first.txt");

            foreach (var line in f)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                FemaleFirstName.Add(line);
            }

            var l = ReadFile("Data_xml/last.txt");

            foreach (var line in l)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                LastName.Add(line);
            }

            var aj = ReadFile("Data_xml/adj.txt");

            foreach (var line in aj)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                Adjs.Add(line);
            }

            var w = ReadFile("Data_xml/words.txt");

            foreach (var line in w)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                Words.Add(line);
            }

            var av = ReadFile("Data_xml/adv.txt");

            foreach (var line in av)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                Advs.Add(line);
            }

            var n = ReadFile("Data_xml/nouns.txt");

            foreach (var line in n)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                Nouns.Add(line);
            }

            var s = ReadFile("Data_xml/street.txt");

            //Street suffixes
            foreach (var line in s)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                Streets.Add(line);
            }

            //Load Occupation
            var o = ReadFile("Data_xml/occupation.txt");
            foreach (var line in o)
            {
                line.Replace(" ", string.Empty);
                line.Trim();
                Occupation.Add(line);
            }

            //Load Map
            //var map = (TextAsset)Resources.Load("Text/uscities", typeof(TextAsset));
            //Map = map.text.Split('\n');

            #endregion Load Files & Format Results

            //****DONT DELETE*****
            //temp[i].Replace("\"([^\"]*?)\"", string.Empty);
            //****Used to remove all non ABC chars from a file
        }

        /// <summary>
        /// /Gets a real US Street Address with a sudo box number
        /// </summary>
        public string GetStreetAddress()
        {
            Random r = new Random();
            string _streetAddy = r.Next(0, 9999) + " ";

            if (r.Next(0, 100) < 25)
            {
                _streetAddy = _streetAddy + Capitilize(Adjs[r.Next(0, Adjs.Count)]) + " ";
            }

            _streetAddy = _streetAddy + Capitilize(Nouns[r.Next(0, Nouns.Count)]) + " ";

            return _streetAddy + Streets[r.Next(0, Streets.Count)];
        }

        /// <summary>
        /// /Gets a real US City
        /// </summary>
        public string[] GetCityAddress(int pick)
        {
            int counter = 0;
            foreach (var line in Map)
            {
                counter++;
                if (counter == pick)
                {
                    var s = line.Split(',');
                    return s;
                }
            }
            return null;
        }

        /// <summary>
        /// /Gets a random occupation
        /// </summary>
        public string GetOccupation(int index)
        {
            return Occupation[index];
        }

        /// <summary>
        /// Gets a random First and Last name
        /// </summary>
        /// <param name="is_male">Should desired name be male</param>
        /// <returns></returns>
        public string GetName(bool is_male)
        {
            try
            {
                if (is_male)
                {
                    return MaleFirstName[new Random().Next(MaleFirstName.Count)].Trim() + " " + LastName[new Random().Next(LastName.Count)].Trim();
                }
                else
                {
                    return FemaleFirstName[new Random().Next(FemaleFirstName.Count)].Trim() + " " + LastName[new Random().Next(LastName.Count)].Trim();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets a random 'World Name'. I used this in a game before making it a lib...lol
        /// </summary>
        /// <returns></returns>
        public string GetWorldName()
        {
            var _worldname = "Land of the ";
            if (new Random().Next(0, 100) < 50)
            {
                _worldname += Capitilize(Adjs[new Random().Next(0, Adjs.Count)] + " ");
            }

            _worldname += Capitilize(Nouns[new Random().Next(Nouns.Count)]) + " ";
            return _worldname;
        }

        /// <summary>
        /// Caps the first letter of the given string
        /// </summary>
        /// <param name="s">Word to cap</param>
        public string Capitilize(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        #endregion Static Methods
    }
}