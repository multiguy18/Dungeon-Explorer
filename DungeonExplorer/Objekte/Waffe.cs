﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public class Waffe : Gegenstand
    {
        public Waffe(short posOben, short posLinks) : base(posOben, posLinks)
        {
        }

        public override void Benutze()
        {
            
        }

        public bool Angriff()
        {

        }
    }
}