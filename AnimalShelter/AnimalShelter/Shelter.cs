using System;
using System.Collections.Generic;

namespace AnimalShelter
{
    public class Shelter
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine($"{animal.Name} added to the shelter!");
        }

        public void ListAnimals()
        {
            if (Animals.Count == 0)
            {
                Console.WriteLine("No animals in the shelter.");
                return;
            }

            Console.WriteLine("\n--- Animals in Shelter ---");
            foreach (var animal in Animals)
            {
                animal.ShowInfo();
            }
        }

        public Animal FindByName(string name)
        {
            return Animals.Find(a => a.Name.ToLower() == name.ToLower());
        }
    }
}
