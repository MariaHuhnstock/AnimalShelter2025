namespace AnimalShelter
{
    public class Bird : Animal
    {
        public bool CanTalk { get; set; }

        public Bird() { }

        public Bird(string name, int age, bool canTalk)
            : base(name, age, "Bird")
        {
            CanTalk = canTalk;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Can Talk: {CanTalk}");
        }
    }
}
