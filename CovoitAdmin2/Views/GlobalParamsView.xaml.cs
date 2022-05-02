using CovoitAdmin2.Model;
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

namespace CovoitAdmin2.Views
{
	/// <summary>
	/// Logique d'interaction pour GlobalParamsView.xaml
	/// </summary>
	public partial class GlobalParamsView : UserControl
	{
		covoitContext context = new covoitContext();

		public GlobalParamsView()
		{
			InitializeComponent();
			try
			{
				DataGrid.ItemsSource = context.Motorizations.OrderBy(user => user.IdMotorization).ToList();
			}
			catch
			{
				ErrorBox.Text = "Le chargement a echoué verifier votre connection internet.";
				ErrorBox.Background = Brushes.Tomato;
			}
			
		}

		private void ButtonModificationMotorization_Click(object sender, RoutedEventArgs e)
		{
			var IdMotorization = int.Parse(((Button)sender).Tag.ToString());
			//UsersView utilisateurInformation = new UsersView();
			MotorizationInformationWindow page = new MotorizationInformationWindow(IdMotorization);
			page.Show();
		}

		private void ButtonDeleteMotorization_Click(object sender, RoutedEventArgs e)
		{
			var IdMotorization = int.Parse(((Button)sender).Tag.ToString());

			var result = MessageBox.Show("Etes vous sur de vouloir supprimer la motorization N°" + IdMotorization + " cela peut avoir de lourde repercution sur la base de donnée", "Confirmer la suppresion", MessageBoxButton.YesNo);


			if (result.ToString() == "Yes")
			{
				Motorization motorizationSelect = context.Motorizations.Find(IdMotorization);
				context.Remove(motorizationSelect);
				context.SaveChanges();
			}
		}

		private void ShowAddMotorizationWindows_Click(object sender, RoutedEventArgs e)
		{
			AddMotorizationWindow addMotorizationWindow = new AddMotorizationWindow();
			addMotorizationWindow.Show();
		}
	}
}
