namespace SSLM
{
	public class CloseMessage
	{
		public CloseMessage (bool close)
		{
			Close = close;
		}

		public bool Close { get; private set; }
	}
}
