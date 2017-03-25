using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HNTR.Views
{
    /// <summary>
    /// Interaction logic for ucTopPanelMenu.xaml
    /// </summary>
    public partial class FilePanelView : UserControl
    {
        public FilePanelView()
        {
            InitializeComponent();
		}

		//private void Grid_MouseEnter(object sender, MouseEventArgs e)
		//{
		//	ColorAnimation ca = new ColorAnimation(Colors.Blue, new Duration(TimeSpan.FromSeconds(4)));
		//	grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF141417"));
		//	grid1.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
		//	MessageBox.Show("Temp"); //FF141417
		//}

		//private void exitButton_MouseEnter(object sender, MouseEventArgs e)
		//{
		//	ColorAnimation ca = new ColorAnimation(Colors.DarkRed, new Duration(TimeSpan.FromMilliseconds(250)));
		//	exitButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
		//	exitButton.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
		//}

		//private void exitButton_MouseLeave(object sender, MouseEventArgs e)
		//{
		//	ColorAnimation ca = new ColorAnimation((Color)ColorConverter.ConvertFromString("#00000000"), 
		//										          new Duration(TimeSpan.FromMilliseconds(250)));
		//	exitButton.Background = new SolidColorBrush(Colors.DarkRed);
		//	exitButton.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
		//}


		//private void exitButton_MouseDown(object sender, MouseButtonEventArgs e)
		//{
		//	ColorAnimation ca = new ColorAnimation((Color)ColorConverter.ConvertFromString("#FFE53E3E"), 
		//												  new Duration(TimeSpan.FromMilliseconds(100)));
		//	exitButton.Background = new SolidColorBrush(Colors.DarkRed);
		//	exitButton.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
		//}
	}
}
