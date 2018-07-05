using System;
using System.Threading;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public int Hunger { get; set; }
        public int Energy { get; set; }
        public int Happiness { get; set; }
        public static List<Pet> myPets = new List<Pet>() { };
        private int mins;
        private int seconds;
        private bool isDead = false;
        Random rand = new Random();

        public Pet(string name)
        {
            this.Name = name;
            Hunger = 100;
            Energy = 100;
            Happiness = 100;
            myPets.Add(this);
            mins = DateTime.Now.Minute;
            seconds = DateTime.Now.Second;
        }

        public void StartThread() 
        {
            Thread t = new Thread(DeclineStats);
            t.Start();
        }

        public void DeclineStats()
        {
            Hunger -= 7;
            Energy -= 7;
            Happiness -= 7;
        }

        public void UpdateAttributes(string attrArgs)
        {
            StartThread();
            int decrimenter = 0;
            int incrimenter = rand.Next(20, 37);
            int currentMins = DateTime.Now.Minute;
            int currentSeconds = DateTime.Now.Second;
            int timeDifference = ((currentMins * 60) + currentSeconds) - ((mins * 60) + seconds);

            if (timeDifference > 100)
            {
                decrimenter = 75;
            }
            else if (timeDifference > 75)
            {
                decrimenter = 50;
            }
            else if (timeDifference > 50)
            {
                decrimenter = 40;
            }
            else if (timeDifference > 25)
            {
                decrimenter = 30;
            }
            else if(timeDifference > 5) 
            {
                decrimenter = 20;
            }
            else 
            {
                decrimenter = 10;   
            }
                
            if (attrArgs == "feed")
            {
                if(Hunger + incrimenter > 100)
                {
                    incrimenter = 100 - Hunger;
                }
                Hunger += incrimenter;
                Energy -= decrimenter;
                Happiness -= decrimenter;
            }
            else if (attrArgs == "sleep")
            {
                if (Energy + incrimenter > 100)
                {
                    incrimenter = 100 - Energy;
                }
                Energy += incrimenter;
                Hunger -= decrimenter;
                Happiness -= decrimenter;
            }
            else
            {
                if (Happiness + incrimenter > 100)
                {
                    incrimenter = 100 - Happiness;
                }
                Happiness += incrimenter;
                Energy -= decrimenter;
                Hunger -= decrimenter;
            }

            mins = DateTime.Now.Minute;
            seconds = DateTime.Now.Second;
        }

        public bool CheckIfDead() 
        {
            if(Hunger <= 0 || Energy <= 0 || Happiness <= 0)
            {
                isDead = true;
            }

            return isDead;
        }
    }
}
