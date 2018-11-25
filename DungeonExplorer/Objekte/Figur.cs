using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Objekte
{
    public abstract class Figur
    {
        protected ushort _HP;
        protected ushort _schaden;

        public void Schade(ushort schaden)
        {
            if (schaden > _HP)
            {
                _HP = 0;
            }
            else
            {
                _HP -= schaden;
            }
        }
    }
}
