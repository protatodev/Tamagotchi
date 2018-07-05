using System;
using System.Collections.Generic;


namespace Tamagotchi.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public int Hunger { get; set; }
        public int Energy { get; set; }
        public int Happiness { get; set; }
        private static List<Pet> pets = new List<Pet> { };
        private PetAttribute attributes = new PetAttribute();

        public Pet(string name)
        {
            Name = name;
            Hunger = 100;
            Energy = 100;
            Happiness = 100;
            pets.Add(this);
        }

        public static IEnumerable<Pet> GetAll()
        {
            return pets;
        }

        public void UpdateAttributes() 
        {
            
        }
    }
}
