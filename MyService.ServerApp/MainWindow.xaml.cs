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
using MyService.ServerApp.Model;

namespace MyService.ServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly IList<Promotion> Promotions = new List<Promotion>();

        private Promotion current;

        public MainWindow()
        {
            InitializeComponent();
            Promotions.Add(new Promotion() { Name = "przykładowy", MinimalCount = 7 , Id = new Guid()});
            this.grid.ItemsSource = Promotions;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new AddForm();
            var result = addForm.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var toAdd = addForm.Model;
                Promotions.Add(toAdd);
                this.grid.ItemsSource = Promotions;
                this.grid.Items.Refresh();
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
