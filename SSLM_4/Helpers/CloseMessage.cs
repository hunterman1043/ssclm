namespace HNTR.Helpers
{
	public class CloseMessage {
		public bool Close { get; private set; }

		public CloseMessage (bool close) {
			Close = close;
		}
	}
}
