using GreenThumb.Database;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetail.xaml
    /// </summary>
    public partial class PlantDetail : Window
    {
        public PlantDetail(PlantModel selectedPlant)
        {
            InitializeComponent();
            FillDetails(selectedPlant);

        }

        // Gör en metod för att fylla rutorna. 
        public async void FillDetails(PlantModel selectedPlant)
        {
            using (PlantDbContext context = new())
            {
                tbPlant.Text = selectedPlant.Name;

                PlantRepository<PlantModel> plantRepository = new(context);
                PlantRepository<InstructionModel> plantRepository1 = new(context);

                var allInstructions = await plantRepository1.GetAll();

                var selectedInstructions = allInstructions.Where(p => p.PlantId == selectedPlant.PlantId);

                foreach (var x in selectedInstructions)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = x;
                    item.Content = x.Instruction;
                    LstInstructions.Items.Add(item);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }
    }
}
