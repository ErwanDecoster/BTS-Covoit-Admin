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
	/// Logique d'interaction pour StatsView.xaml
	/// </summary>
	public partial class StatsView : UserControl
	{
		public StatsView()
		{
			InitializeComponent();
			try
			{
				covoitContext context = new covoitContext();
				try
				{
					DateTime dateTime = DateTime.Now.AddDays(-30);
					int nbNewUsers = context.Users.Where(x => x.DateCreate > dateTime).Count();
					int nbUsers = context.Users.Count();
					int nbUsersCreate = context.Users.ToList().Last().IdUser;
					int nbTrips = context.Trips.Count();
					int nbPath = context.Paths.Count();
					int nbVehicle = context.Vehicles.Count();

					newUsersNumber.Text = nbNewUsers.ToString() + " Nouveaux utilisateurs crées";
					usersNumber.Text = nbUsers.ToString() + " Utilisateurs actuel";
					usersCreateNumber.Text = nbUsersCreate + " Utilisateurs crées";
					travelsNumber.Text = nbTrips.ToString() + " Voyage crées";
					pathNumber.Text = nbPath.ToString() + " Villes traversé";
					vehiclesNumber.Text = nbVehicle.ToString() + " Vehicules crées";
				}
				catch (Exception ex)
				{
					ErrorBox.Text = "Une erreur inconue c'est produite.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
			catch
			{
				ErrorBox.Text = "Le chargement a echoué verifier votre connection internet.";
				ErrorBox.Background = Brushes.Tomato;
			}
		}
	}
}
