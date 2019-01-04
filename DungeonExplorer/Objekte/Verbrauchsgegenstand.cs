using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Verbrauchsgegenstand : Gegenstand
    {
        public Verbrauchsgegenstand(short posOben, short posLinks) : base(posOben, posLinks)
        {
        }
    }
}
