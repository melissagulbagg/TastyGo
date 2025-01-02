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
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            LoadUserInformation();
            UpdateHamburgerName();  
            UpdatePizzaName();      
            UpdateCigKofteName();
            UpdateLahmacunName();
            UpdateMantıName();
            UpdateiskenderName();
            UpdateHatayTavukName();
            UpdateEtDonerName();
            UpdateKofteName();
            UpdateMakarnaName();
        }

        private void LoadUserInformation()
        {
            UserNameTextBlock.Text = MainWindow.LoggedInUserFullName;
        }

        private void UpdateHamburgerName()
        {
            string HamburgerName = GetHamburgerNameFromDatabase();
            HamburgerTextBlock.Text = HamburgerName;
        }

        private void UpdatePizzaName()
        {
            string PizzaName = GetPizzaNameFromDatabase();
            PizzaTextBlock.Text = PizzaName; 
        }

        private void UpdateCigKofteName()
        {
            string CigKofteName = GetCigKofteNameFromDatabase();
            CigKofteTextBlock.Text = CigKofteName; 
        }

        private void UpdateLahmacunName()
        {
            string LahmacunName = GetLahmacunNameFromDatabase();
            LahmacunTextBlock.Text = LahmacunName; 
        }

        private void UpdateMantıName()
        {
            string MantıName = GetMantıNameFromDatabase();
            MantıTextBlock.Text = MantıName; 
        }

        private void UpdateiskenderName()
        {
            string iskenderName = GetiskenderNameFromDatabase();
            iskenderTextBlock.Text = iskenderName; 
        }

        private void UpdateHatayTavukName()
        {
            string HatayTavukName = GetHatayTavukNameFromDatabase();
            HatayTavukTextBlock.Text = HatayTavukName; 
        }
        
        private void UpdateEtDonerName()
        {
            string EtDonerName = GetEtDonerNameFromDatabase();
            EtDonerTextBlock.Text = EtDonerName; 
        }

        private void UpdateKofteName()
        {
            string KofteName = GetKofteNameFromDatabase();
            KofteTextBlock.Text = KofteName; 
        }

        private void UpdateMakarnaName()
        {
            string MakarnaName = GetMakarnaNameFromDatabase();
            MakarnaTextBlock.Text = MakarnaName; 
        }





        private string GetHamburgerNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string hamburgerName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 1 ROW FETCH NEXT 1 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        hamburgerName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return hamburgerName;
        }

        private string GetPizzaNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string pizzaName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 7 ROW FETCH NEXT 7 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        pizzaName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return pizzaName;
        }

        private string GetCigKofteNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string CigKofteName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 0 ROW FETCH NEXT 1 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        CigKofteName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return CigKofteName;
        }

        private string GetLahmacunNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string LahmacunName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 6 ROW FETCH NEXT 6 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        LahmacunName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return LahmacunName;
        }

        private string GetMantıNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string MantıName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 9 ROW FETCH NEXT 9 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MantıName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return MantıName;
        }

        private string GetiskenderNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string iskenderName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 3 ROW FETCH NEXT 3 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        iskenderName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return iskenderName;
        }

        private string GetHatayTavukNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string HatayTavukName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 5 ROW FETCH NEXT 5 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        HatayTavukName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return HatayTavukName;
        }

        private string GetEtDonerNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string EtDonerName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 8 ROW FETCH NEXT 8 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EtDonerName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return EtDonerName;
        }

        private string GetKofteNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string KofteName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 2 ROW FETCH NEXT 2 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        KofteName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return KofteName;
        }

        private string GetMakarnaNameFromDatabase()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;"; 
            string MakarnaName = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RestaurantName FROM Restaurants ORDER BY (SELECT NULL) OFFSET 4 ROW FETCH NEXT 4 ROW ONLY"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MakarnaName = reader["RestaurantName"].ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return MakarnaName;
        }




        private void UserButton(object sender, RoutedEventArgs e)
        {
            var userInformationControl = new UserInformation();
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(userInformationControl);
            }
        }

        private void CartButton(object sender, RoutedEventArgs e)
        {
            var cartControl = new Cart();
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(cartControl);
            }
        }

        private void LogOutButton(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/TastyGo_UI.png")));

                
                TextBlock nameTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 395, 0, 0),
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 312,
                    Height = 30,
                    FontSize = 24,
                    Text = "Enter Your Name&Surname"
                };
                parentWindow.MainGrid.Children.Add(nameTextBlock);

                TextBox nameTextBox = new TextBox
                {
                    Name = "FullNameTextBox",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 438, 0, 0),
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 248,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1.5),
                    FontSize = 18,
                    Style = (Style)FindResource("RoundedTextBox")
                };
                parentWindow.MainGrid.Children.Add(nameTextBox);

                TextBlock passwordTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 476, 0, 0),
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 234,
                    FontSize = 24,
                    Text = "Enter Your Password"
                };
                parentWindow.MainGrid.Children.Add(passwordTextBlock);

                PasswordBox passwordBox = new PasswordBox
                {
                    Name = "PasswordBox",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 513, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 248,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1.5),
                    FontSize = 18,
                    Style = (Style)FindResource("RoundedPasswordBox")
                };
                parentWindow.MainGrid.Children.Add(passwordBox);

                Button logInButton = new Button
                {
                    Content = "Log In",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(675, 556, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = Brushes.White,
                    Width = 70,
                    Height = 40,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1.5),
                    FontSize = 18,
                    Style = (Style)FindResource("RoundedButton")
                };
                logInButton.Click += parentWindow.LogInButton;
                parentWindow.MainGrid.Children.Add(logInButton);

                Button signUpButton = new Button
                {
                    Content = "Sign Up",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(784, 556, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = Brushes.White,
                    Width = 70,
                    Height = 40,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1.5),
                    FontSize = 18,
                    Style = (Style)FindResource("RoundedButton")
                };
                signUpButton.Click += parentWindow.SignUpButton;
                parentWindow.MainGrid.Children.Add(signUpButton);
            }
        }

        private void Hamburger(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new Hamburger());
            }
        }

        private void Pizza(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new Pizza());
            }
        }

        private void CigKofte(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new CigKofte());
            }
        }

        private void Lahmacun(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new Lahmacun());
            }
        }

        private void Mantı(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new Mantı());
            }
        }

        private void iskender(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new iskender());
            }
        }

        private void HatayTavuk(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new HatayTavuk());
            }
        }

        private void EtDoner(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new EtDoner());
            }
        }

        private void Kofte(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new Kofte());
            }
        }

        private void Makarna(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new Makarna());
            }
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            var homeControl = new Home();
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(homeControl);
            }
        }
    }
}