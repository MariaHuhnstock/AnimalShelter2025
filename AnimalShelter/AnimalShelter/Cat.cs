namespace AnimalShelter
{
    public class Cat : Animal
    {
        public bool IndoorCat { get; set; }

        public Cat() { }

        public Cat(string name, int age, bool indoorCat)
            : base(name, age, "Cat")
        {
            IndoorCat = indoorCat;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Indoor Cat: {IndoorCat}");
        }
    }
}
