using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Waffe : Gegenstand
    {
        Random zufallsgen;
        protected byte _praezision;
        protected ushort _waffenschaden;

        public ushort Waffenschaden
        {
            get { return _waffenschaden; }
        }

        public Waffe(short posOben, short posLinks) : base(posOben, posLinks)
        {
            zufallsgen = new Random();
        }

        public override void Benutze()
        {
            _spieler.WaffeAusruesten(this);
        }

        public bool Angriff(Monster ziel)
        {
            if (zufallsgen.Next(0, 254) < _praezision)
            {
                ziel.Schade(_waffenschaden);
                return true;
            }

            return false;
        }
    }
}
