using CovoitAdmin2;
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
	/// Logique d'interaction pour AddUserWindow.xaml
	/// </summary>
	public partial class AddUserWindow : Window
	{
		public AddUserWindow()
		{
			InitializeComponent();
		}

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
			int Tel = Int32.Parse(TelInput.Text);
			string FName = FNameInput.Text;
			string LName = LNameInput.Text;
			string Password = PasswordInput.Password;
			bool Admin = false;
			Admin = AdminInput.IsChecked ?? false;
			try
			{
				covoitContext context = new covoitContext();
				UsersView usersView = new UsersView();
				var dateNow = DateTime.Now;
				var PasswordHash = Outils.getHashSha256(Password);
				User newUser = new User { Tel = Tel, LName = LName, FName = FName, Password = PasswordHash, Administrator = Admin, DateCreate = dateNow, DateModification = dateNow };
				context.Add(newUser);
				//validation des changements
				context.SaveChanges();
				usersView.recieveData(FName);
				this.Close();
			}
			catch
			{
				ErrorBox.Text = "L'ajout a echoué, verifier votre connection internet.";
				ErrorBox.Background = Brushes.Tomato;
			}		
		}
	}
}
