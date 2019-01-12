using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    class Kettenharnisch : Ruestung
    {
        public Kettenharnisch(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _bezeichnung = "Kettenharnisch";
            _slots = "d";
            _wert = 6;
            _schadensabwehr = 4;
        }

        
    }
}
