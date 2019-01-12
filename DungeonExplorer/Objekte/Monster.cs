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
        private int _nichtbewegt = 0;

        public Monster(Spielfigur ziel, short posOben, short posLinks) : base(posOben, posLinks)
        {
            _ziel = ziel;
        }

        //FIXME: Temporär da Levels samt Objekte und Spieler in einem Array initialisiert werden
        public void SetzeZiel(Spielfigur ziel)
        {
            _ziel = ziel;
        }

        /// <summary>
        ///     Bewegungsmuster für Monster
        /// </summary>
        /// <param name="distx">Manuelle Distanz X. Wird verwendet, wenn sich ein Monster vorher nicht bewegt hat, 
        /// um die Bewegungsrichtung manuell zu ändern</param>
        /// <param name="disty">Manuelle Distanz Y. Siehe distx</param>
        public virtual void Bewege(int? distx, int? disty)
        {
            short _tempPosOben = _posOben;
            short _tempPosLinks = _posLinks;

            int differenzOben = _ziel.PosOben - PosOben;
            int differenzLinks = _ziel.PosLinks - PosLinks;

            int distanzY = disty ?? Math.Abs(differenzOben);
            int distanzX = distx ?? Math.Abs(differenzLinks);

            //Wenn das Monster zu weit weg ist, bewegt es sich nicht
            if(distanzX + distanzY >= 10)
            {
                return;
            }

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
            } else
            {
                _nichtbewegt++;

                //Wenn sich ein Monster x-1 Züge nicht bewegt hat, soll die Bewegungsrichtung geändert werden, 
                //auch wenn die Distanz in der anderen Richtung grösser ist
                if(_nichtbewegt >= 2)
                {
                    if(distanzY >= distanzX)
                    {
                        _nichtbewegt = 0;
                        Bewege(1, 0);
                    } else
                    {
                        _nichtbewegt = 0;
                        Bewege(0, 1);
                    }
                    
                }
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
