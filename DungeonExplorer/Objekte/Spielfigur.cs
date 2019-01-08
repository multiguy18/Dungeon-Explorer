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

        private byte _spielerLevel;
        private ushort _EP;
        private ushort _maxEP;

        private Dictionary<char, Gegenstand> _gegenstaende;
        private Waffe _aktuelleWaffe = null;

        public string Name { get; private set; }
        public Spielfigur(string name, short posOben, short posLinks) : base (posOben, posLinks)
        {
            Name = name;
            _symbol = '@';
            _HP = 30;
            _maxHP = 30;
            _maxEP = 15;
            _spielerLevel = 1;
            _schaden = 5;

            _gegenstaende = new Dictionary<char, Gegenstand>()
            {
                { 'a', null },
                { 'b', null },
                { 'c', null },
                { 'd', null },
                { 'e', null },
                { 'i', null },
                { 'j', null },
                { 'k', null },
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

        public ushort MaxHP
        {
            get { return _maxHP; }
        }

        public ushort EP
        {
            get { return _EP; }
        }

        public ushort MaxEP
        {
            get { return _maxEP; }
        }

        public ushort Level
        {
            get { return _spielerLevel; }
        }

        public ushort Schaden
        {
            get { return _schaden; }
        }

        public void ErhoeheSchaden(ushort menge)
        {
            if (menge + _schaden > ushort.MaxValue)
            {
                _schaden = ushort.MaxValue;
            }
            else
            {
                _schaden += menge;
            }
        }

        public void VerringereSchaden(ushort menge)
        {
            if (_schaden - menge < 0)
            {
                _schaden = 0;
            }
            else
            {
                _schaden -= menge;
            }
        }

        public void Belohne(ushort menge)
        {
            //Mehrfacher Levelaufstieg falls Menge über ein Levelaustieg hinausgeht
            if (menge + _EP >= _maxEP)
            {
                while (menge + _EP >= _maxEP)
                {
                    _EP += menge;
                    _EP -= _maxEP;
                    menge = _EP;
                    Levelaufstieg();
                    _EP = 0;
                }
            }
            _EP += menge;
        }

        public void Levelaufstieg()
        {
            _spielerLevel++;
            _maxEP += 15;
            _maxHP += 5;
            _schaden += 3;
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
            }
            else if (anderes is Monster)
            {
                Monster monster = (Monster)anderes;

                if(_aktuelleWaffe == null)
                {
                    Random zufallsgen = new Random();
                    if (zufallsgen.NextDouble() < 0.75)
                    {
                        Hauptprogramm.Nachricht(monster.Bezeichnung + " wurde verletzt");
                        monster.Schade(_schaden);
                    }
                    else
                    {
                        Hauptprogramm.Nachricht(monster.Bezeichnung + " wurde verfehlt");
                    }
                }
                else
                {
                    bool getroffen = _aktuelleWaffe.Angriff(monster);
                    if (getroffen)
                    {
                        Hauptprogramm.Nachricht(monster.Bezeichnung + " wurde verletzt");
                        monster.Schade(_schaden);
                    }
                    else
                    {
                        Hauptprogramm.Nachricht(monster.Bezeichnung + " wurde verfehlt");
                    }
                }

                if (monster.HP == 0)
                {
                    Hauptprogramm.Nachricht(monster.Bezeichnung + " ist Tot");
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
            Gegenstand gegenstand = _gegenstaende[slot];

            if (gegenstand != null)
            {
                if (gegenstand is Waffe || gegenstand is Ruestung)
                {
                    gegenstand.Benutze();
                }
                else
                {
                    _gegenstaende[slot].Benutze();
                    _gegenstaende[slot] = null;
                }
            }
        }

        
        public Dictionary<char, string> ZeigeInventar()
        {
            Dictionary<char, string> info = new Dictionary<char, string>();

            foreach (char schluessel in _gegenstaende.Keys)
            {
                Gegenstand gegenstand = _gegenstaende[schluessel];
                string beschriftung;

                if (gegenstand == null)
                {
                    info.Add(schluessel, "-");
                }
                else if (gegenstand is Waffe)
                {
                    Waffe waffe = (Waffe)gegenstand;
                    beschriftung = waffe.Bezeichnung + " (+" + waffe.Waffenschaden + ")";

                    if (_aktuelleWaffe != null && _aktuelleWaffe == waffe)
                    {
                        beschriftung += " *";
                    }

                    info.Add(schluessel, beschriftung);
                }
                else if  (gegenstand is Ruestung)
                {
                    Ruestung ruestung = (Ruestung)gegenstand;
                    beschriftung = ruestung.Bezeichnung + " (+" + ruestung.Wert + ")";

                    info.Add(schluessel, beschriftung);
                }
                else
                {
                    info.Add(schluessel, gegenstand.Bezeichnung);
                }
            }

            return info;
        }

        public void WaffeAusruesten(Waffe waffe)
        {
            _aktuelleWaffe = waffe;
        }
    }
}