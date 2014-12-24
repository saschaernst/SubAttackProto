namespace SubAttack
{
	public sealed class CId
	{
		public static int count = 0;
		readonly public static int None = count++;
		readonly public static int Position = count++;
		readonly public static int Orientation = count++;
		readonly public static int Speed = count++;
		readonly public static int View = count++;
		readonly public static int Navigation = count++;
	}
}
