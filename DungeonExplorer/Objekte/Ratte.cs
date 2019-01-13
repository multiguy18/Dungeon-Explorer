using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Ratte : Monster
    {
        public Ratte(Spielfigur ziel, short posOben, short posLinks) : base(ziel, posOben, posLinks)
        {
            _symbol = '(';
            _bezeichnung = "Ratte";
            _HP = 5;
            _schaden = 3;
            _belohnung = 2;
        }
    }
}
