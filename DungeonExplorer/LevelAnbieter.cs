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
        private byte[,] _level;
        private List<Objekt> _objekte;

        public byte[,] Level { get { return _level; } }

        public List<Objekt> Objekte { get { return _objekte; } }

        public LevelData(byte[,] level, List<Objekt> objekte)
        {
            _level = level;
            _objekte = objekte;
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

        public List<Objekt> LadeLevel(byte levelnr)
        {
            LevelData aktuellesLevel = levels[--levelnr];

            Level = aktuellesLevel.Level;
            return aktuellesLevel.Objekte;
        }

        //TODO: Kollisionsüberprüfverfahren überdenken
        public bool PruefeKollision(short posOben, short PosLinks)
        {
            throw new NotImplementedException();
        }
    }
}
