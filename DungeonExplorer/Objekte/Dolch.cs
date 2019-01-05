using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Dolch : Waffe
    {
        public Dolch(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _bezeichnung = "Dolch";
            _slots = "ac";
            _praezision = 230;
            _waffenschaden = 5;
        }
    }
}
