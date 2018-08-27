namespace LudoConsole1
{
	internal class Goti
	{
		//Every goti will be owned by some player. But individually a got can have its position, can have its state, Dead or Alive
		GotiStatus gotiStatus = GotiStatus.Dead;
		GotiPosition gotiPosition = new GotiPosition(); 

	}

	public enum GotiStatus
	{
		Dead, 
		Alive
	}; 

}