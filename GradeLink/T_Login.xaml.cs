using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace GradeLink
{
	/// <summary>
	/// Interaction logic for T_Login.xaml
	/// </summary>
	public partial class T_Login : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";
		public T_Login()
		{
			InitializeComponent();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			string query = $"select count(1) from Teachers where [name] = '{username.Text}' and \"password\" = '{password.Password}'";
			SqlConnection sqlCon = new SqlConnection(connection);

			try
			{
				sqlCon.Open();
				SqlCommand command = new SqlCommand(query, sqlCon);
				command.CommandType = CommandType.Text;

				int a = Convert.ToInt32(command.ExecuteScalar());
				if (a == 1)
				{
					query = $"select ID from Teachers where [name] = '{username.Text}'";
					command = new SqlCommand(query, sqlCon);
					command.CommandType = CommandType.Text;
					new T_Main(command.ExecuteScalar().ToString()).Show();

					Close();
				}
			}
			catch (Exception ex)
			{

			}



		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			new T_New_account().Show();
			Close();

		}
	}
}
