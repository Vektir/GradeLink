using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;

namespace GradeLink
{
	/// <summary>
	/// Interaction logic for T_New_account.xaml
	/// </summary>
	public partial class T_New_account : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";

		public T_New_account()
		{
			InitializeComponent();


		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string query = $"insert into Teachers ([Name], password, subject) values ('{username.Text}', '{password.Password}', '{subject.Text}')";
			SqlConnection sqlCon = new SqlConnection(connection);
			try
			{
				sqlCon.Open();
				SqlCommand command = new SqlCommand(query, sqlCon);
				command.CommandType = CommandType.Text;

				Convert.ToInt32(command.ExecuteNonQuery());
				new T_Login().Show();
				Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Close();
		}
	}
}
