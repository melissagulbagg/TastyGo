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
    public partial class UserInformation : UserControl
    {
        public UserInformation()
        {
            InitializeComponent();
            LoadUserInformation();
        }

        private void LoadUserInformation()
        {
            UserNameTextBlock.Text = MainWindow.LoggedInUserFullName;
            LoadAdditionalUserInfo();
        }

        private void LoadAdditionalUserInfo()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;";
            string query = "SELECT Phone, Address FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                string username = (MainWindow.LoggedInUserFirstName + MainWindow.LoggedInUserLastName).ToLower();
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        PhoneNumberTextBlock.Text = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "Not provided";
                        AddressTextBlock.Text = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "Not provided";
                    }
                    else
                    {
                        PhoneNumberTextBlock.Text = "Not provided";
                        AddressTextBlock.Text = "Not provided";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            var mainMenuControl = new MainMenu();
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(mainMenuControl);
            }
        }
    }
}
