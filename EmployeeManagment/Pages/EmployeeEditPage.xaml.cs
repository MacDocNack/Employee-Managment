using EmployeeManagment.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace EmployeeManagment.Pages
{
    public partial class EmployeeEditPage : Page
    {
        private string _filePath = $"../employee.txt";
        private int _elementNumber = -1;
        public EmployeeEditPage()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string name = EmployeeName.Text.Trim();
            string position = EmployeePosition.Text.Trim();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(position))
            {
                if (_elementNumber == -1)
                {
                    Employee newEmployee = new Employee() { Name = name, Position = position };
                    EmployeeListPage.Instance.EmployeeData.Add(newEmployee);
                    EmployeeName.Clear();
                    EmployeePosition.Clear();
                    EmployeeListPage.Instance.SaveListToJson();
                    NavigationService.Navigate(PageController.EmployeeListPage);
                }
                else
                {
                    EmployeeListPage.Instance.EmployeeData[_elementNumber] = new Employee() { Name = name, Position = position };
                    EmployeeName.Clear();
                    EmployeePosition.Clear();
                    EmployeeListPage.Instance.SaveListToJson();
                    _elementNumber = -1;
                    NavigationService.Navigate(PageController.EmployeeListPage);
                }
            }
        }

        public void EditEmployee(string name, string position, int element)
        {
            EmployeeName.Text = name;
            EmployeePosition.Text = position;
            _elementNumber = element;
        }
    }
}
