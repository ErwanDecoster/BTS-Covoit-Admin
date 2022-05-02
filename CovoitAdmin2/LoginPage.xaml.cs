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

namespace CovoitAdmin2
{
	/// <summary>
	/// Logique d'interaction pour LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Window
	{
		public LoginPage()
		{
			InitializeComponent();
		}
		covoitContext context = new covoitContext();


		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			ErrorBox.Text = "";
			try
			{
				List<User> users = context.Users.ToList();
				try
				{
					var tel = Int32.Parse(telInput.Text);
					var password = CovoitAdmin.Outils.getHashSha256(passwordInput.Password);
					foreach (User user in users)
					{
						if (tel == user.Tel && password == user.Password)
						{
							if (user.Administrator == true)
							{
								MainWindow page = new MainWindow();
								page.Show();
								this.Close();
								ErrorBox.Text = "Connexion reussit";
							} else { ErrorBox.Text = "Votre compte n'as pas les droit administrateur"; ErrorBox.Background = Brushes.Tomato; }
						} else { ErrorBox.Text = "Le numero et le mot de passe ne corepondent a aucun compte"; ErrorBox.Background = Brushes.Tomato; }
					}
				} catch (Exception ex) { ErrorBox.Text = "Format des données incorecte"; ErrorBox.Background = Brushes.Tomato; }
			} catch (Exception ex) { ErrorBox.Text = "Erreur de connection a la base de donnée"; ErrorBox.Background = Brushes.Tomato; }
		}
	}
}
