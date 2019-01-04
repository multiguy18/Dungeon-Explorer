using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Gegenstand : Objekt
    {
        protected Spielfigur _spieler;

        public Gegenstand(short posOben, short posLinks) : base(posOben, posLinks)
        {

        }

        public void SetzeSpieler(Spielfigur spieler)
        {
            _spieler = spieler;
        }

        public abstract void Benutze();
    }
}
