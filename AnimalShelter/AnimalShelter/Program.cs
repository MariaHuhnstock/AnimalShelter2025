using System;

namespace AnimalShelter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shelter shelter = new Shelter();
            shelter.Animals = SaveSystem.Load();

            string choice = "";

            while (choice != "4")
            {
                Console.WriteLine("\n--- Animal Shelter ---");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. List Animals");
                Console.WriteLine("3. Adopt Animal");
                Console.WriteLine("4. Exit");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Choose animal type (dog/cat/bird):");
                        string type = Console.ReadLine().ToLower();

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());

                        Animal newAnimal = null;

                        if (type == "dog")
                        {
                            Console.Write("Needs walks? (true/false): ");
                            bool needsWalks = bool.Parse(Console.ReadLine());
                            newAnimal = new Dog(name, age, needsWalks);
                        }
                        else if (type == "cat")
                        {
                            Console.Write("Indoor cat? (true/false): ");
                            bool indoorCat = bool.Parse(Console.ReadLine());
                            newAnimal = new Cat(name, age, indoorCat);
                        }
                        else if (type == "bird")
                        {
                            Console.Write("Can talk? (true/false): ");
                            bool canTalk = bool.Parse(Console.ReadLine());
                            newAnimal = new Bird(name, age, canTalk);
                        }
                        else
                        {
                            Console.WriteLine("Invalid type.");
                            break;
                        }

                        shelter.AddAnimal(newAnimal);
                        SaveSystem.Save(shelter.Animals);
                        break;

                    case "2":
                        shelter.ListAnimals();
                        break;

                    case "3":
                        Console.WriteLine("Enter animal name to adopt:");
                        string search = Console.ReadLine();

                        Animal found = shelter.FindByName(search);

                        if (found == null)
                        {
                            Console.WriteLine("Animal not found.");
                        }
                        else
                        {
                            found.Adopt();
                            SaveSystem.Save(shelter.Animals);
                        }
                        break;
                }
            }
        }
    }
}
