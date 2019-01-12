using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    class Falltuere : Objekt
    {
        public Falltuere(short posOben, short posLinks) : base(posOben, posLinks)
        {
            _symbol = 'v';
        }


    }
}
