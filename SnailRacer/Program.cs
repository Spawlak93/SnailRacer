using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnailRacer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Random _rand = new Random();
            int _RaceLength = 1000;
            int _NumbaerOfRacers = 6;
            List<string> _SnailNames = new List<string> { "Sir. Es Car Vango", "Speedy Shelldon", "Slowdo Baggins", "Ronald Speedsly", "The Phantom Mollsk", "Jennifer Slowpez", "Albus Dumblesnore", "Gastro-pod-Racer" };

            Console.Write("Enter the name of your snail:");
            SnailClass PlayerSnail = new SnailClass(Console.ReadLine(), _rand);

            var PlayerOneRace = PlayerSnail.RaceStart(_RaceLength);

            
            var Podium = new List<SnailClass>();
            var RaceTasks = new List<Task<SnailClass>> { PlayerOneRace };
            for (int i = 0; i < _NumbaerOfRacers; i++)
            {
                var snail = new SnailClass(_SnailNames[_rand.Next(_SnailNames.Count)], _rand);
                _SnailNames.Remove(snail.Name);
                RaceTasks.Add(snail.RaceStart(_RaceLength));
                Thread.Sleep(2);
            }

            while (RaceTasks.Count > 0)
            {
                Task<SnailClass> finishedTask = await Task.WhenAny(RaceTasks);
                FinishedRace(Podium.Count + 1, finishedTask.Result.Name);
                Podium.Add(finishedTask.Result);
                RaceTasks.Remove(finishedTask);
            }
            Console.WriteLine("And the results are in!\n" +
                "Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            DrawPodium(Podium);
            Console.WriteLine();
            Console.ReadLine();

        }

        public static void FinishedRace(int finished, String name)
        {
            switch(finished)
            {
                case 1:
                    Console.WriteLine($"{name} Has finished the race in 1st place");
                    break;
                case 2:
                    Console.WriteLine($"{name} Has finished the race in 2nd place");
                    break;
                case 3:
                    Console.WriteLine($"{name} Has finished the race in 3rd place");
                    break;
                default:
                    Console.WriteLine($"{name} Has finished the race in {finished}th place");
                    break;
            }
        }

        public static void DrawPodium(List<SnailClass> snails)
        {
            Console.WriteLine($"\n\n\n\n\n\n\n" +
                string.Format($"{ 0, - 41 }",  snails[0].Name )); 
        }
    }
}
