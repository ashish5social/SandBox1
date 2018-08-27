namespace LudoConsole1
{
	internal class Player
	{
		private int playerNumber;
		//Every player will have 
		List<Goti> gotis = new List<Goti>(); 



		public Player(int playerNumber)
		{
			this.playerNumber = playerNumber;
			//Player numer 1 means Red, 2=Green, 3=Blue, 4=Yellow
		}
	}
}