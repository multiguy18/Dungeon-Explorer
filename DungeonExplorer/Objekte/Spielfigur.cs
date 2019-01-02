using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer.Objekte
{
    public class Spielfigur : Figur
    {
        public string Name { get; private set; }
        public Spielfigur(string name, short posOben, short posLinks) : base (posOben, posLinks)
        {
            Name = name;
            _symbol = '@';
            _HP = 30;
            _schaden = 2;
        }

        public ushort HP
        {
            get { return _HP; }
        }

        public void Bewege(short posOben, short posLinks)
        {
            _posOben = posOben;
            _posLinks = posLinks;
        }

        public void Bewege(Richtung richtung)
        {
            short _tempPosOben = _posOben;
            short _tempPosLinks = _posLinks;

            switch (richtung)
            {
                case Richtung.Oben:
                    _tempPosOben--;
                    break;
                case Richtung.Links:
                    _tempPosLinks--;
                    break;
                case Richtung.Unten:
                    _tempPosOben++;
                    break;
                case Richtung.Rechts:
                    _tempPosLinks++;
                    break;
            }

            if (!Hauptprogramm.PruefeKollision(_tempPosOben, _tempPosLinks, this))
            {
                _posOben = _tempPosOben;
                _posLinks = _tempPosLinks;
            }
        }

        public override bool WirdKollidieren(Objekt anderes)
        {
            if (anderes is Tuere)
            {
                Tuere tuere = (Tuere)anderes;
                tuere.OeffneTuere();
                return true;
            }

            return true;
        }
    }
}