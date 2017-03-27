namespace HNTR.Helpers
{
	public class MinimizeMessage {
		public bool Minimize { get; private set; }

		public MinimizeMessage (bool minimize) {
			Minimize = minimize;
		}
	}
}
