using System;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using HNTR.Models;

namespace HNTR.ViewModels {
	public class FilePanelViewModel {
		public DocumentModel Document { get; private set; }
		public ICommand DragCommand { get; }

		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute ("user32.dll")]
		public static extern int SendMessage (IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute ("user32.dll")]
		public static extern bool ReleaseCapture ();

		public FilePanelViewModel (DocumentModel document) {
			Document = document;
			DragCommand = new RelayCommand (DragWindow);
			//File.RequestClose += (s, e) => Dispatcher.Invoke (this.Close);
			//File.RequestMinimize += (s, e) => Dispatcher.Invoke (() => { this.WindowState = WindowState.Minimized; });
		}

		private void DragWindow() {
			//Debug.WriteLine ("Hello World");
			//Window.DragMove();

			ReleaseCapture ();
			SendMessage (new WindowInteropHelper (this).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
		}

		/*public ICommand CloseCommand { get; }
		public ICommand MinimizeCommand { get; }

		public event EventHandler<EventArgs> RequestClose;
		public event EventHandler<EventArgs> RequestMinimize;

		public FilePanelViewModel (DocumentModel document) {
			Document = document;
		}

		private void SetupCommands () {
			CloseCommand = new RelayCommand (CloseApplication);
			MinimizeCommand = new RelayCommand (MinimizeApplication);
		}

		private void MinimizeApplication (object obj) {
			RequestMinimize (this, new EventArgs ());
		}
		private void CloseApplication (object obj) {
			RequestClose (this, new EventArgs ());
		} */

		/*private void PanelMovement (MouseEventArgs e) {
			Dispatcher.BeginInvoke (new  (delegate () {
				base.OnMouseDown (e);

				if (e.Button == MouseButtons.Left) {
					ReleaseCapture ();
					SendMessage (Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
				} else if (e.Button == MouseButtons.Right) {
					var p = MousePosition.X + (MousePosition.Y * 0x10000);
					SendMessage (this.Handle, WM_POPUPSYSTEMMENU, (IntPtr)0, (IntPtr)p);
				}
			}));
		}*/
	}
}
