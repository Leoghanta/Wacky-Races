using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wacky_Races
{
	/// <summary>
	/// This class handles everything to do with the race, from setting up the competetors to 
	/// handling the disasters. 
	/// </summary>
	internal class Race
	{
		Car[] Carlist = new Car[12];
		int TrackLength = 500;

		/// <summary>
		/// Constructor to build up all the cars into the list.
		/// </summary>
		public Race()
		{

			Carlist[0] = new Car("The Mean Machine", "Dick Dastarly and Muttly", "00", ConsoleColor.DarkBlue, 17);
			Carlist[1] = new Car("The Bouldermobile", "The Slag Brothers", "01", ConsoleColor.DarkCyan, 18);
			Carlist[2] = new Car("The Creepy Coupe", "The Gruesome Twosome", "02", ConsoleColor.DarkMagenta, 19);
			Carlist[3] = new Car("The Convert-a-car", "Professor Pat Pending", "03", ConsoleColor.DarkYellow, 20);
			Carlist[4] = new Car("The Crimson Haybaler", "Red Max", "04", ConsoleColor.Red, 18);
			Carlist[5] = new Car("The Compact Pussycat", "Penelope Pitstop", "05", ConsoleColor.Magenta, 20);
			Carlist[6] = new Car("The Army Surplus Special", "Sergent Blast and Private Meekley", "06", ConsoleColor.DarkGreen, 18);
			Carlist[7] = new Car("The Bulletproof Bomb", "The Ant Hill Mob", "07", ConsoleColor.DarkGray, 18);
			Carlist[8] = new Car("The Arkansas Chug-a-bug", "Lazy Luke and Blubber Bear", "08", ConsoleColor.Blue, 18);
			Carlist[9] = new Car("The Turbo Terrific", "Peter Perfect", "09", ConsoleColor.Yellow, 20);
			Carlist[10] = new Car("The Buzzwagon", "Rufus Ruffcut and Sawtooth", "10", ConsoleColor.Cyan, 19);
			Carlist[11] = new Car("The Bestest", "Jimi The Awesome", "22", ConsoleColor.White, 25);

		}

		/// <summary>
		/// Display the lineup - all cars in original order 00 - 10
		/// </summary>
		public void lineup()
		{
			Console.WriteLine("The Line Up");
			for (int i = 0; i < Carlist.Length; i++)
			{
				Carlist[i].DisplayCar();
			}
		}

		/// <summary>
		/// Display the cars in first, second and third place. 
		/// </summary>
		public void DisplayRanking()
		{
			Console.Write("In the lead, we have ");
			Carlist[0].DisplayCar();
			Console.Write("And a close second second place by ");
			Carlist[1].DisplayCar();
			Console.Write("And in third, ");
			Carlist[2].DisplayCar();
			Console.Write("followed by; ");
			for (int i=3; i<Carlist.Length; i++)
			{
				if (i == Carlist.Length-1)
				{
					Console.WriteLine($" and in last place, Number {Carlist[i].GetNumber()}.");
				} else
				{
					Console.Write($"{Carlist[i].GetNumber()}, ");
				}
			}
		}

		/// <summary>
		/// Display the winner (called when race is over)
		/// </summary>
		public void DisplayWinner()
		{
			Console.WriteLine("\n\n\t\t. o O ( W I N N E R ) O o .");
			Carlist[0].DisplayCar();
		}

		/// <summary>
		/// Adjust ranking - use Bubble Sort to adjust the order of the list
		/// in top to bottom rankings.
		/// </summary>
		public void AdjustRanking() 
		{
			int swaps = 0;

			do
			{
				swaps = 0; // reset the swaps to zero. 
				for (int i = 1; i < Carlist.Length; i++)
				{
					if (Carlist[i].GetMileage() > Carlist[i - 1].GetMileage())
					{
						//rank in order highest to lowest. if i > i-1 then swap.
						(Carlist[i - 1], Carlist[i]) = (Carlist[i], Carlist[i - 1]);
						swaps++; // count up a swap!
					}
				}
			} while (swaps > 0); //continue until no more swaps.

			DisplayRanking();
		}

		/// <summary>
		/// Check if the winning car has travelled the track length
		/// </summary>
		/// <returns>Return true if winner, false if race continues</returns>
		public Boolean CheckWinner()
		{
			if (Carlist[0].GetMileage() >= TrackLength)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Percentage chance of a disaster happening and how it affects the cars. 
		/// Disasters are always caused by Dick Dastardly so they are never affected.
		/// 
		/// </summary>
		private void MakeDisaster(int i)
		{
			Random rnd = new Random();
			int disasterchance = rnd.Next(100);

			Console.ForegroundColor = ConsoleColor.DarkBlue;
			switch (disasterchance)
			{
				case 0:
					Console.WriteLine("Wait, what's that on the track ahead? Someone has sprayed oil on the track!");
					Carlist[i].StallCar("skidding off the track!", 2);
					break;
				case 1:
					Console.WriteLine("What is that crook Dastardly up to now! Nails on the Track? That Scoundrel!");
					Carlist[i].StallCar("a flat tyre", 1);
					break;
				case 2:
					Console.WriteLine("It looks like Muttley is scarring the pigeons. Oh no! Poop Everywhere!");
					Carlist[i].StallCar("skidding on pigeon poop!", 1);
					break;
				case 3:
					Console.WriteLine("What's Dick Dastarly doing with that wattering can?  Quicksand? Oh No!");
					Carlist[i].StallCar("getting stuck in quicksand.", 1);
					break;
				case 4:
					Console.WriteLine("There's Muttley eating bananas, Oh no, he's throwing the skins on the track");
					Carlist[i].StallCar("skidding on banana skins.", 2);
					break;
				case 5:
					Console.WriteLine("Here comes the tunnel. Wait, that tunnel has been painted on the cliffside.");
					Carlist[i].StallCar("crashed into the cliffside.", 2);
					break;
			}

			Console.ForegroundColor= ConsoleColor.Gray;

		}

		/// <summary>
		/// GO! This is one round of the cars. For each car, make them travel their top speed.
		/// After the round, adjust the rankings and check if there is a winner.
		/// </summary>
		/// <returns>Return True if there is a winner to stop the race.</returns>
		public Boolean Go()
		{
			for (int i = 0; i < Carlist.Length; i++)
			{
				Carlist[i].Go();

				//If this car is not dick dastardly, %age chance of disaster!
				if (Carlist[i].GetNumber() != "00")
				{
					MakeDisaster(i);
				}
			}
			AdjustRanking();
			return CheckWinner();
		}


	}
}
