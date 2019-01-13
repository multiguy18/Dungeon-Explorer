using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    class Skelett : Monster
    {
        public Skelett(Spielfigur ziel, short posOben, short posLinks) : base(ziel, posOben, posLinks)
        {
            _symbol = '£';
            _bezeichnung = "Animiertes Skelett";
            _HP = 10;
            _schaden = 5;
            _belohnung = 5;
        }
    }
}
