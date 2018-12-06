using DungeonExplorer.Objekte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Hauptprogramm
    {
        private static LevelAnbieter _lAnbieter;
        private static List<Objekt> _objekte;
        private static Spielfigur _spielfigur;

        static void Main(string[] args)
        {
            _lAnbieter = new LevelAnbieter();
            _objekte = _lAnbieter.LadeLevel(1);

            _spielfigur = (Spielfigur)_objekte.Single(p => p.GetType() == typeof(Spielfigur));
            //_objekte.Remove(_spielfigur);

            Zeichner.Zeichne(_lAnbieter.Level, _objekte);

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
                Console.Clear();

                Zeichner.Zeichne(_lAnbieter.Level, _objekte);

            } while (true);
        }

        public static void WechsleLevel(byte levelnr)
        {
            
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
    }
}
