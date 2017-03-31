// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SSLM.xaml.cs" company="ProjectEnterprise">
//  Matthew Leslie 2017 GNU 3.0
// </copyright>
// <summary>
//   Defines the SSLM type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HNTR
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;

    using GalaSoft.MvvmLight.Messaging;

    using HNTR.Helpers;
    using HNTR.ViewModels;

    /// <summary>
    /// Code-behind to XAML <see cref="SSLM"/>
    /// </summary>
    public partial class SSLM
    {
        #region Private Members

		/// <summary>
		/// Delays the animation by <see cref="ANIMDELAY"/>.
		/// </summary>
		private const int ANIMDELAY = 150;
        #endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="SSLM"/> class.
		/// </summary>
		public SSLM()
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

        /// <summary>
        /// TODO The window_ activated.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        private void Window_Activated(object sender, EventArgs e)
		{
			if (this.Opacity != 100 && WindowState != WindowState.Normal)
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

		private async void MinimizeAnim()
		{
			DoubleAnimation _opacityAnim = new DoubleAnimation();
			_opacityAnim.From = 1;
			_opacityAnim.To = 0;
			_opacityAnim.Duration = new Duration(TimeSpan.FromMilliseconds(ANIMDELAY));
			this.BeginAnimation(OpacityProperty, _opacityAnim);

			await Task.Delay(ANIMDELAY);

			WindowState = WindowState.Minimized;
		}

		private async void NormalizeAnim()
		{
			DoubleAnimation _opacityAnim = new DoubleAnimation();
			_opacityAnim.From = 0;
			_opacityAnim.To = 1;
			_opacityAnim.Duration = new Duration(TimeSpan.FromMilliseconds(ANIMDELAY));
			this.BeginAnimation(OpacityProperty, _opacityAnim);

			await Task.Delay(ANIMDELAY);

			WindowState = WindowState.Normal;
		}
	}
}
