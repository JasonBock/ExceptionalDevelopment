namespace Exceptions
{
	public static class Uses
	{
		public static void CreateAndUse()
		{
			using (var resource = new DisposableResource())
			{
				resource.Use();
			}
		}
	}
}
