using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class LembasBrot : Verbrauchsgegenstand
    {
        public LembasBrot(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _slots = "l";
            _bezeichnung = "Lembas Brot";
        }

        public override void Benutze()
        {
            _spieler.Heile(5);
        }
    }
}
