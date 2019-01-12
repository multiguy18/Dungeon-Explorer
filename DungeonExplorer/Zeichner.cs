using DungeonExplorer.Objekte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Zeichner
    {
        public static void Zeichne(byte[,] level, List<Objekt> objekte, Spielfigur spielfigur, string nachrichten)
        {
            string konsoleBuffer = "";
            Dictionary<char, string> inventar;

            for (short zeile = 0; zeile < level.GetLength(0); zeile++)
            {
                for (short spalte = 0; spalte < level.GetLength(1); spalte++)
                {
                    switch (level[zeile,spalte])
                    {
                        case 1:
                            konsoleBuffer += "|";
                            break;
                        case 2:
                            konsoleBuffer += ".";
                            break;
                        case 3:
                            konsoleBuffer += "#";
                            break;
                        default:
                            konsoleBuffer += " ";
                            break;
                    }
                }
                konsoleBuffer += "\n";
            }
            
            Console.Write(konsoleBuffer);

            foreach (Objekt obj in objekte)
            {
                if (!(obj is Spielfigur))
                {
                    Console.SetCursorPosition(obj.PosLinks, obj.PosOben);
                    Console.Write(obj.Symbol);
                }
            }

            //Spielfigur zeichnen
            Console.SetCursorPosition(spielfigur.PosLinks, spielfigur.PosOben);
            Console.Write(spielfigur.Symbol);

            //Spielerwerte anzeigen
            Console.SetCursorPosition(1, 26);
            Console.Write(spielfigur.Name + " / HP:" + spielfigur.HP + " MaxHP:" + spielfigur.MaxHP + " EP:" + spielfigur.EP + " MaxEP:" + spielfigur.MaxEP + " LV:" + spielfigur.Level + " DMG:" + spielfigur.Schaden);
            Console.SetCursorPosition(56, 3);

            inventar = spielfigur.ZeigeInventar();

            foreach (char schluessel in inventar.Keys)
            {
                Console.Write(schluessel + " : " + inventar[schluessel]);
                Console.CursorTop++;
                Console.CursorLeft = 56;
            }

            Console.SetCursorPosition(0, 28);
            Console.Write(nachrichten);

            Console.SetCursorPosition(0, 0);
        }

        public static void Textausgabe(string text, bool resetCursor = false)
        {
            StringBuilder empty = new StringBuilder();
            empty.Insert(0, " ", 55);

            Console.SetCursorPosition(2, 27);
            Console.Write(empty);

            Console.SetCursorPosition(2, 27);
            Console.Write(text.Take(55).ToArray());

            if (resetCursor)
            {
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
