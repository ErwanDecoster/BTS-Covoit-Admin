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
using System.Windows.Shapes;

namespace CovoitAdmin2
{
	/// <summary>
	/// Logique d'interaction pour AddMotorizationWindow.xaml
	/// </summary>
	public partial class AddMotorizationWindow : Window
	{
		public AddMotorizationWindow()
		{
			InitializeComponent();
		}
		private void AddMotorization_Click(object sender, RoutedEventArgs e)
		{
			string Libellet = LibelletInput.Text;
			try
			{
				covoitContext context = new covoitContext();
				/*UsersView usersView = new UsersView();*/
				Motorization newMotorization = new Motorization { Libellet = Libellet};
				context.Add(newMotorization);
				//validation des changements
				context.SaveChanges();
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
