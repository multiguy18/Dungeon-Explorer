using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Tuere : Objekt
    {
        public Tuere(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _symbol = '+';
        }

        public void OeffneTuere()
        {
            Hauptprogramm.Nachricht("Die Türe öffnet sich...");

            Hauptprogramm.Entferne(this);
        }
    }
}
