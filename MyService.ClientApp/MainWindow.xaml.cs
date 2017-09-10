using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MyService.Application.Model;

namespace MyService.ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string keyName = "Software\\MyService";
        public static User CurrentUser;

        public MainWindow()
        {
            InitializeComponent();
            var t1 = Task.Run(() => this.ReadEmail());
            
            Task.WaitAll(t1);
            this.RefreshGrid();
        }

        private async Task ReadEmail()
        {
            using (var registry = Registry.CurrentUser.OpenSubKey(keyName, true) 
                ?? Registry.CurrentUser.CreateSubKey(keyName))
            {
                var email = registry.GetValue("Email") as string;
                // TODO: popup z logowaniem (tylko email)
                if (email == null)
                {
                    email = "damsaneta@gmail.com";
                }

                registry.SetValue("Email", email, RegistryValueKind.String);
                CurrentUser = await DataHelper.RegisterUser(email);
            }
        }

        private async Task RefreshGrid()
        {
            var promotions = await DataHelper.GetPromotions();
            this.grid.ItemsSource = promotions;
            this.grid.Items.Refresh();
        }

        private async void Order(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).CommandParameter as string;
            await DataHelper.MakeOrder(CurrentUser.Id, id);
            await this.RefreshGrid();
        }
    }
}
