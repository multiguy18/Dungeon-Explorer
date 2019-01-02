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
                new Spielfigur("Hallo", 4, 5),
            }),
            new LevelData(new byte[,]
           {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 2, 2, 2, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 2, 2, 2, 3, 3, 3, 3, 3, 0},
            {0, 0, 0, 1, 2, 2, 2, 1, 0, 0, 0, 3, 0},
            {0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 3, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}
            , new List<Objekt>{
                new Spielfigur("Hallo", 7, 10),
                new Tuere(6, 11),
                new Ratte(null, 4, 5)
            })
        };

        public List<Objekt> LadeLevel(byte levelnr)
        {
            LevelData aktuellesLevel = levels[--levelnr];

            Level = aktuellesLevel.Level;

            return aktuellesLevel.Objekte;
        }

        public bool PruefeKollision(short posOben, short posLinks)
        {
            byte abschnitt = Level[posOben, posLinks];
            if (abschnitt == 1 || abschnitt == 0)
            {
                return true;
            }

            return false;
        }
    }
}
