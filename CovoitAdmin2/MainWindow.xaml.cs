using CovoitAdmin2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CovoitAdmin2
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ShowUsers_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new UsersViewModel();
		}
		private void ShowStats_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new StatsViewModel();
		}
		private void ShowGlobalParams_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new GlobalParamsViewModel();
		}
	}
}
