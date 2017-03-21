using System;
using System.Windows.Threading;
using System.Windows.Input;
using System.Runtime.InteropServices;
using HNTR.Models;

namespace HNTR.ViewModels {
	public class FilePanelViewModel {
		[DllImportAttribute ("user32.dll")]
		static extern int SendMessage (IntPtr hWnd,
						 int Msg, int wParam, int lParam);
		[DllImportAttribute ("user32.dll")]
		static extern bool ReleaseCapture ();

		[DllImport ("user32.dll")]
		static extern IntPtr SendMessage (IntPtr hWnd, int msg,
			IntPtr wParam, IntPtr lParam);
		const int WM_POPUPSYSTEMMENU = 0x313;

		public DocumentModel Document { get; private set; }
		public ICommand DragTopPanel { get; }

		public FilePanelViewModel (DocumentModel document) {
			Document = document;
		}

		private void PanelMovement (MouseEventArgs e) {
			/*Dispatcher.BeginInvoke (new  (delegate () {
				base.OnMouseDown (e);

				if (e.Button == MouseButtons.Left) {
					ReleaseCapture ();
					SendMessage (Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
				} else if (e.Button == MouseButtons.Right) {
					var p = MousePosition.X + (MousePosition.Y * 0x10000);
					SendMessage (this.Handle, WM_POPUPSYSTEMMENU, (IntPtr)0, (IntPtr)p);
				}
			}));*/
		}
	}
}
