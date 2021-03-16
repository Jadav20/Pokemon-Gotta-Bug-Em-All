using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    /// <summary>
    /// Class to represent moves (attacks in Pokemon), currently only holds a name that we're going to use for flavour
    /// </summary>
    public class Move
    {
        public string Name { get; }
        public int Power { get; }

        public Move(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
    }
}
