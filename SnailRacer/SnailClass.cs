using System;
using System.Threading.Tasks;

namespace SnailRacer
{
    public class SnailClass
    {
        private readonly int _MaxSpeedChange = 4;
        private readonly int _MaxSpeed = 10;
        private readonly int _MinSpeed = 3;
        private Random _rand;
        public SnailClass(string name, Random random)
        {
            _rand = random;
            Name = name;
            if (_rand.Next(5) == 0 || Name == "Albus Dumblesnore")
            {
                Speed = 0;
            }
            else
                Speed = _rand.Next(3,7);
        }
        public string Name { get; set; }
        public int Speed { get; set; }

        private void SpeedChange(int i)
        {
            if (Speed == 0)
            {
                Console.WriteLine($"{Name} Woke up with a surge of energy");
                Speed = 7;
                return;
            }
            //40% chance to go slower
            //10% chance of falling asleep
            if(i == 0)
            {
                Speed = 0;
                Console.WriteLine($"{Name} fell asleep");
            }
            else if (i < 5)
            {
                Speed -= _rand.Next(1, _MaxSpeedChange);
                Console.WriteLine($"{Name} slowed down");
                if (Speed <= _MinSpeed)
                {
                    Console.WriteLine($"Is {Name} even still moving?");
                    Speed = _MinSpeed;
                }
                return;
            }
            //50 % chance to go faster
            else
            {
                Speed += _rand.Next(1, _MaxSpeedChange);
                Console.WriteLine($"{Name} sped up");
                if (Speed > _MaxSpeed)
                {
                    Console.WriteLine($"{Name} couldnt go any faster");
                    Speed = _MaxSpeed;
                }
                return;
            }

        }

        public async Task<SnailClass> RaceStart(int raceLength)
        {
            double firstQuarter = raceLength *.75;
            double halfway = raceLength * .5;
            double finalQuarter = raceLength * .25;
                
            if (Speed == 0)
            {
                Console.WriteLine($"{Name} decided to take a nap instead");
                await Task.Delay(3000);
                SpeedChange(10);
            }
            Console.WriteLine($"{Name} has started the race");
            while (raceLength > 0)
            {
                raceLength -= Speed;
                if (raceLength < firstQuarter)
                {
                    Console.WriteLine($"{Name} is a quarter of the way there");
                    firstQuarter = -9999;
                }
                if (raceLength < halfway)
                {
                    Console.WriteLine($"{Name} is halfway done!");
                    halfway = -9999;
                }
                if (raceLength < finalQuarter)
                {
                    finalQuarter = -9999;
                    Console.WriteLine($"{Name} is in the final quarter!");
                }
                //2 % chance of speedchange
                if (_rand.Next(50) == 1)
                    SpeedChange(_rand.Next(10));
                await Task.Delay(_rand.Next(100,300));
            }
            return this;
        }
    }
}
