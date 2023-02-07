namespace Wacky_Races
{
	internal class Program
	{
		/// <summary>
		/// The main program.
		/// Create a new race. call the lineup and run GO until there is a winner. 
		/// Pause the rounds by asking user to press Enter
		/// Finally display the winner.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Race race = new Race();

			race.lineup();

			Console.WriteLine("\n\n\t\t...And they're off.\n");
			while (race.Go() == false)
			{
				Console.WriteLine("\n\nPress Enter for next round!");
				Console.ReadLine();
			}

			race.DisplayWinner();
		}
	}
}