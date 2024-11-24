using EmployeeManagment.Pages;

namespace EmployeeManagment.Classes
{
    public class PageController
    {
        private static HomePage _homePage { get; set; }
        private static EmployeeListPage _employeeListPage { get; set; }
        private static EmployeeEditPage _employeeEditPage { get; set; }

        public static HomePage HomePage
        {
            get
            {
                if (_homePage == null)
                {
                    _homePage = new HomePage();
                }
                return _homePage;
            }
        }
        public static EmployeeListPage EmployeeListPage
        {
            get
            {
                if (_employeeListPage == null)
                {
                    _employeeListPage = new EmployeeListPage();
                }
                return _employeeListPage;
            }
        }
        public static EmployeeEditPage EmployeeEditPage
        {
            get
            {
                if (_employeeEditPage == null)
                {
                    _employeeEditPage = new EmployeeEditPage();
                }
                return _employeeEditPage;
            }
        }
    }
}
