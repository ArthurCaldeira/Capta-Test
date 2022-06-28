using Capta_Test.Customer.UI.Model;
using Capta_Test.Customer.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Capta_Test.Customer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<CustomerStatusModel> statusList;
        private IEnumerable<CustomerTypeModel> typeList;
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAll();
        }

        private async void LoadAll()
        {
            ClearForm();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5071");

            var customerService = new CustomerService(client);
            var customerList = await customerService.FindAll();
            Customers.ItemsSource = customerList;

            var customerStatusService = new CustomerStatusService(client);
            statusList = await customerStatusService.Get();
            customerStatus.ItemsSource = statusList.Select(x => x.Status);

            var customerTypeService = new CustomerTypeService(client);
            typeList = await customerTypeService.Get();
            customerType.ItemsSource = typeList.Select(x => x.Type);

            List<string> genders = new List<string>();
            genders.Add("Masculino");
            genders.Add("Feminino");
            gender.ItemsSource = genders;
        }

        private void Customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;

            var selectedCustomer = (CustomerModel)e.AddedItems[0];

            id.Text = selectedCustomer.Id.ToString();
            name.Text = selectedCustomer.CustomerName;
            cpf.Text = selectedCustomer.Cpf;
            gender.Text = selectedCustomer.Gender.Equals("M") ? "Masculino" : "Feminino";
            customerStatus.Text = statusList.Where(x => x.Id == selectedCustomer.CustomerStatusId).Select(x => x.Status).FirstOrDefault();
            customerType.Text = typeList.Where(x => x.Id == selectedCustomer.CustomerTypeId).Select(x =>x.Type).FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            id.Text = name.Text = cpf.Text = gender.Text = customerStatus.Text = customerType.Text = string.Empty;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var customerData = new CustomerModel()
            {
                Id = string.IsNullOrEmpty(id.Text) ? 0 : Convert.ToInt32(id.Text),
                CustomerName = name.Text,
                Cpf = cpf.Text,
                Gender = gender.Text.Equals("Masculino", StringComparison.InvariantCultureIgnoreCase) ? "M" : "F",
                CustomerStatusId = statusList.Where(x => x.Status.Equals(customerStatus.Text, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.Id).FirstOrDefault(),
                CustomerTypeId = typeList.Where(x => x.Type.Equals(customerType.Text, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.Id).FirstOrDefault()
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5071");
            var customerService = new CustomerService(client);

            if (string.IsNullOrEmpty(id.Text))
                await customerService.Create(customerData);
            else
                await customerService.Update(customerData);

            LoadAll();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(id.Text))
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5071");
                var customerService = new CustomerService(client);

                var result = await customerService.Delete(Convert.ToInt32(id.Text));

                LoadAll();
            }
        }
    }
}
