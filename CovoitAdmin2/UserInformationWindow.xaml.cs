using CovoitAdmin2.Model;
using CovoitAdmin2.Views;
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
using System.Windows.Shapes;

namespace CovoitAdmin2
{
	/// <summary>
	/// Logique d'interaction pour UserInformationWindow.xaml
	/// </summary>
	public partial class UserInformationWindow : Window
	{
		covoitContext context = new covoitContext();
		int idUserGlobal = 0;
		public UserInformationWindow(int idUser)
		{
			InitializeComponent();
			try
			{
				idUserGlobal = idUser;
				try
				{
					User userSelect = context.Users.Find(idUser);

					VehicleGrid.ItemsSource = context.Vehicles.Where(x => x.IdUser == idUser).ToList();
					FName.Text = userSelect.FName;
					LName.Text = userSelect.LName;
					Tel.Text = userSelect.Tel.ToString();
					Admin.IsChecked = userSelect.Administrator;
					Password.Password = "********";
				}
				catch
				{
					ErrorBox.Text = "Le chargement a echoué verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
			catch
			{
				ErrorBox.Text = "Une erreur inconnu est survenue, ferme cette page et reesayer.";
				ErrorBox.Background = Brushes.Tomato;
			}
			
		}
		private void ButtonModificationInformationFName_Click(object sender, RoutedEventArgs e)
		{
			if (FName.IsEnabled == false)
			{
				FName.IsEnabled = true;
				ButtonModificationInformationFName.Content = "Sauvegarder";
			}
			else if(FName.IsEnabled == true)
			{
				ButtonModificationInformationFName.Content = "Modifier";
				FName.IsEnabled = false;
				try
				{
					var user = context.Users.Find(idUserGlobal);
					user.FName = FName.Text;
					user.DateModification = DateTime.Now;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}

		}

		private void ButtonModificationInformationLName_Click(object sender, RoutedEventArgs e)
		{
			if (LName.IsEnabled == false)
			{
				LName.IsEnabled = true;
				ButtonModificationInformationLName.Content = "Sauvegarder";
			}
			else if (LName.IsEnabled == true)
			{
				ButtonModificationInformationLName.Content = "Modifier";
				LName.IsEnabled = false;
				try
				{
					var user = context.Users.Find(idUserGlobal);
					user.LName = LName.Text;
					user.DateModification = DateTime.Now;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}

		private void ButtonModificationInformationTel_Click(object sender, RoutedEventArgs e)
		{
			if (Tel.IsEnabled == false)
			{
				Tel.IsEnabled = true;
				ButtonModificationInformationTel.Content = "Sauvegarder";
			}
			else if (Tel.IsEnabled == true)
			{
				ButtonModificationInformationTel.Content = "Modifier";
				Tel.IsEnabled = false;
				try
				{
					var user = context.Users.Find(idUserGlobal);
					user.Tel = int.Parse(Tel.Text);
					user.DateModification = DateTime.Now;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}
		private void ButtonModificationInformationAdmin_Click(object sender, RoutedEventArgs e)
		{
			if (Admin.IsEnabled == false)
			{
				Admin.IsEnabled = true;
				ButtonModificationInformationAdmin.Content = "Sauvegarder";
			}
			else if (Admin.IsEnabled == true)
			{
				ButtonModificationInformationAdmin.Content = "Modifier";
				Admin.IsEnabled = false;
				try
				{
					var user = context.Users.Find(idUserGlobal);
					if (Admin.IsChecked == true)
					{
						user.Administrator = true;
					}
					else
					{
						user.Administrator = false;
					}
					user.DateModification = DateTime.Now;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}

		private void ButtonResetPassword_Click(object sender, RoutedEventArgs e)
		{
			if (Password.IsEnabled == false)
			{
				Password.Password = "";
				Password.IsEnabled = true;
				ButtonResetPassword.Content = "Sauvegarder";
			}
			else if (Password.IsEnabled == true)
			{
				Password.IsEnabled = false;
				ButtonResetPassword.Content = "Modifier";
				try
				{
					var user = context.Users.Find(idUserGlobal);
					user.Password = CovoitAdmin.Outils.getHashSha256(Password.Password);
					user.DateModification = DateTime.Now;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}
		private void ButtonModificationVehicle_Click(object sender, RoutedEventArgs e)
		{
			var idVehicle = int.Parse(((Button)sender).Tag.ToString());
			//UsersView utilisateurInformation = new UsersView();
			UserVehicleEditWindows page = new UserVehicleEditWindows(idVehicle);
			page.Show();
		}
		private void ButtonDeleteVehicle_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
