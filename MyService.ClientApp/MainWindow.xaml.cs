using System.Threading.Tasks;
using System.Windows;
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
            var t = Task.Run(() => this.ReadEmail());
            Task.WaitAll(t);
        }

        private async Task ReadEmail()
        {
            using (var registry = Registry.CurrentUser.OpenSubKey(keyName, true) 
                ?? Registry.CurrentUser.CreateSubKey(keyName))
            {
                var email = registry.GetValue("Email") as string;
                if (email == null)
                {
                    email = "damsaneta@gmail.com";
                }

                registry.SetValue("Email", email, RegistryValueKind.String);
                CurrentUser = await DataHelper.RegisterUser(email);
            }
        }
    }
}
