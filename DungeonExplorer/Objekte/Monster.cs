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

        public Monster(Spielfigur ziel, short posOben, short posLinks) : base(posOben, posLinks)
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
    }
}
