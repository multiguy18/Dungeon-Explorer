﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Figur : Objekt
    {
        public Figur(short posOben, short posLinks) : base(posOben, posLinks)
        {

        }

        protected ushort _HP;
        protected ushort _schaden;
        
        public ushort HP
        {
            get { return _HP; }
        }

        public virtual void Schade(ushort schaden)
        {
            if (schaden > _HP)
            {
                _HP = 0;
            }
            else
            {
                _HP -= schaden;
            }

            if (_HP == 0)
            {
                IstTot();
            }
        }

        protected virtual void IstTot()
        {

        }
    }
}
