using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Hauptprogramm
    {
        static void Main(string[] args)
        {
            LevelAnbieter lan = new LevelAnbieter();
            lan.LadeLevel(1);
            Zeichner.Zeichne(lan.Level);
            Console.ReadKey();
        }
    }
}
