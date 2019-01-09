using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Ruestung : Gegenstand
    {
        protected ushort _wert;
        protected ushort _schadensabwehr;

        public ushort Wert {
            get { return _wert; }
        }

        public Ruestung(short posOben, short posLinks) : base(posOben, posLinks)
        {
        }

        public override void Benutze()
        {
        }

        /// <summary>
        /// Berechnet die Höhe der blockierten Schadenspunkte durch eine Rüstung
        /// </summary>
        /// <param name="schaden">Der angerichtete Schaden durch einen gegnerischen Angriff</param>
        /// <returns></returns>
        public ushort Blockiere(ushort schaden)
        {
            ushort blockierterSchaden;

            if (schaden > _schadensabwehr)
            {
                blockierterSchaden = _schadensabwehr;
            }
            else
            {
                blockierterSchaden = schaden;
            }

            if (blockierterSchaden > _wert)
            {
                blockierterSchaden = _wert;
            }

            _wert -= blockierterSchaden;

            return blockierterSchaden;
        }
        
    }
}
