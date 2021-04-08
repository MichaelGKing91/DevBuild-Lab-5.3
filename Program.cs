using System;
using System.Collections.Generic;

namespace Lab_5._3___Used_Car_Lot
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public Car()
        {
            Make = "no data";
            Model = "no data";
            Year = 0;
            Make = "no data";
            
        }
        public Car(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }
        // Console.WriteLine(calc) --> Calls the override ToString() method if one is available
        // Refrences an object from the class:
        //     Calculator calc = new Calculator();
        //     calc --> returns the 
        // Else --> Prints --> Overloading_2.Calculator
        public override string ToString()
        {
            return $"- Condition: New " +
                $"\n- Make: {Make}" +
                $"\n- Model: {Model}" +
                $"\n- Year: {Year:0000}" +
                $"\n- Price: ${Price:0.00}";
        }

    }
    class UsedCar : Car
    {
        public double Mileage { get; set; }
        public UsedCar(string make, string model, int year, double price, double mileage) : base (make, model, year, price)
        {
            Mileage = mileage;
        }
        public override string ToString()
        {
            return $"- Conditon: Used " +
                $"\n- Make: {Make}" +
                $"\n- Model: {Model}" +
                $"\n- Year: {Year:0000}" +
                $"\n- Price: ${Price:0.00}" +
                $"\n- Mileage: {Mileage}";
        }
    }
    class CarLot
    {
        public List<Car> myCars = new List<Car>();
        public void InternalAddCar()
        {
            myCars.Add(new Car("Ford","Bronco",2021, 39000));
            myCars.Add(new Car("Dodge", "Durango", 2021, 43000));
            myCars.Add(new Car("Jeep", "Wrangler", 2021, 35000));
            myCars.Add(new UsedCar("Ford", "Model-T", 1921, 29000,345221));
            myCars.Add(new UsedCar("Chevrolet", "Trailblazer", 2002, 29000, 21001));
            myCars.Add(new UsedCar("Dodge", "Neon", 1991, 29000, 201965));
        }
        public void UserAddCar()
        {

            Console.WriteLine("Is the car new? (Y/N)");
            string isNew = Console.ReadLine().ToLower();
            while (isNew != "y" && isNew != "yes" && isNew != "n" && isNew != "no")
            {
                Console.Write("\nInvalid response || Play again? (Type 'Y' or 'N'): ");
                isNew = Console.ReadLine().ToLower();
            }
            if (isNew == "y" || isNew == "yes")
            {
                Console.Write("Enter Car Make: ");
                string addMake = Console.ReadLine();
                Console.Write("Enter Car Model: ");
                string addModel = Console.ReadLine();
                Console.Write("Enter Car Year: ");
                int addYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Car Price: ");
                double addPrice = Convert.ToDouble(Console.ReadLine());
                myCars.Add(new Car(addMake, addModel, addYear, addPrice));
            }
            else
            {
                Console.Write("Enter Car Make: ");
                string addMake = Console.ReadLine();
                Console.Write("Enter Car Model: ");
                string addModel = Console.ReadLine();
                Console.Write("Enter Car Year: ");
                int addYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Car Price: ");
                double addPrice = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Car Price: ");
                double addMileage = Convert.ToDouble(Console.ReadLine());
                myCars.Add(new UsedCar(addMake, addModel, addYear, addPrice, addMileage));
            }
        }

        public int ShowCars()
        {
            Console.WriteLine("Available Car Listings: ");
            int count = 0;
            foreach (Car cur in myCars)
            {
                count++;
                Console.WriteLine($"--- Car {count} ---");
                Console.WriteLine(cur);
                Console.WriteLine();

            }
            return count;
        }

        public void SelectCar()
        {
            Console.WriteLine("Which car would you like to purchase (hint: select by car number)?");
            Console.WriteLine("Ex: Trailblazer = 5");
            int selMod = Int32.Parse(Console.ReadLine());
            selMod = selMod - 1;
            Console.WriteLine(myCars[selMod]);
            Console.WriteLine();
            Console.WriteLine("Would you like to puchase this vehicle? (Y/N)");
            string purchYN = Console.ReadLine().ToLower();
            while (purchYN != "y" && purchYN != "yes" && purchYN != "n" && purchYN != "no")
            {
                Console.Write("\nInvalid response || Play again? (Type 'Y' or 'N'): ");
                purchYN = Console.ReadLine().ToLower();
            }
            if (purchYN == "y" || purchYN == "yes")
            {
                Console.WriteLine("Your car has been removed from inventory.");
                myCars.RemoveAt(selMod);
            }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            CarLot myCarLot = new CarLot();
            myCarLot.InternalAddCar();
            Console.WriteLine("Welcome to Big Joe's Car Lot!");
            Console.WriteLine();
            myCarLot.ShowCars();

            bool done = false;
            while (!done)
            {
                // Add user selection statements to the calls below
                // Add quit option
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Select a car for purchase || [2] Add a car to the lot || [3] Veiw all cars");
                int userSel = Convert.ToInt32(Console.ReadLine());
                while (userSel != 1 && userSel != 2 && userSel != 3)
                {
                    Console.Write("\nInvalid response || Please type [1], [2], or [3]: ");
                    userSel = Convert.ToInt32(Console.ReadLine());
                }
                switch (userSel)
                {
                    case 1:
                        myCarLot.SelectCar();
                        break;
                    case 2:
                        myCarLot.UserAddCar();
                        break;
                    case 3:
                        myCarLot.ShowCars();
                        break;
                }




                Console.WriteLine("Would you like to continue to the main menu? (Y/N)");
                string contYN = Console.ReadLine().ToLower();
                while (contYN != "y" && contYN != "yes" && contYN != "n" && contYN != "no")
                {
                    Console.Write("\nInvalid response || Play again? (Type 'Y' or 'N'): ");
                    contYN = Console.ReadLine().ToLower();
                }
                if (contYN == "n" || contYN == "no")
                {
                    done = true;
                }

            }
        }
    }
}
