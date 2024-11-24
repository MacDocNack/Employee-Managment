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

namespace EmployeeManagment.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            Welcome.Text = $"Добро пожаловать! \n Справка по приложению: \n На главную - Возвращает на главную страницу с приветствием \n" +
                $"Сотрудники - Открывает страницу со списком сотрудников. На странице сотрудников можно редактировать список сотрудников";
        }
    }
}
