namespace SSLM
{
	using GalaSoft.MvvmLight.Ioc;
	using Microsoft.Practices.ServiceLocation;

	class ViewModelLocator
	{
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<FilePanelViewModel>();
		}

		public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();


		public FilePanelViewModel File => SimpleIoc.Default.GetInstance<FilePanelViewModel>();
	}
}
