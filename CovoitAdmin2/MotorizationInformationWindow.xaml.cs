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
	/// Logique d'interaction pour MotorizationInformationWindow.xaml
	/// </summary>
	public partial class MotorizationInformationWindow : Window
	{
		int idMotorizationGlobal = 0;
		covoitContext context = new covoitContext();
		public MotorizationInformationWindow(int IdMotorization)
		{
			InitializeComponent();
			try
			{
				idMotorizationGlobal = IdMotorization;
				try
				{
					Motorization motorizationSelect = context.Motorizations.Find(idMotorizationGlobal);
					IdMotorisation.Text = motorizationSelect.IdMotorization.ToString();
					Libellet.Text = motorizationSelect.Libellet.ToString();
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
					var motorization = context.Motorizations.Find(idMotorizationGlobal);
					motorization.IdMotorization = int.Parse(IdMotorisation.Text);
					context.SaveChanges();
				}
				catch
				{
					ErrorBox.Text = "La modification na pas pu etre effectué, verifier votre connection internet.";
					ErrorBox.Background = Brushes.Tomato;
				}
			}
		}
		private void ButtonModificationInformationLibellet_Click(object sender, RoutedEventArgs e)
		{
			if (Libellet.IsEnabled == false)
			{
				Libellet.IsEnabled = true;
				ButtonModificationInformationLibellet.Content = "Sauvegarder";
			}
			else if (Libellet.IsEnabled == true)
			{
				ButtonModificationInformationLibellet.Content = "Modifier";
				Libellet.IsEnabled = false;
				ButtonModificationInformationIdMotorisation.Content = "Modifier";
				IdMotorisation.IsEnabled = false;
				try
				{
					var motorization = context.Motorizations.Find(idMotorizationGlobal);
					motorization.Libellet = Libellet.Text;
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
