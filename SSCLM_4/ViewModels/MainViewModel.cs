using HNTR.Models;

namespace HNTR.ViewModels {
	class MainViewModel {
		private DocumentModel _document;
		public FilePanelViewModel File { get; set; }

		public MainViewModel () {
			_document = new DocumentModel();
			File = new FilePanelViewModel(_document);
		}
	}
}
