using GreenThumb.Database;
using GreenThumb.Models;
using GreenThumb.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<PlantModel> allPlants;
        private List<PlantModel> filteredPlants;
        public MainWindow()
        {
            InitializeComponent();
            ListPlantsAsync();
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addplantwindow = new AddPlantWindow();
            addplantwindow.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteFromList();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lstAddPlants.Items.Clear();
            ListPlantsAsync();
        }

        async void ListPlantsAsync()
        {

            using PlantDbContext context = new(); // Fyll listan över tillagda växter.
            {

                PlantRepository<PlantModel> plantRepository = new(context);

                var allPlants = await plantRepository.GetAll();
                var filteredPlants = allPlants;

                foreach (var plantItem in filteredPlants)

                {
                    ListViewItem item = new();
                    item.Tag = plantItem;
                    item.Content = plantItem.Name;

                    lstAddPlants.Items.Add(item);
                }
            }
        }

        async void DeleteFromList()
        {
            if (lstAddPlants.SelectedItem != null)
            { // Hitta listViewITem:et som är selectat
              //Titta i Tag för att hitta planten
              // Använd Id på den planten för att skicka till Delete-metoden
                ListViewItem selectedItem = (ListViewItem)lstAddPlants.SelectedItem;

                PlantModel plantToRemove = (PlantModel)selectedItem.Tag;

                lstAddPlants.Items.Remove(lstAddPlants.SelectedItem);

                using PlantDbContext context = new();
                {
                    PlantRepository<PlantModel> plantRepository = new(context);
                    await plantRepository.Delete(plantToRemove);

                }

                MessageBox.Show("Your plant has been removed.");
            }
            else
            {
                MessageBox.Show("Please select an item");
            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            using (PlantDbContext context = new())
            {
                PlantRepository<PlantModel> plantRepository = new(context);

                var allPlants = await plantRepository.GetAll();
                string searchPlant = txtSearch.Text.ToLower();

                //var filtererdPlants = allPlants;
                var filteredPlants = allPlants.Where(p => p.Name.ToLower().Contains(searchPlant));
                lstAddPlants.Items.Clear();

                foreach (var plant in filteredPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    lstAddPlants.Items.Add(item);
                }

                txtSearch.Clear();

            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstAddPlants.SelectedItem;

            if (selectedItem != null)
            {
                PlantModel selectedPlant = (PlantModel)selectedItem.Tag;

                PlantDetail plantDetail = new PlantDetail(selectedPlant);
                plantDetail.Show();
                Close();
            }
        }
    }
}