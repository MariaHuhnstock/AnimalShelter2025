using System;

namespace AnimalShelter
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public bool IsAdopted { get; private set; }

        // Für JSON: Speichert den tatsächlichen Typ
        public string Type => GetType().Name;

        public Animal() { }

        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
            IsAdopted = false;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}, Adopted: {IsAdopted}");
        }

        public void Adopt()
        {
            if (IsAdopted)
            {
                Console.WriteLine($"{Name} is already adopted.");
                return;
            }

            IsAdopted = true;
            Console.WriteLine($"{Name} has been adopted!");
        }
    }
}
