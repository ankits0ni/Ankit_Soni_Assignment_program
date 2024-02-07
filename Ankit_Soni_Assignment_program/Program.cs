using System;

namespace VirtualPetShop
{
    class VirtualPetApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Pet Shop!");

            // Pet creation process via console
            Console.WriteLine("Choose a pet type (Dog, Cat, Fish): ");
            string petType = Console.ReadLine();
            Console.WriteLine("Enter a name for your pet:");
            string petName = Console.ReadLine();

            VirtualPet myPet = new VirtualPet(petType, petName);

            // Display greetings
            Console.WriteLine($"Congratulations! You have a new {myPet.Type} named {myPet.Name}.");

            // Pet Care Loop of selections
            bool isExiting = false;
            while (!isExiting)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Check pet health status");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                // Case loop implimatation
                switch (choice)
                {
                    case "1":
                        myPet.Feed();
                        break;
                    case "2":
                        myPet.Play();
                        break;
                    case "3":
                        myPet.Rest();
                        break;
                    case "4":
                        myPet.CheckHealth();
                        break;
                    case "5":
                        isExiting = true;
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Passage of time function
                myPet.PassTime();

                // Check pet's health condition function
                myPet.EvaluateCondition();
            }
        }
    }

    class VirtualPet
    {
        public string Type { get; }
        public string Name { get; }
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }

        private const int MaxStatValue = 10;
        private const int MinCriticalValue = 3;
        private const int MaxCriticalValue = 8;

        public VirtualPet(string type, string name)
        {
            Type = type;
            Name = name;
            Hunger = MaxStatValue / 2;
            Happiness = MaxStatValue / 2;
            Health = MaxStatValue / 2;
        }

        public void Feed()
        {
            Hunger -= 2;
            if (Hunger < 0) Hunger = 0;
            Health++;
            Console.WriteLine($"{Name} is fed.");
        }

        public void Play()
        {
            if (Hunger >= MinCriticalValue)
            {
                Happiness += 2;
                Hunger++;
                if (Hunger > MaxStatValue) Hunger = MaxStatValue;
                Console.WriteLine($"{Name} is playing.");
            }
            else
            {
                Console.WriteLine($"{Name} is too hungry to play. Feed it first!");
            }
        }

        public void Rest()
        {
            Health++;
            Happiness--;
            if (Happiness < 0) Happiness = 0;
            Console.WriteLine($"{Name} is resting.");
        }

        public void CheckHealth()
        {
            Console.WriteLine($"{Name}'s Health:");
            Console.WriteLine($"Hunger: {Hunger}/{MaxStatValue}");
            Console.WriteLine($"Happiness: {Happiness}/{MaxStatValue}");
            Console.WriteLine($"Health: {Health}/{MaxStatValue}");
        }

        public void PassTime()
        {
            Hunger++;
            Happiness--;
            if (Happiness < 0) Happiness = 0;
            Console.WriteLine("Time passes.");
        }

        public void EvaluateCondition()
        {
            if (Hunger <= MinCriticalValue || Happiness <= MinCriticalValue || Health <= MinCriticalValue)
            {
                Console.WriteLine("Alert: Some stats are critically low!");
            }
            else if (Hunger >= MaxCriticalValue || Happiness >= MaxCriticalValue || Health >= MaxCriticalValue)
            {
                Console.WriteLine("Alert: Some stats are very high!");
            }
        }
    }
}
