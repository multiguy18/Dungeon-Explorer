using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Spielfigur : Figur
    {
        public string Name { get; private set; }
        public Spielfigur(string name, short posOben, short posLinks) : base (posOben, posLinks)
        {
            Name = name;
            _symbol = '@';
        }

        public void Bewege(short posOben, short posLinks)
        {
            _posOben = posOben;
            _posLinks = posLinks;
        }

        public void Bewege()
        {
            throw new NotImplementedException();
        }
        
    }
}
