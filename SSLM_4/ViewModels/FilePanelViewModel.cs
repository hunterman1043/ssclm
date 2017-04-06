using System;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HNTR.Models;
using HNTR.Helpers;
using System.Diagnostics;

namespace HNTR.ViewModels {
	public class FilePanelViewModel : ViewModelBase {
		private RelayCommand<bool> closeCommand;
		private RelayCommand<bool> minimizeCommand;

		public string Title { get; private set; }

		public RelayCommand<bool> CloseCommand {
			get {
				return this.closeCommand ?? (this.closeCommand = new RelayCommand<bool>(
					close => {
						close = true;

						var message = new CloseMessage(close);

						Messenger.Default.Send(message);
					}
				));
			}
		}

		public RelayCommand<bool> MinimizeCommand {
			get {
				return this.minimizeCommand ?? (this.minimizeCommand = new RelayCommand<bool>(
					minimize => {
						minimize = true;

						var message = new MinimizeMessage(minimize);

						Messenger.Default.Send(message);
					}
				));
			}
		}

		public FilePanelViewModel () {
			Title = Constants.MainTitle;
		}
	}
}
