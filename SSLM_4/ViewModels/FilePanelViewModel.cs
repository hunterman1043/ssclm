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
		private RelayCommand<bool> _closeCommand;
		private RelayCommand<bool> _minimizeCommand;

		public string Title { get; private set; }

		public RelayCommand<bool> CloseCommand {
			get {
				return _closeCommand ?? (_closeCommand = new RelayCommand<bool>(
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
				return _minimizeCommand ?? (_minimizeCommand = new RelayCommand<bool>(
					minimize => {
						minimize = true;

						var message = new MinimizeMessage(minimize);

						Messenger.Default.Send(message);
					}
				));
			}
		}

		public FilePanelViewModel () {
			Title = Constants.MAIN_TITLE;
		}
	}
}
