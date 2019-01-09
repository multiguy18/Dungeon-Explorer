using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Trank : Verbrauchsgegenstand
    {
        private sbyte _heilung;
        private short _angriffsschaden;
        private ushort _ep;

        public Trank(short posOben, short posLinks, sbyte heilung, short angriffsschaden, ushort EP) : base(posOben, posLinks)
        {
            _slots = "ijk";
            _bezeichnung = "Trank";
            _heilung = heilung;
            _angriffsschaden = angriffsschaden;
            _ep = EP;
        }

        public override void Benutze()
        {
            if (_heilung > 0)
            {
                _spieler.Heile((byte)_heilung);
            }
            else if (_heilung < 0)
            {
                short schaden = _heilung;
                _spieler.Schade((ushort)Math.Abs(schaden), true);
            }

            if (_angriffsschaden > 0)
            {
                _spieler.ErhoeheSchaden((ushort)_angriffsschaden);
            }
            else if (_angriffsschaden < 0)
            {
                int dekrementierung = _angriffsschaden;
                _spieler.VerringereSchaden((ushort)Math.Abs(dekrementierung));
            }

            if (_ep > 0)
            {
                _spieler.Belohne(_ep);
            }
        }
    }
}
