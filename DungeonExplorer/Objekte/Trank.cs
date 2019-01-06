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
            throw new NotImplementedException();
        }
    }
}
