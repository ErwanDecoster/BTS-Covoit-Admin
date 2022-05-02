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
	/// Logique d'interaction pour UsersView.xaml
	/// </summary>
	public partial class UsersView : UserControl
	{
		covoitContext context = new covoitContext();
		public UsersView()
		{
			InitializeComponent();
			try
			{
				UsersGrid.ItemsSource = context.Users.OrderBy(user => user.IdUser).ToList();
			}
			catch {
				ErrorBox.Text = "Le chargement a echoué verifier votre connection internet.";
				ErrorBox.Background = Brushes.Tomato;
			}
		}

		public void updateDataGrid()
		{
			UsersGrid.ItemsSource = null;
			UsersGrid.ItemsSource = context.Users.OrderBy(user => user.IdUser).ToList();
			UsersGrid.Items.Refresh();
		}

		internal void recieveData(string newName)
		{
			updateDataGrid();
			//MessageBox.Show("Prenom : " + newName);
		}

		private void ModificationInformationPersonnelles(object sender, RoutedEventArgs e)
		{
			
		}

		private void ButtonModificationInformationPersonnelles_Click(object sender, RoutedEventArgs e)
		{
			var idUser = int.Parse(((Button)sender).Tag.ToString());
			//UsersView utilisateurInformation = new UsersView();
			UserInformationWindow page = new UserInformationWindow(idUser);
			page.Show();
		}

		private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
		{
			var idUser = ((Button)sender).Tag;

			var result = MessageBox.Show("Etes vous sur de vouloir supprimer l'utilisateur N°" + idUser, "Confirmer la suppresion", MessageBoxButton.YesNo);


			if (result.ToString() == "Yes")
			{
				User userSelect = context.Users.Find(idUser);
				context.Remove(userSelect);
				context.SaveChanges();
				updateDataGrid();
			}
		}

		private void ShowAddUserWindows_Click(object sender, RoutedEventArgs e)
		{
			AddUserWindow addUserWindow = new AddUserWindow();
			addUserWindow.Show();
		}
	}
}
