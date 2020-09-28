using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailRacer
{
    public class RaceClass
    {
        public RaceClass(int raceLength)
        {
            RaceLength = raceLength;
        }
        public int RaceLength { get; set; }

        public async Task RaceStart(SnailClass snail)
        {

        }
    }
}
