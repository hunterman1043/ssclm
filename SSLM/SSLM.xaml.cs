// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="ProjectEnterprise">
// Matthew Leslie 2017 GNU 3.0
// </copyright>
// <summary>
// This file contains the main MainWindow Application. (Code-Behind)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SSLM
{
	#region Using Dependencies

	using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;

    using GalaSoft.MvvmLight.Messaging;

	#endregion

	#region Class

	/// <summary>
	/// <see cref="SSLM.MainWindow"/>
	/// </summary>
	public partial class MainWindow
    {
        #region Private Members

		/// <summary>
		/// Delays the animation by <see cref="ANIM_DELAY"/>.
		/// </summary>
		private const int ANIM_DELAY = 150;

		/// <summary>
		/// Floating-point comparison <see cref="TOLERANCE"/>.
		/// </summary>
		private const double TOLERANCE = double.Epsilon;

		#endregion

	    #region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SSLM.MainWindow"/> class.
		/// </summary>
		public MainWindow()
		{
			this.InitializeComponent();

			this.DataContext = new WindowViewModel(this);

			var iconUri = new Uri("pack://application:,,,/Resources/Images/Logo/logo.ico", UriKind.RelativeOrAbsolute);
			this.Icon = BitmapFrame.Create(iconUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);

			Messenger.Default.Register<CloseMessage>(
				this,
				message => 
				{
					if (message.Close)
					{
						this.Close();
					}
				});

			Messenger.Default.Register<MinimizeMessage>(
				this,
				message => 
				{
					if (message.Minimize)
					{
						this.MinimizeAnim();
					}
				});
		}

		#endregion

		#region Events

		/// <summary>
		/// The <see cref="WindowActivated"/> event method.
		/// </summary>
		/// <param name="sender">
		/// The <see cref="sender"/> is ignored.
		/// </param>
		/// <param name="e">
		/// The <see cref="e"/> event is ignored.
		/// </param>
		private void WindowActivated(object sender, EventArgs e)
        {
	        if (Math.Abs(this.Opacity - 100) > TOLERANCE && this.WindowState != WindowState.Normal)
	        {
		        this.Dispatcher.BeginInvoke(
			        DispatcherPriority.ApplicationIdle,
			        (DispatcherOperationCallback)delegate
				        {
					        this.NormalizeAnim();
					        return null;
				        },
			        null);
	        }
        }

		#endregion

	    #region Awaited Private Methods

		/// <summary>
		/// Sets the window to be in a <see cref="WindowState.Minimized"/> state in an awaited Task.
		/// </summary>
		private async void MinimizeAnim()
		{
			var opacityAnim = new DoubleAnimation
				                  {
					                  From = 1,
					                  To = 0,
					                  Duration = new Duration(TimeSpan.FromMilliseconds(ANIM_DELAY))
				                  };

			this.BeginAnimation(OpacityProperty, opacityAnim);

			await Task.Delay(ANIM_DELAY);

			this.WindowState = WindowState.Minimized;
		}

		/// <summary>
		/// Sets the window to be in a <see cref="WindowState.Normal"/> state in an awaited Task.
		/// </summary>
		private async void NormalizeAnim()
		{
			var opacityAnim = new DoubleAnimation
				                  {
					                  From = 0,
					                  To = 1,
					                  Duration = new Duration(TimeSpan.FromMilliseconds(ANIM_DELAY))
				                  };

			this.BeginAnimation(OpacityProperty, opacityAnim);

			await Task.Delay(ANIM_DELAY);

			this.WindowState = WindowState.Normal;
		}

		#endregion
	}

	#endregion
}
