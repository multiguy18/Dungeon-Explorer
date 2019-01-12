using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Brustpanzer : Ruestung
    {
        public Brustpanzer(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _bezeichnung = "Brustpanzer";
            _slots = "d";
            _wert = 10;
            _schadensabwehr = 3;
        }
    }
}
