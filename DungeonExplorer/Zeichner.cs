using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Zeichner
    {
        public static void Zeichne()
        {
            
        }

        public static void Textausgabe(string text)
        {
            StringBuilder empty = new StringBuilder();
            empty.Insert(0, " ", 45);

            Console.SetCursorPosition(2, 20);
            Console.Write(empty);

            Console.SetCursorPosition(2, 20);
            Console.Write(text.Take(45).ToArray());

            Console.SetCursorPosition(0, 0);
        }
    }
}
