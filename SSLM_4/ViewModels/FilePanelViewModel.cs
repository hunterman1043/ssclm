using System;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HNTR.Models;

namespace HNTR.ViewModels {
	public class FilePanelViewModel : ViewModelBase {
		public string Title { get; private set; }
		public string Name { 
			get { return _name; }
			set
			{
				Set(() => Name, ref _name, value);
			}
		}

		public ICommand CloseCommand { get; }
		public ICommand DragCommand { get; }

		private string _name;

		public FilePanelViewModel (/*IMessenger messenger*/) {
			Title = Constants.MAIN_TITLE;
			//if (messenger == null)
			//	throw new ArgumentNullException("messenger");

			//MessengerInstance = messenger;
			//MessengerInstance.Register<string>(this, s => Name = s);
		}

        private void CloseWindow() {
            
        }

		private void DragWindow() {
			
		}

		public void SendMessage(string message)
		{
			MessengerInstance.Send(message);
		}
	}
}
