using System;
using System.Threading;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class PetAttribute
    {
        public static int Hunger { get; set; } 
        public static int Energy { get; set; } 
        public static int Happiness { get; set; }

        public PetAttribute() 
        {
            Hunger = 100;
            Energy = 100;
            Happiness = 100;
        }

        public static void DeclineStats()
        {
            Hunger -= 5;
            Energy -= 5;
            Happiness -= 5;
            Thread.Sleep(5000);
        }
    }
}
