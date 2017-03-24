using GalaSoft.MvvmLight;
using HNTR.Models;

namespace HNTR.ViewModels {
	class MainViewModel : ViewModelBase {
		private DocumentModel _document;
		public FilePanelViewModel File { get; private set; }

		public MainViewModel () {
			_document = new DocumentModel();
			/*File = new FilePanelViewModel(_document);
			File.RequestClose += (s, e) => Dispatcher.Invoke (this.Close);
			File.RequestMinimize += (s, e) => Dispatcher.Invoke (() => { this.WindowState = WindowState.Minimized; });*/
		}
	}
}
