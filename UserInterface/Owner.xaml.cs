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
using VetService.ClassLibary;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class Owner : Page
    {
        APIClient client;
        List<VetService.ClassLibary.Owner> owners;
        VetService.ClassLibary.Owner selectOwner;

        public Owner()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            client = new APIClient();
            
            owners = await client.GetOwners();

            OWNER_DG.ItemsSource = owners;

        }

        private void OWNER_DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OWNER_DG.SelectedItem != null)
            {
                selectOwner = (VetService.ClassLibary.Owner)OWNER_DG.SelectedItem;
                txtSurname.Text = selectOwner.Surname;
                txtGivenName.Text = selectOwner.GivenName;
                txtPhone.Text = selectOwner.Phone;
                Create_BTN.IsEnabled = false;
            }
        }

        private async void Create_BTN_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            VetService.ClassLibary.Owner newOwner = new VetService.ClassLibary.Owner()
            {
                OwnerID = await client.NextOwnerID(),
                Surname = txtSurname.Text,
                GivenName = txtGivenName.Text,
                Phone = txtPhone.Text
            };
            await client.CreateOwner(newOwner);

            owners = await client.GetOwners();

            OWNER_DG.ItemsSource = owners;

            //OWNER_DG.ItemsSource = newOwner.ToString();
        }

        private async void Delete_BTN_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();
            await client.DeleteOwner(selectOwner);

            owners = await client.GetOwners();

            OWNER_DG.ItemsSource = owners;
        }

        private async void Update_BTN_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            VetService.ClassLibary.Owner updateOwner = new VetService.ClassLibary.Owner()
            {
                OwnerID = selectOwner.OwnerID,
                Surname = txtSurname.Text,
                GivenName = txtGivenName.Text,
                Phone = txtPhone.Text
            };
            await client.UpdateOwner(updateOwner);

            owners = await client.GetOwners();

            OWNER_DG.ItemsSource = owners;

        }

        private void Back_BTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Procedures.xaml", UriKind.RelativeOrAbsolute));
        }

        
    }
}
