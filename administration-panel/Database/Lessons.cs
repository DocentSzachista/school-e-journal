using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database.Enums;
using System.Data;

namespace Database
{
	class Lessons : IDAO
	{
		public override void DeleteData(int index)
		{
			_connection.Open();

			string query = "DELETE FROM Lessons WHERE LessonId = @idx;";
			SqlCommand command = new SqlCommand(query, _connection);
			command.Parameters.AddWithValue("@idx", index);
			command.ExecuteNonQuery();

			_connection.Close();
		}

		public override DataType GetDataType()
		{
			return DataType.Lekcje;
		}

		public override void InsertData(string[] data)
		{
			_connection.Open();

			string query = "INSERT INTO Lessons (Topic, StartTime, EndTime, SubjectId) " +
						   "VALUES (@topic, @startTime, @endTime, @subjectId);";
			SqlCommand command = new SqlCommand(query, _connection);

			command.Parameters.AddWithValue("@topic", data[0]);
			command.Parameters.AddWithValue("@startTime", data[1]);
			command.Parameters.AddWithValue("@endTime", data[2]);
			command.Parameters.AddWithValue("@subjectId", data[3]);

			command.ExecuteNonQuery();

			_connection.Close();
		}

		public override DataTable ReadData()
		{
			_connection.Open();
			string readQuery = "SELECT * FROM DisplayLessons";
			SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
			DataTable dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			_connection.Close();
			return dataTable;
		}

		public override void UpdateData(string[] data, int index)
		{
			_connection.Open();

			string query = "UPDATE Lessons " +
						   "SET Topic = @topic, StartTime = @startTime, EndTime = @endTime, SubjectId = @subjectId " +
						   "WHERE LessonId = @index;";
			SqlCommand command = new SqlCommand(query, _connection);

			command.Parameters.AddWithValue("@topic", data[0]);
			command.Parameters.AddWithValue("@startTime", data[1]);
			command.Parameters.AddWithValue("@endTime", data[2]);
			command.Parameters.AddWithValue("@subjectId", data[3]);
			command.Parameters.AddWithValue("@index", index);

			command.ExecuteNonQuery();

			_connection.Close();
		}

		public DataTable GetSubjectLessons(int subjectId)
		{
			_connection.Open();
			string readQuery = $"SELECT LessonId, Topic, StartTime, SubjectName, EndTime FROM Lessons " +
							   $"JOIN Subjects ON Subjects.SubjectId = Lessons.SubjectId " +
							   $"WHERE Lessons.SubjectId={subjectId};";
			SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
			DataTable dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			_connection.Close();
			return dataTable;
		}
	}
}
