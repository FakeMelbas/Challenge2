using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for Procedures.xaml
    /// </summary>
    public partial class Procedures : Page
    {
        APIClient client;
        //List<Owner> owners;
        List<Pet> pets;
        List<Procedure> procedures;
        List<Treatment> treatmentViews;
        Procedure selectedProcedure;
        List<Treatment> treatments;

        public Procedures()
        {
            InitializeComponent();
            DataContext = this;
        }
        private async void Open_Page(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            procedures = await client.GetProcedures();
            treatments = await client.GetTreatments();

            PROC_DG.ItemsSource = procedures;
        }
        private void PROC_DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Procedure selectedProcedure = (Procedure)PROC_DG.SelectedItem;

            int procID = selectedProcedure.ProcedureID;

            insertTreatments(procID);
            /*if (PROC_DG.SelectedItem != null)
            {
                selectedProcedure = (Procedure)PROC_DG.SelectedItem;
            }
            var TreatmentList = from p in procedures
                                join t in treatments on p.ProcedureID equals t.ProcedureID
                                where t.procedureID == selectedProcedure.ProcedureID
                                select new
                                {
                                    p.Name,
                                    p.Type,
                                    t.Date,
                                    t.Notes,
                                    t.Price

                                };

            TREAT_DG.ItemsSource = treatmentViews;*/









        }
        public async Task insertTreatments(int procID)
        {
            treatmentViews = new List<Treatment>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/treatmentviews");

            string treatment = "";

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                treatment = await response.Content.ReadAsStringAsync();
            }

            treatments = JsonConvert.DeserializeObject<List<Treatment>>(treatment);

            var filtered = treatments.Where(tr => tr.ProcedureID == procID);
            foreach (var item in filtered)
            {
               treatmentViews.Add(item);
            }

            TREAT_DG.ItemsSource = treatmentViews;
        }

        private void Owner_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Owner.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
