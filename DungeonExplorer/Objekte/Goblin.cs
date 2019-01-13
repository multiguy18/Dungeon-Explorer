using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    class Goblin : Monster
    {
        public Goblin(Spielfigur ziel, short posOben, short posLinks) : base(ziel, posOben, posLinks)
        {
            _symbol = '%';
            _bezeichnung = "Goblin";
            _HP = 7;
            _schaden = 4;
            _belohnung = 3;
        }
    }
}
