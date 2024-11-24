using EmployeeManagment.Classes;
using System.Windows;

namespace EmployeeManagment
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.Navigate(PageController.HomePage);
        }

        private void ToMain(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(PageController.HomePage);
        }

        private void ToEmployeeList(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(PageController.EmployeeListPage);
        }
    }
}
