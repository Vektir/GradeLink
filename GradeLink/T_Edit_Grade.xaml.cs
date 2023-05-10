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
	/// Interaction logic for T_Edit_Grade.xaml
	/// </summary>
	public partial class T_Edit_Grade : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";
		string Teacher_ID;
		string Student_ID;
		string Grade_ID;
		public T_Edit_Grade(string teacher_ID, string student_ID, string grade_ID)
		{
			InitializeComponent();
			Teacher_ID = teacher_ID;
			Student_ID = student_ID;
			Grade_ID = grade_ID;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string query = $"update Grades set [name] = '{name.Text}', [value] = {value.Text} where ID = {Grade_ID}";
			SqlConnection sqlCon = new SqlConnection(connection);
			sqlCon.Open();
			try
			{
				SqlCommand command = new SqlCommand(query, sqlCon);
				command.CommandType = CommandType.Text;
				command.ExecuteNonQuery();

				new T_Student_Details(Teacher_ID, Student_ID).Show();
				Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void Back(object sender, RoutedEventArgs e)
		{
			new T_Student_Details(Teacher_ID, Student_ID).Show();
			Close();
		}

		private void Delete_Grade(object sender, RoutedEventArgs e)
		{
			string query = $"delete from grades where ID = {Grade_ID}";
			SqlConnection sqlCon = new SqlConnection(connection);
			sqlCon.Open();
			try
			{
				SqlCommand command = new SqlCommand(query, sqlCon);
				command.CommandType = CommandType.Text;
				command.ExecuteNonQuery();

				new T_Student_Details(Teacher_ID, Student_ID).Show();
				Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
