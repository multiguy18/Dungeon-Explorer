using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Objekt
    {
        protected short _posOben;
        protected short _posLinks;

        protected short _bezeichnung;

        public short PosOben
        {
            get { return _posOben; }
        }

        public short PosLinks
        {
            get { return _posLinks; }
        }

        public Objekt(short posOben, short posLinks)
        {
            _posOben = posOben;
            _posLinks = _posLinks;
        }

        public virtual bool WirdKollidieren(Objekt anderes)
        {
            return true;
        }
    }
}
