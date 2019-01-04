using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Gegenstand : Objekt
    {
        Spielfigur spieler;

        public Gegenstand(short posOben, short posLinks) : base(posOben, posLinks)
        {

        }

        public void Benutze()
        {

        }
    }
}
