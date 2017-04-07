namespace SSLM
{
	public class MinimizeMessage
	{
		public MinimizeMessage (bool minimize)
		{
			Minimize = minimize;
		}

		public bool Minimize { get; private set; }
	}
}
