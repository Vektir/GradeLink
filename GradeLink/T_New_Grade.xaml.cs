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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace GradeLink
{
	/// <summary>
	/// Interaction logic for T_New_Grade.xaml
	/// </summary>
	public partial class T_New_Grade : Window
	{

		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";

		string Teacher_ID;
		string Student_ID;

		public T_New_Grade(string Teacher_ID, string Student_ID)
		{
			InitializeComponent();
			this.Teacher_ID = Teacher_ID;
			this.Student_ID = Student_ID;




		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string query = $"insert into Grades ([name], [value], teacher, student) values ('{name.Text}', {value.Text}, {Teacher_ID}, {Student_ID})";
			SqlConnection sqlCon = new SqlConnection(connection);
			sqlCon.Open();
			try
			{
				SqlCommand command = new SqlCommand(query, sqlCon);
				command.CommandType = CommandType.Text;
				command.ExecuteNonQuery();

				new T_Student_Details(Teacher_ID, Student_ID).Show();
				Close();

			}catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void Back(object sender, RoutedEventArgs e)
		{
			new T_Student_Details(Teacher_ID, Student_ID).Show();
			Close();

		}
	}
}
