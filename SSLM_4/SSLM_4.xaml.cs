using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;
using HNTR.Helpers;
using HNTR.ViewModels;

namespace HNTR {
	public partial class SSLM_4 : Window {
		private const int ANIM_DELAY = 150;

		public SSLM_4 () {
			InitializeComponent();

			this.DataContext = new WindowViewModel(this);

			Uri iconUri = new Uri("pack://application:,,,/Resources/Images/Logo/logo.ico", UriKind.RelativeOrAbsolute);
			this.Icon = BitmapFrame.Create(iconUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);

			Messenger.Default.Register<CloseMessage>(
				this,
				message => {
					if (message.Close == true) {
						this.Close();
					}
				}
			);

			Messenger.Default.Register<MinimizeMessage>(
				this,
				message => {
					if (message.Minimize == true) {
						MinimizeAnim();
					}
				}
			);
		}

		private void Window_Activated(object sender, System.EventArgs e)
		{
			if (this.Opacity != 100 && WindowState != WindowState.Normal) {
				Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (DispatcherOperationCallback)delegate (object unused) {
					NormalizeAnim();
					return null;
				}
				, null);
			}
		}

		private async void MinimizeAnim() {
			DoubleAnimation _opacityAnim = new DoubleAnimation();
			_opacityAnim.From = 1;
			_opacityAnim.To = 0;
			_opacityAnim.Duration = new Duration(TimeSpan.FromMilliseconds(ANIM_DELAY));
			this.BeginAnimation(OpacityProperty, _opacityAnim);

			await Task.Delay(ANIM_DELAY);

			WindowState = WindowState.Minimized;
		}

		private async void NormalizeAnim()
		{
			DoubleAnimation _opacityAnim = new DoubleAnimation();
			_opacityAnim.From = 0;
			_opacityAnim.To = 1;
			_opacityAnim.Duration = new Duration(TimeSpan.FromMilliseconds(ANIM_DELAY));
			this.BeginAnimation(OpacityProperty, _opacityAnim);

			await Task.Delay(ANIM_DELAY);

			WindowState = WindowState.Normal;
		}
	}
}
