using GreenThumb.Database;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        private List<PlantModel?> allPlants;
        public AddPlantWindow()
        {
            InitializeComponent();
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {

            AddPlantWindow addPlantWindow = new AddPlantWindow();

            addPlantWindow.Show();

            Close();
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            string instructions = txtInstructions.Text;

            //Lägg till flera instructions
            if (!string.IsNullOrWhiteSpace(instructions))
            {
                InstructionModel model = new()
                {
                    Instruction = instructions,

                };

                ListViewItem item = new();

                item.Tag = model;
                item.Content = instructions;

                lstInstructions.Items.Add(item);

                // Rensa UI:t
                txtInstructions.Text = "";
            }
        }

        private async void btnSavePlant_Click(object sender, RoutedEventArgs e)
        {

            string plant = txtPlant.Text;
            if (!string.IsNullOrWhiteSpace(plant))
            {

                using PlantDbContext context = new(); // Fyll listan över tillagda växter.
                {
                    PlantRepository<PlantModel> plantRepository = new(context);

                    var allPlants = await plantRepository.GetAll();

                    string flower = txtPlant.Text;

                    foreach (var plants in allPlants)
                    {
                        if (flower.ToLower() == plants.Name.ToLower())
                        {
                            MessageBox.Show("The plant already exists!");
                            return;
                        }
                    }

                    PlantModel plantmodel = new()
                    {
                        Name = flower,
                    };

                    foreach (ListViewItem item in lstInstructions.Items)
                    {
                        var instruction = (InstructionModel)item.Tag;

                        plantmodel.Instructions.Add(instruction);
                    }

                    context.Plants.Add(plantmodel);
                    context.SaveChanges();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();

                }
            }
            else
            {
                MessageBox.Show("Please write the name of your plant!");
            }

        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}

