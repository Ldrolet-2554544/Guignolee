using Guignolee.Models;
using Guignolee.ViewModels;
using Guignolee.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Guignolee.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierDonPage : Page
    {
        public ModifierDonViewModel ViewModel { get; private set; }

        public ModifierDonPage()
        {
            InitializeComponent();

            ViewModel = new ModifierDonViewModel(
                new DonViewModel(new Don())
            );
        }

        /// <summary>
        /// À la navigation vers cette page, on récupère le don à modifier passé en 
        /// paramètre pour le mettre dans la propriété DonEdit du ViewModel.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is DonViewModel donViewModel)
            {
                DonViewModel copie = new DonViewModel(new Don
                {
                    Id = donViewModel.Id,
                    Donateur = donViewModel.Donateur,
                    Contenu = donViewModel.Contenu,
                    Quantite = donViewModel.Quantite,
                    EstPerissable = donViewModel.EstPerissable,
                    EstRemis = donViewModel.EstRemis
                });

                ViewModel.DonEdit = copie;
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            // On navigue vers le registre et on passe le don modifié en paramètre
            if (ViewModel.DonEdit.EstValide)
            {
                Frame.Navigate(typeof(RegistrePage), ViewModel.DonEdit);

            }
        }
    }
}