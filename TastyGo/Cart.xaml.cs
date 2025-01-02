using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace TastyGo
{
    public partial class Cart : UserControl
    {
        public Cart()
        {
            InitializeComponent();
        }

        
        private void LoadCartData(string foodName)
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;";
            string query = "SELECT FoodName, FoodPrice FROM Restaurants WHERE FoodName = @FoodName";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FoodName", foodName);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            FoodNameTextBlock.Text = reader["FoodName"].ToString();
                            PriceTextBlock.Text = $"{reader["FoodPrice"]} ₺"; 
                        }
                        else
                        {
                            MessageBox.Show($"No data found for '{foodName}'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Hamburger");
        }

        
        private void PizzaButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Pizza");
        }

        private void CigKofte_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Çiğ Köfte");
        }
        private void LahmacunButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Lahmacun");
        }

        private void MantıButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Mantı");
        }

        private void iskenderButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("İskender");
        }

        private void HatayTavukButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Hatay Usulü Tavuk Döner");
        }

        private void EtDonerkButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Et Döner");
        }

        private void KofteButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Köfte");
        }

        private void MakarnaButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCartData("Pasta");
        }



        
        private void BackButton(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new MainMenu());
            }
        }

        
        private void ConfirmButton(object sender, RoutedEventArgs e)
        {
            TotalPrice totalPrice = new TotalPrice();
            totalPrice.ShowDialog();
        }
    }
}
