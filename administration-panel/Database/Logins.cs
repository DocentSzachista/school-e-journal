using Database.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
	class Logins : IDAO
	{
		public override void DeleteData(int index)
		{
			throw new NotImplementedException();
		}

		public override DataType GetDataType()
		{
			return DataType.Loginy;
		}

		public override void InsertData(string[] data)
		{
			throw new NotImplementedException();
		}

		public override DataTable ReadData()
		{
			throw new NotImplementedException();
		}

		public override void UpdateData(string[] data, int index)
		{
			throw new NotImplementedException();
		}

		public bool CheckPassword(string login, string password)
		{
			_connection.Open();

			string readQuery = $"SELECT Users.UserType FROM LoginData " +
							   $"JOIN Users ON Users.UserId=LoginData.UserId " +
							   $"WHERE Login='{login}' AND Password='{password}' AND Users.UserType={(int)UserType.Admin};";
			SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
			DataTable dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			_connection.Close();
			return dataTable.Rows.Count == 1;
		}
	}
}
