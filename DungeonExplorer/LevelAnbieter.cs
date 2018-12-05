using DungeonExplorer.Objekte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal struct LevelData
    {
        public byte[,] Level { get; private set; }
        public List<Objekt> Objekte { get; private set; }

        public LevelData(byte[,] level, List<Objekt> objekte)
        {
            Level = level;
            Objekte = objekte;
        }
    }

    public class LevelAnbieter
    {
        public byte[,] Level { get; private set; }

        private LevelData[] levels = {
            new LevelData(new byte[,]
           {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 2, 2, 2, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 2, 2, 2, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 2, 2, 2, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},}
            , new List<Objekt>{
                new Spielfigur("Hallo", 6, 5),
            })
        };

    }
}
