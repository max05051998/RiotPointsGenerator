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
using System.Configuration;

namespace AB120_02
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        public MainWindow()
        {
            InitializeComponent();

        }




        private void ggez_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(usernamelogin.Text))
            {
                MessageBox.Show("Please enter a Username!");
            }
            else if(String.IsNullOrWhiteSpace(passwortlogin.Password))
            {
                MessageBox.Show("Please enter your Password!");
            }
            else
            {
                save();
            }
        }
        private void save()
        {
            string query = "INSERT INTO dbo.RiotPoints (username, password) VALUES (@username, @password)";
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                command.Parameters.AddWithValue("@username", usernamelogin.Text);
                command.Parameters.AddWithValue("@password", passwortlogin.Password);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
