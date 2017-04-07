namespace SSLM
{
    using System.Windows;
    using System.Windows.Input;

	using Core;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

	public class WindowViewModel : ViewModelBase 
    {
		#region Variables

		private Window window;
		private int outerMarginSize = 10;
		private int windowRadius = 6;

		#endregion

		#region Commands

		public ICommand MinimizeCommand { get; set; }
		public ICommand MaximizeCommand { get; set; }
		public ICommand CloseCommand { get; set; }
		public ICommand MenuCommand { get; set; }

		#endregion

		#region Properties

		public string Title { get; private set; }

		public int BorderThickness { get; set; } = 6;
		public int TitleHeight { get; set; } = 42;
		public double MinWindowWidth { get; set; } = 800;
		public double MinWindowHeight { get; set; } = 600;

		public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + BorderThickness); } }
		public Thickness ResizeBorderThickness { get { return new Thickness(BorderThickness + OuterMarginSize); } }
		public Thickness InnerContentPadding { get { return new Thickness(BorderThickness, 0, BorderThickness, BorderThickness); } }
		public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
		public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

		public int OuterMarginSize {
			get {
				return this.window.WindowState == WindowState.Maximized ? 0 : this.outerMarginSize;
			}

			set {
				this.outerMarginSize = value;
			}
		}

		public int WindowRadius {
			get {
				return this.window.WindowState == WindowState.Maximized ? 0 : this.windowRadius;
			}

			set {
				this.windowRadius = value;
			}
		}

		#endregion

		public WindowViewModel(Window window) 
        {
			this.window = window;
			Title = Constants.MainTitle;

			this.window.StateChanged += (sender, e) => 
            {
				RaisePropertyChanged(nameof(ResizeBorderThickness));
				RaisePropertyChanged(nameof(OuterMarginSizeThickness));
				RaisePropertyChanged(nameof(WindowCornerRadius));
				RaisePropertyChanged(nameof(OuterMarginSize));
				RaisePropertyChanged(nameof(WindowRadius));
			};

			MinimizeCommand = new RelayCommand(() => this.window.WindowState = WindowState.Minimized);
			MaximizeCommand = new RelayCommand(() => this.window.WindowState ^= WindowState.Maximized);
			CloseCommand = new RelayCommand(() => this.window.Close());
			MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(this.window, GetMousePosition()));

			var resizer = new WindowResizer(this.window);
		}

		#region Helpers

		private Point GetMousePosition()
		{
			var position = Mouse.GetPosition(this.window);
			return new Point(position.X + this.window.Left, position.Y + this.window.Top);
		}

		#endregion
	}
}
