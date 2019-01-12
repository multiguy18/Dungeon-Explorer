using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    class Kurzschwert : Waffe
    {
        public Kurzschwert(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _bezeichnung = "Kurzschwert";
            _slots = "ac";
            _praezision = 200;
            _waffenschaden = 8;
        }
    }
}
