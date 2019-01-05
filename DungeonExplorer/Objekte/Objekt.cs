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

        protected char _symbol;
        protected string _bezeichnung;

        public short PosOben
        {
            get { return _posOben; }
        }

        public short PosLinks
        {
            get { return _posLinks; }
        }

        public char Symbol
        {
            get { return _symbol; }
        }

        public string Bezeichnung
        {
            get { return _bezeichnung; }
        }

        public Objekt(short posOben, short posLinks)
        {
            _posOben = posOben;
            _posLinks = posLinks;
        }

        /// <summary>
        /// Diese Funktion wird aufgerufen, wenn dieses Objekt mit einem anderen kollidiert.
        /// </summary>
        /// <param name="anderes">Das andere Objekt, mit dem dieses kollidiert</param>
        /// <returns></returns>
        public virtual bool WirdKollidieren(Objekt anderes)
        {
            return true;
        }
    }
}
