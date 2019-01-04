using DungeonExplorer.Objekte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Hauptprogramm
    {
        private static LevelAnbieter _lAnbieter;
        private static List<Objekt> _objekte;
        private static List<Objekt> _zuLoeschendeObjekte;
        private static Spielfigur _spielfigur;
        private static byte _levelNr = 2;

        public static bool NaechstesLevel = false;

        static void Main(string[] args)
        {
            _lAnbieter = new LevelAnbieter();
            _zuLoeschendeObjekte = new List<Objekt>();
            WechsleLevel(_levelNr);

            Zeichner.Zeichne(_lAnbieter.Level, _objekte, _spielfigur);

            do
            {
                Aktion aktion;
                aktion = VerarbeiteEingabe();

                switch (aktion)
                {
                    case Aktion.BewegeNachOben:
                        _spielfigur.Bewege(Richtung.Oben);
                        break;
                    case Aktion.BewegeNachLinks:
                        _spielfigur.Bewege(Richtung.Links);
                        break;
                    case Aktion.BewegeNachUnten:
                        _spielfigur.Bewege(Richtung.Unten);
                        break;
                    case Aktion.BewegeNachRechts:
                        _spielfigur.Bewege(Richtung.Rechts);
                        break;
                }

                foreach (Objekt objekt in _zuLoeschendeObjekte)
                {
                    _objekte.Remove(objekt);
                }
                _zuLoeschendeObjekte.Clear();

                foreach (Objekt objekt in _objekte)
                {
                    if (objekt is Monster)
                    {
                        Monster monster = (Monster)objekt;
                        monster.Bewege();
                    }
                }

                if (NaechstesLevel == true)
                {
                    _levelNr++;
                    WechsleLevel(_levelNr);

                    NaechstesLevel = false;
                }

                Console.Clear();

                Zeichner.Zeichne(_lAnbieter.Level, _objekte, _spielfigur);

            } while (true);
        }

        public static void WechsleLevel(byte levelnr)
        {
            _objekte = _lAnbieter.LadeLevel(levelnr);

            if (_spielfigur != null)
            {
                Spielfigur duplikat = (Spielfigur)_objekte.Single(p => p.GetType() == typeof(Spielfigur));

                short posObenNeu = duplikat.PosOben;
                short posLinksNeu = duplikat.PosLinks;
                _objekte.Remove(duplikat);

                _spielfigur.Bewege(posObenNeu, posLinksNeu);
                _objekte.Add(_spielfigur);
            }
            else
            {
                _spielfigur = (Spielfigur)_objekte.Single(p => p.GetType() == typeof(Spielfigur));
            }

            foreach (Objekt objekt in _objekte)
            {
                if (objekt is Monster)
                {
                    ((Monster)objekt).SetzeZiel(_spielfigur);
                }
            }
        }

        private static Aktion VerarbeiteEingabe()
        {
            ConsoleKeyInfo gedrueckteTaste;
            gedrueckteTaste = Console.ReadKey();

            switch(gedrueckteTaste.Key)
            {
                case ConsoleKey.UpArrow:
                    return Aktion.BewegeNachOben;
                case ConsoleKey.LeftArrow:
                    return Aktion.BewegeNachLinks;
                case ConsoleKey.DownArrow:
                    return Aktion.BewegeNachUnten;
                case ConsoleKey.RightArrow:
                    return Aktion.BewegeNachRechts;
            }

            return Aktion.BewegeNachUnten;
        }

        public static bool PruefeKollision(short posObenNeu, short posLinksNeu, Figur ausloeser)
        {
            bool kollisionMitLevel = _lAnbieter.PruefeKollision(posObenNeu, posLinksNeu);
            bool kollisionMitObjekt = false;

            foreach (Objekt objekt in _objekte)
            {
                if (objekt.PosOben == posObenNeu && objekt.PosLinks == posLinksNeu)
                {
                    /*
                     * Wieso ein Oder? Es könnte sein, dass zwei objekte 
                     * am gleichen Ort sind.
                     */
                    kollisionMitObjekt |= ausloeser.WirdKollidieren(objekt);
                }
            }

            if (kollisionMitLevel || kollisionMitObjekt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Entferne(Objekt objekt)
        {
            _zuLoeschendeObjekte.Add(objekt);
        }
    }
}
