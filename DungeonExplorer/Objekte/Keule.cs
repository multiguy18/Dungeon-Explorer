using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    class Keule : Waffe
    {
        public Keule(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _bezeichnung = "Keule";
            _slots = "ac";
            _praezision = 180;
            _waffenschaden = 10;
        }
    }
}
