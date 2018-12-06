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
        public static void Zeichne(byte[,] level, List<Objekt> objekte)
        {
            string konsoleBuffer = "";

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
                Console.SetCursorPosition(obj.PosLinks, obj.PosOben);

                Console.Write(obj.Symbol);
            }


        }

        public static void Textausgabe(string text, bool resetCursor = false)
        {
            StringBuilder empty = new StringBuilder();
            empty.Insert(0, " ", 45);

            Console.SetCursorPosition(2, 20);
            Console.Write(empty);

            Console.SetCursorPosition(2, 20);
            Console.Write(text.Take(45).ToArray());

            if (resetCursor)
            {
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
