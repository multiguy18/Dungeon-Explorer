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

        private short _spielfigurPosOben;
        private short _spielfigurPosLinks;

        public byte[,] Level { get { return _level; } }

        public List<Objekt> Objekte { get { return _objekte; } }

        public short SpielfigurPosOben
        {
            get { return _spielfigurPosOben; }
        }

        public short SpielfigurPosLinks
        {
            get { return _spielfigurPosLinks; }
        }

        public LevelData(byte[,] level, List<Objekt> objekte, short spielfigurPosOben, short spielfigurPosLinks)
        {
            _level = level;
            _objekte = objekte;

            _spielfigurPosOben = spielfigurPosOben;
            _spielfigurPosLinks = spielfigurPosLinks;
        }
    }

    public class LevelAnbieter
    {
        private Spielfigur _spielfigur;

        public LevelAnbieter(Spielfigur spielfigur)
        {
            _spielfigur = spielfigur;
        }

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
            },
                4, 5
            ),
            new LevelData(new byte[,]
           {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 2, 2, 1, 1, 1, 0, 0, 3, 3, 3, 3, 3, 0},
            {0, 0, 1, 2, 2, 2, 2, 1, 0, 0, 3, 0, 0, 0, 3, 0},
            {0, 0, 0, 1, 2, 2, 2, 3, 3, 3, 3, 0, 1, 1, 2, 1},
            {0, 0, 0, 1, 2, 2, 2, 1, 0, 0, 3, 0, 1, 2, 2, 1},
            {0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 2, 1, 1, 2, 2, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1},}
            , new List<Objekt>{
                new Tuere(6, 10),
                new Tuere(4, 14),
                new Ratte(null, 4, 5),
                new LembasBrot(8, 12),
                new LembasBrot(3, 4),
                new Trank(4, 4, -5, 0, 50),
                new Dolch(7, 14),
                new Brustpanzer(8, 10),
                new Falltuere(2, 3)
            },
                7, 10
            ),
            new LevelData(new byte[,]
           {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 2, 2, 2, 3, 3, 0, 1, 1, 1, 1, 1, 1, 0},
            {0, 0, 1, 2, 2, 1, 0, 3, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 1, 2, 2, 1, 0, 3, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 1, 2, 2, 1, 0, 3, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 1, 1, 1, 1, 0, 3, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 3, 3, 2, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 1, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 1, 1, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0}}
            , new List<Objekt>{
                new Tuere(2, 5),
                new Ratte(null, 4, 7),
                new Goblin(null, 5, 11),
                new Skelett(null, 7, 8),
                new Skelett(null, 15, 11),
                new Trank(5, 10, 3, 0, 0),
                new Falltuere(14, 9),
                new Kettenharnisch(15, 10)
            },
                2, 3
            ),
            new LevelData(new byte[,]
           {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
            {0, 0, 1, 2, 2, 2, 3, 3, 2, 2, 2, 2, 2, 2, 1, 0},
            {0, 0, 1, 2, 2, 1, 0, 0, 1, 2, 2, 2, 2, 2, 1, 0},
            {0, 0, 1, 2, 2, 1, 0, 0, 1, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 1, 0},
            {1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 2, 1, 2, 1, 1, 0},
            {1, 2, 2, 2, 2, 1, 0, 0, 0, 0, 3, 1, 2, 1, 1, 0},
            {1, 2, 2, 2, 2, 1, 0, 0, 0, 0, 3, 0, 3, 0, 0, 0},
            {1, 2, 2, 2, 1, 1, 0, 0, 0, 0, 3, 0, 3, 0, 0, 0},
            {1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0},
            {1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}
            , new List<Objekt>{
                new Tuere(3, 5),
                new Tuere(3, 8),
                new Tuere(11, 10),
                new Tuere(12, 12),
                new Ratte(null, 4, 3),
                new Ratte(null, 4, 12),
                new Goblin(null, 5, 11),
                new Goblin(null, 13, 2),
                new Skelett(null, 7, 10),
                new Skelett(null, 15, 11),
                new Trank(9, 11, 10, -2, 0),
                new Kurzschwert(3, 13),
                new Falltuere(13, 2)
            },
                3, 3
            ),
            new LevelData(new byte[,]
           {{0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 1, 1, 0},
            {0, 1, 2, 2, 2, 1, 0},
            {0, 1, 2, 2, 2, 1, 0},
            {0, 1, 2, 2, 2, 1, 0},
            {0, 1, 1, 1, 1, 1, 0}}
            , new List<Objekt>{},
                3, 3
            )
        };

        public List<Objekt> LadeLevel(byte levelnr)
        {
            LevelData aktuellesLevel = levels[--levelnr];
            Level = aktuellesLevel.Level;

            _spielfigur.Bewege(aktuellesLevel.SpielfigurPosOben, aktuellesLevel.SpielfigurPosLinks);

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
