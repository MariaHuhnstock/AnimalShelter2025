namespace AnimalShelter
{
    public class Dog : Animal
    {
        public bool NeedsWalks { get; set; }

        public Dog() { }

        public Dog(string name, int age, bool needsWalks)
            : base(name, age, "Dog")
        {
            NeedsWalks = needsWalks;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Needs Walks: {NeedsWalks}");
        }
    }
}
