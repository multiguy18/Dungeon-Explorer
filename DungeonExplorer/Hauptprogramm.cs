using DungeonExplorer.Objekte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Hauptprogramm
    {
        private static LevelAnbieter _lAnbieter;
        private static List<Objekt> _objekte;

        static void Main(string[] args)
        {
            LevelAnbieter lAnbieter = new LevelAnbieter();
            _objekte = lAnbieter.LadeLevel(1);
            Zeichner.Zeichne(lAnbieter.Level, _objekte);

            do
            {
                
            } while (true);
        }

        public static void WechsleLevel(byte levelnr)
        {

        }
    }
}
