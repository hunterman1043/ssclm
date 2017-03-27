using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace HNTR.ViewModels {
	class ViewModelLocator {
		public MainViewModel Main {
			get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
		}

		public FilePanelViewModel File {
			get { return SimpleIoc.Default.GetInstance<FilePanelViewModel>(); }
		}

		public ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<FilePanelViewModel>();
		}
	}
}
