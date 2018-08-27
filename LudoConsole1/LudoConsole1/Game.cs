using System;
using System.Collections.Generic;

namespace LudoConsole1
{
	internal class Game
	{
		List<Player> players = new List<Player>(); 
		private int numPlayers;

		public Game(int numPlayers)
		{
			this.numPlayers = numPlayers;
			for (int i = 1; i <= numPlayers; i++)
			{
				Player p = new Player(i);
				players.Add(p); 
			}
		}

		internal void Start()
		{
			

		}
	}
}