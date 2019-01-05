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
        private static List<Objekt> _zuEntfernendeObjekte;
        private static string _nachrichten;
        private static Spielfigur _spielfigur;
        private static byte _levelNr;

        public static bool NaechstesLevel = false;

        static void Main(string[] args)
        {
            //Initialisierung Konsole
            Console.WindowWidth = 80;
            Console.WindowHeight = 30;

            Console.BufferWidth = 80;
            Console.BufferHeight = 30;

            //Levelanbieter erstellen und erstes Level laden
            _lAnbieter = new LevelAnbieter();
            _zuEntfernendeObjekte = new List<Objekt>();

            //Erstes Level setzen
            _levelNr = 2;

            WechsleLevel(_levelNr);

            //Level und Oberfläche zeichnen
            Zeichner.Zeichne(_lAnbieter.Level, _objekte, _spielfigur, _nachrichten);

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
                    case Aktion.WaffenslotA:
                        _spielfigur.BenutzeGegenstand('a');
                        break;
                    case Aktion.WaffenslotB:
                        _spielfigur.BenutzeGegenstand('b');
                        break;
                    case Aktion.WaffenslotC:
                        _spielfigur.BenutzeGegenstand('c');
                        break;
                    case Aktion.LembasBrot:
                        _spielfigur.BenutzeGegenstand('l');
                        break;
                }

                /*
                 * Entferne alle zum entfernen markierten Objekte 
                 * aus der Objektliste. Dies kann nicht direkt durchgeführt
                 * werden, da sonst die Foreach-schleifen eine Ausnahme
                 * auslösen
                 */
                foreach (Objekt objekt in _zuEntfernendeObjekte)
                {
                    _objekte.Remove(objekt);
                }
                _zuEntfernendeObjekte.Clear();

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

                Zeichner.Zeichne(_lAnbieter.Level, _objekte, _spielfigur, _nachrichten);

                _nachrichten = "";

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
                case ConsoleKey.A:
                    return Aktion.WaffenslotA;
                case ConsoleKey.B:
                    return Aktion.WaffenslotB;
                case ConsoleKey.C:
                    return Aktion.WaffenslotC;
                case ConsoleKey.L:
                    return Aktion.LembasBrot;
            }

            return Aktion.BewegeNachUnten;
        }

        /// <summary>
        /// Prüft, ob der Auslöser an der angegebenen Position mit etwas kollidiert.
        /// Ist ein Objekt an der gleichen stelle, so wird beim Auslöser die WirdKollidieren()-Methode
        /// aufgerufen.
        /// </summary>
        /// <param name="posObenNeu"></param>
        /// <param name="posLinksNeu"></param>
        /// <param name="ausloeser"></param>
        /// <returns></returns>
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
            _zuEntfernendeObjekte.Add(objekt);
        }

        public static void Nachricht(string meldung, bool kommaVorher = true)
        {
            if (string.IsNullOrEmpty(_nachrichten))
            {
                _nachrichten = meldung;
            }
            else if (kommaVorher == true)
            {
                _nachrichten = string.Concat(_nachrichten, ", ", meldung);
            }
            else
            {
                _nachrichten += meldung;
            }
        }
    }
}
