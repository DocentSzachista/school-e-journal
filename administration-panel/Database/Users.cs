using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database.Enums;
namespace Database
{

    class Users : IDAO
    {

        
        public override void DeleteData(int index)
        {
            _connection.Open();
            using (SqlCommand deleteProcedure = new SqlCommand("SP_DML_Users", _connection))
            {
                deleteProcedure.CommandType = CommandType.StoredProcedure;
                deleteProcedure.Parameters.AddWithValue("@ACTION", "DELETE");
                deleteProcedure.Parameters.AddWithValue("userId", index);
                deleteProcedure.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public override DataType GetDataType()
        {
            return DataType.Uzytkownicy;
        }

        public override void InsertData(string[] data)
        {
            int value = (int)(Enum.Parse(typeof(UserType), data[5]));
           
            using (SqlCommand insertProcedure = new SqlCommand("SP_DML_Users", _connection)   )
            {
                insertProcedure.CommandType = CommandType.StoredProcedure;
                insertProcedure.Parameters.AddWithValue("@firstName", data[0]);
                insertProcedure.Parameters.AddWithValue("@secondName", data[1]);
                insertProcedure.Parameters.AddWithValue("@lastName", data[2]);
                insertProcedure.Parameters.AddWithValue("@PhoneNumber", data[3]);
                insertProcedure.Parameters.AddWithValue("@email", data[4]);
                insertProcedure.Parameters.AddWithValue("@userType",  value);
                insertProcedure.Parameters.AddWithValue("@ACTION", "INSERT");
                _connection.Open();
                insertProcedure.ExecuteNonQuery();
                _connection.Close();
            }

        }

        public override DataTable ReadData()
        {
            _connection.Open();
            string readQuery = "SELECT * FROM DisplayUsers;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }
        /// <summary>
        /// Funkcja która pobiera typ użytkownika i zwraca tabelkę posiadającą wszystkich użytkowników danego typu 
        /// </summary>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public DataTable GetSpecifiedUserData(UserType UserType)
        {
            _connection.Open();
            int userTypeIndex = 3;
            DataTable dataTable = new DataTable();
            using (SqlCommand readProcedure = new SqlCommand("SP_DisplayUserWithSpecifiedUserType", _connection))
            {
                readProcedure.CommandType = CommandType.StoredProcedure;
                switch (UserType)
                {
                    case UserType.Nauczyciel:
                        userTypeIndex = ((int)UserType.Nauczyciel);
                        break;
                    case UserType.Uczen:
                        userTypeIndex = (int)UserType.Uczen;
                        break;
                    case UserType.Rodzic:
                        userTypeIndex = (int)UserType.Rodzic;
                        break;
                }
                readProcedure.Parameters.AddWithValue("@userType", userTypeIndex);

                dataTable.Load(readProcedure.ExecuteReader());

            }
            _connection.Close();
            return dataTable;
        }

        public override void UpdateData(string[] data, int index)
        {
            // parsujemy typ użytkownika z comboboxa 
            int value = (int)(Enum.Parse(typeof(UserType), data[5]));
            using (SqlCommand updateProcedure = new SqlCommand("SP_DML_Users", _connection))
            {
                
                updateProcedure.CommandType = CommandType.StoredProcedure;
                updateProcedure.Parameters.AddWithValue("@firstName", data[0]);
                updateProcedure.Parameters.AddWithValue("@secondName", data[1]);
                updateProcedure.Parameters.AddWithValue("@lastName", data[2]);
                updateProcedure.Parameters.AddWithValue("@PhoneNumber", data[3]);
                updateProcedure.Parameters.AddWithValue("@email", data[4]);
                updateProcedure.Parameters.AddWithValue("@userType", value);
                updateProcedure.Parameters.AddWithValue("@ACTION", "UPDATE");
                updateProcedure.Parameters.AddWithValue("@userId", index);
                _connection.Open();
                updateProcedure.ExecuteNonQuery();
                _connection.Close();
            }

        }
    }
}
