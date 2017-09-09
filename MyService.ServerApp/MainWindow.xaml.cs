using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MyService.Application.Respositories;

namespace MyService.ServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IPromotionRepository promotionRepository = new PromotionRepository(); 

        public MainWindow()
        {
            InitializeComponent();
            this.RefreshGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new AddForm();
            var result = addForm.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var toAdd = addForm.Model;
                this.promotionRepository.Add(toAdd);
                this.RefreshGrid();
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            var id = ((Button) sender).CommandParameter as string;
            this.promotionRepository.Delete(id);
            this.RefreshGrid();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            var promotions = this.promotionRepository.GetAll();
            this.grid.ItemsSource = promotions;
            this.grid.Items.Refresh();
        }
    }
}
