using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Rüstung : Gegenstand
    {
        protected ushort _wert;
        protected ushort _blockierterSchaden;

        public ushort Wert {
            get { return _wert; }
        }

        public Rüstung(short posOben, short posLinks) : base(posOben, posLinks)
        {
        }

        public override void Benutze()
        {
        }

        //TODO: Logik schadensblockierung
        /*
        public ushort Blockiere(ushort schaden)
        {
            if (schaden > _wert)
            {
                return _wert;
            }
            else if (schaden > _blockierterSchaden)
            {
                return _blockierterSchaden;
            }
        }
        */
    }
}
