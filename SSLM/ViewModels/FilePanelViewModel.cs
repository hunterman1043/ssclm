namespace SSLM
{
	using Core;
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Command;
	using GalaSoft.MvvmLight.Messaging;

	public class FilePanelViewModel : ViewModelBase
	{
		private RelayCommand<bool> closeCommand;
		private RelayCommand<bool> minimizeCommand;

		public FilePanelViewModel()
		{
			Title = Constants.MainTitle;
		}

		public string Title { get; private set; }

		public RelayCommand<bool> CloseCommand => 
			closeCommand ?? (closeCommand = new RelayCommand<bool>(
				close => 
				{
					var message = new CloseMessage(true);

					Messenger.Default.Send(message);
				}));

		public RelayCommand<bool> MinimizeCommand => 
			this.minimizeCommand ?? (this.minimizeCommand = new RelayCommand<bool>(
				minimize => 
				{
					var message = new MinimizeMessage(true);

					Messenger.Default.Send(message);
				}));

	}
}
