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
        private ushort _maxHP;
        private Dictionary<char, Gegenstand> _gegenstaende;

        public string Name { get; private set; }
        public Spielfigur(string name, short posOben, short posLinks) : base (posOben, posLinks)
        {
            Name = name;
            _symbol = '@';
            _HP = 30;
            _maxHP = 30;
            _schaden = 5;

            _gegenstaende = new Dictionary<char, Gegenstand>()
            {
                { 'l', null }
            };
        }

        public void Heile(byte menge)
        {
            if (menge + _HP > _maxHP)
            {
                _HP = 30;
            }
            else
            {
                _HP += menge;
            }
        }

        public ushort HP
        {
            get { return _HP; }
        }

        public ushort MaxHP
        {
            get { return _maxHP; }
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
            else if (anderes is Monster)
            {
                //TODO: If zum überprüfen ob eine Waffe ausgewählt ist
                Monster monster = (Monster)anderes;

                Random zufallsgen = new Random();
                if (zufallsgen.NextDouble() < 0.75)
                {
                    Hauptprogramm.Nachricht(monster.Bezeichnung + " wurde verletzt");
                    monster.Schade(_schaden);
                }
            }
            else if (anderes is Gegenstand)
            {
                ConsoleKey taste;

                do
                {
                    Zeichner.Textausgabe("\"" + anderes.Bezeichnung + "\" aufheben?: ");
                    taste = Console.ReadKey().Key;
                } while (taste != ConsoleKey.J && taste != ConsoleKey.N);

                if (taste == ConsoleKey.N)
                {
                    return false;
                }

                Gegenstand gegenstand = (Gegenstand)anderes;
                string slots = gegenstand.Slots;

                for (byte i = 0; i < slots.Length; i++)
                {
                    if (_gegenstaende[slots[i]] == null)
                    {
                        _gegenstaende[slots[i]] = gegenstand;
                        gegenstand.SetzeSpieler(this);


                        Hauptprogramm.Entferne(gegenstand);
                        return false;
                    }
                }

                Hauptprogramm.Nachricht("Gegenstand kann nicht ins Inventar gelegt werden.");

                return false;
            }

            return true;
        }

        public void BenutzeGegenstand(char slot)
        {
            //TODO: Anderes Verhalten für Waffen
            if (_gegenstaende[slot] != null)
            {
                _gegenstaende[slot].Benutze();
                _gegenstaende[slot] = null;
            }
        }
    }
}