using EmployeeManagment.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
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
    public partial class EmployeeListPage : INotifyPropertyChanged
    {

        private string _filePath = $"../employee.txt";
        private ObservableCollection<Employee> _employeeData;

        public ObservableCollection<Employee> EmployeeData
        {
            get
            {
                if (_employeeData == null)
                {
                    _employeeData = new ObservableCollection<Employee>();
                }
                return _employeeData;
            }
            set
            {
                EmployeeData = value;
                OnPropertyChanged(nameof(EmployeeData));
            }
        }

        public static EmployeeListPage Instance { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EmployeeListPage()
        {
            InitializeComponent();

            Instance = this;

            string json = File.ReadAllText(_filePath);

            if (!string.IsNullOrEmpty(json))
            {
                JsonArray jsonArray = JsonArray.Parse(json) as JsonArray;
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    EmployeeData.Add(JsonSerializer.Deserialize<Employee>(jsonArray[i]));
                }
            }

            EmployeeList.SetBinding(DataGrid.ItemsSourceProperty, new Binding()
            {
                Source = EmployeeData
            });
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedIndex == -1)
            {
                NavigationService.Navigate(PageController.EmployeeEditPage);
            }
            else
            {
                string name = EmployeeData[EmployeeList.SelectedIndex].Name;
                string position = EmployeeData[EmployeeList.SelectedIndex].Position;
                PageController.EmployeeEditPage.EditEmployee(name, position, EmployeeList.SelectedIndex);
                NavigationService.Navigate(PageController.EmployeeEditPage);
            }
        }

        public void SaveListToJson()
        {
            if (EmployeeData.Count > 0)
            {
                string json = JsonSerializer.Serialize(EmployeeData);

                File.WriteAllText(_filePath, json);
            }
        }
    }
}
