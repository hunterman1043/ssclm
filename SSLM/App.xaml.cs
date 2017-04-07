// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="ProjectEnterprise">
// Matthew Leslie 2017 GNU 3.0
// </copyright>
// <summary>
// This file contains the MainWindow Application Entry Point. (Code-Behind)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SSLM
{
	#region Using Depedencies

	using System.Windows;

	#endregion

	#region Constructor

	/// <summary>
	/// Entry point to main application
	/// </summary>
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Current.MainWindow = new MainWindow();
			Current.MainWindow.Show();
		}
	}

	#endregion
}
