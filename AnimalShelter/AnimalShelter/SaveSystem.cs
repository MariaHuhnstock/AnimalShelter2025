using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AnimalShelter
{
    public static class SaveSystem
    {
        private static string path = "animals.json";

        public static void Save(List<Animal> animals)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            File.WriteAllText(path, JsonSerializer.Serialize(animals, options));
            Console.WriteLine("Data saved as JSON!");
        }

        public static List<Animal> Load()
        {
            if (!File.Exists(path))
                return new List<Animal>();

            var raw = File.ReadAllText(path);
            var json = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(raw);

            var animals = new List<Animal>();

            foreach (var item in json)
            {
                string type = item["Type"].GetString();
                string name = item["Name"].GetString();
                int age = item["Age"].GetInt32();

                switch (type)
                {
                    case "Dog":
                        bool needsWalks = item.ContainsKey("NeedsWalks") && item["NeedsWalks"].GetBoolean();
                        animals.Add(new Dog(name, age, needsWalks));
                        break;

                    case "Cat":
                        bool indoor = item.ContainsKey("IndoorCat") && item["IndoorCat"].GetBoolean();
                        animals.Add(new Cat(name, age, indoor));
                        break;

                    case "Bird":
                        bool canTalk = item.ContainsKey("CanTalk") && item["CanTalk"].GetBoolean();
                        animals.Add(new Bird(name, age, canTalk));
                        break;
                }
            }

            return animals;
        }
    }
}
