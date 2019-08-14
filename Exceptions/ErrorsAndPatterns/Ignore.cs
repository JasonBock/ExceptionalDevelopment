namespace ErrorsAndPatterns
{
	public sealed class Ignore
	{
		private static readonly Ignore use = new Ignore();
		public static Ignore Use() => Ignore.use;
		private Ignore() { }
	}
}