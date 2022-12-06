using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu.Library
{
    internal class Player
    {
        public string Name;
        public int Score;

        public void AddPoint()
        {
            this.Score++;
        }

        public void RemovePoint()
        {
            this.Score--;
        }

        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
        }
    }
}
