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
	/// Logique d'interaction pour UserVehicleEditWindows.xaml
	/// </summary>
	public partial class UserVehicleEditWindows : Window
	{
		int idVehicleGlobal = 0;
		covoitContext context = new covoitContext();
		public UserVehicleEditWindows(int IdVehicle)
		{
			InitializeComponent();
			try
			{
				idVehicleGlobal = IdVehicle;
				try
				{
					Vehicle vehicleSelect = context.Vehicles.Find(idVehicleGlobal);
					VehicleColor.Text = vehicleSelect.Color;
					VehicleName.Text = vehicleSelect.VehicleName;
					IdMotorisation.Text = vehicleSelect.IdMotorization.ToString();
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

		private void ButtonModificationInformationVehicleColor_Click(object sender, RoutedEventArgs e)
		{
			if (VehicleColor.IsEnabled == false)
			{
				VehicleColor.IsEnabled = true;
				ButtonModificationInformationVehicleColor.Content = "Sauvegarder";
			}
			else if (VehicleColor.IsEnabled == true)
			{
				ButtonModificationInformationVehicleColor.Content = "Modifier";
				VehicleColor.IsEnabled = false;
				try
				{
					var vehicle = context.Vehicles.Find(idVehicleGlobal);
					vehicle.Color = VehicleColor.Text;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}

		private void ButtonModificationInformationVehicleName_Click(object sender, RoutedEventArgs e)
		{
			if (VehicleName.IsEnabled == false)
			{
				VehicleName.IsEnabled = true;
				ButtonModificationInformationVehicleName.Content = "Sauvegarder";
			}
			else if (VehicleName.IsEnabled == true)
			{
				ButtonModificationInformationVehicleName.Content = "Modifier";
				VehicleName.IsEnabled = false;
				try
				{
					var vehicle = context.Vehicles.Find(idVehicleGlobal);
					vehicle.VehicleName = VehicleName.Text;
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}

		private void ButtonModificationInformationIdMotorisation_Click(object sender, RoutedEventArgs e)
		{
			if (IdMotorisation.IsEnabled == false)
			{
				IdMotorisation.IsEnabled = true;
				ButtonModificationInformationIdMotorisation.Content = "Sauvegarder";
			}
			else if (IdMotorisation.IsEnabled == true)
			{
				ButtonModificationInformationIdMotorisation.Content = "Modifier";
				IdMotorisation.IsEnabled = false;
				try
				{
					var vehicle = context.Vehicles.Find(idVehicleGlobal);
					vehicle.IdMotorization = int.Parse(IdMotorisation.Text);
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}
	}
}
