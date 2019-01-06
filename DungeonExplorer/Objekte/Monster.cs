using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Monster : Figur
    {
        private Spielfigur _ziel;
        protected ushort _belohnung;

        public Monster(Spielfigur ziel, short posOben, short posLinks) : base(posOben, posLinks)
        {
            _ziel = ziel;
        }

        //FIXME: Temporär da Levels samt Objekte und Spieler in einem Array initialisiert werden
        public void SetzeZiel(Spielfigur ziel)
        {
            _ziel = ziel;
        }

        public virtual void Bewege()
        {
            short _tempPosOben = _posOben;
            short _tempPosLinks = _posLinks;

            int differenzOben = Math.Abs(_ziel.PosOben - PosOben);
            int differenzLinks = Math.Abs(_ziel.PosLinks - PosLinks);

            int distanzY = Math.Abs(differenzOben);
            int distanzX = Math.Abs(differenzLinks);

            if (distanzY >= distanzX)
            {
                if (differenzOben > 0)
                {
                    _tempPosOben++;
                }
                else if (differenzOben < 0)
                {
                    _tempPosOben--;
                }
            }
            else
            {
                if (differenzLinks > 0)
                {
                    _tempPosLinks++;
                }
                else if (differenzLinks < 0)
                {
                    _tempPosLinks--;
                }
            }

            if (!Hauptprogramm.PruefeKollision(_tempPosOben, _tempPosLinks, this))
            {
                _posOben = _tempPosOben;
                _posLinks = _tempPosLinks;
            }
        }

        public override bool WirdKollidieren(Objekt anderes)
        {
            if (anderes is Spielfigur)
            {
                Spielfigur spielfigur = (Spielfigur)anderes;
                spielfigur.Schade(_schaden);

                Hauptprogramm.Nachricht(_bezeichnung + " hat dich getroffen", true);

                return true;
            }

            return true;
        }

        protected override void IstTot()
        {
            _ziel.Belohne(_belohnung);
            Hauptprogramm.Entferne(this);
        }
    }
}
