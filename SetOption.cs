using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueClientLocaleSwitcher
{
    public class SetOption
    {

        public void SaveOptions(string filepath)
        {

        }

        public void CheckOption()
        {
            var json = File.ReadAllText(@"options.json");

        }

    }
}
