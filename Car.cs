using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wacky_Races
{
	/// <summary>
	/// This is the car class, every car is built from this blueprint.
	/// </summary>
	internal class Car
	{
		String CarName;				// Name of the car
		String DriverName;			// Driver's Name(s)
		String CarNumber;			// The car's race number (as a string so we can have trailing 0's
		ConsoleColor CarColour;		// The colour of the car
		int TopSpeed;				// the top speed of the car. Cars go at this top speed
		int Mileage = 0;			// Mileage - how far the car has travelled.
		int Stalled = 0;			// If the car stalls, this will count down.

		/// <summary>
		/// Constructor to build the car. This will create the car and add a bit of randomness to the
		/// top speed. This gives a bit of an edge to those faster cars.
		/// </summary>
		/// <param name="carName">The name of the car as a string</param>
		/// <param name="driverName">The driver(s) name</param>
		/// <param name="carNumber">the number of the car as a string</param>
		/// <param name="color">the colour of the car as a ConsoleColor</param>
		/// <param name="topspeed">The integer top speed of the car (around 20)</param>
		public Car(string carName, string driverName, string carNumber, ConsoleColor color, int topspeed)
		{
			CarName = carName;
			DriverName = driverName;
			CarNumber = carNumber;
			CarColour = color;
			TopSpeed = topspeed;

			//Add a bit of randomness to the top speed
			Random rnd = new Random();
			int x = rnd.Next(5) - 3;
			Console.WriteLine($"Speed adjusted by {x}");
			TopSpeed += x;  // top speed adjusted from -2 to +2

		}

		/// <summary>
		/// Displays the carnumber, carname and who it's driven by.
		/// !!For testing, added the top speed and mileage
		/// </summary>
		public void DisplayCar()
		{
			Console.ForegroundColor = CarColour;
			Console.WriteLine($"car {CarNumber}, {CarName} driven by {DriverName} ({TopSpeed}/{Mileage})");
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// GO!  the cars travel.  
		/// If the car has stalled for any reason, count down the stall until 0. then they can go again.
		/// There's a percent chance of flooring it round a bend, and a percent chance of slowing down.
		/// </summary>
		public void Go()
		{
			if (Stalled > 0)
			{
				//car is out of commission!
				Stalled -= 1;
				return;
			}

			Random rnd =new Random();
			int x = rnd.Next(100);
			if (x <= 2)
			{
				Console.ForegroundColor = CarColour;
				Console.WriteLine($"Whoah! {DriverName} floors it round that bend!");
				Mileage += 5;
				Console.ForegroundColor = ConsoleColor.Gray;
			}
			else if (x > 98)
			{
				Console.ForegroundColor = CarColour;
				Console.WriteLine($"Oh No! {CarName} has slowed down.");
				Mileage -= 3;
				Console.ForegroundColor = ConsoleColor.Gray;
			}
			else
			{
				Mileage += TopSpeed;
			}
		}

		/// <summary>
		/// Returns the car's current mileage.
		/// </summary>
		/// <returns>Integer of mileage</returns>
		public int GetMileage()
		{
			return Mileage;
		}

		/// <summary>
		/// returns the car's colour
		/// </summary>
		/// <returns>ConsoleColor of car</returns>
		public ConsoleColor GetColour()
		{
			return CarColour ;
		}

		/// <summary>
		/// Returns the car's race number. 
		/// </summary>
		/// <returns>Racenumber as String</returns>
		public string GetNumber()
		{
			return CarNumber;
		}

		/// <summary>
		/// Stall the car.  Accept a reason, and how many rounds the car will be stalled for.
		/// </summary>
		/// <param name="reason">String to describe what happened</param>
		/// <param name="rounds">Integer of how many rounds they are out of the race.</param>
		public void StallCar(String reason, int rounds)
		{
			Console.ForegroundColor = CarColour;
			Console.WriteLine($"OH NO! {DriverName} is having trouble with {reason}.");
			Console.ForegroundColor = ConsoleColor.Gray;
			Stalled = rounds;
		}

	}

}
