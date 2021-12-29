using Database.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
	class Logins : IDAO
	{
		private int currentUserId;
		public override void DeleteData(int index)
		{
			// No implementation will be provided
		}

		public override DataType GetDataType()
		{
			return DataType.Loginy;
		}

		public override void InsertData(string[] data)
		{
			// No implementation will be provided
		}

		public override DataTable ReadData()
		{
			_connection.Open();
			string readQuery = $"SELECT UserId, Login, Password FROM LoginData;";
			SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
			DataTable dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			_connection.Close();

			return dataTable;
		}

		public override void UpdateData(string[] data, int index)
		{
			_connection.Open();
			string updateQuery = $"UPDATE LoginData SET Password = @pwd " +
				$"WHERE UserId = @id";
			SqlCommand command = new SqlCommand(updateQuery, _connection);
			command.Parameters.AddWithValue("@pwd", data[0]);
			command.Parameters.AddWithValue("@id", index);
			command.ExecuteNonQuery();
			_connection.Close();
		}

		public bool CheckPassword(string login, string password)
		{
			_connection.Open();

			string readQuery = $"SELECT Users.UserType, Users.UserId FROM LoginData " +
							   $"JOIN Users ON Users.UserId=LoginData.UserId " +
							   $"WHERE Login='{login}' AND Password='{password}' AND Users.UserType={(int)UserType.Admin};";
			SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
			DataTable dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			_connection.Close();
			this.currentUserId = int.Parse(dataTable.Rows[0]["UserId"].ToString());
			
			return dataTable.Rows.Count == 1;
		}
		public int GetCurrentLoggedUser()
        {
			return this.currentUserId;
        }
	}
}
