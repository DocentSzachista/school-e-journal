using Database.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Database
{
    class Classes : IDAO
    {


        public override void DeleteData(int index)
        {
            _connection.Open();
            using (SqlCommand deleteProcedure = new SqlCommand("SP_DML_Class", _connection))
            {
                deleteProcedure.CommandType = CommandType.StoredProcedure;
                deleteProcedure.Parameters.AddWithValue("@ACTION", "DELETE");
                deleteProcedure.Parameters.AddWithValue("classId", index);
                deleteProcedure.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public override DataType GetDataType()
        {
            return DataType.Klasy;
        }

        public override void InsertData(string[] data)
        {
            string className = data[1];
            _connection.Open();
            // odwołujemy się do procedury przetwarzania operacji na danych
            using (SqlCommand insertProcedure = new SqlCommand("SP_DML_CLASS", _connection))
            {
                // Ustalamy SqlCommand aby wiedział, że korzystamy z procedury składowanej
                insertProcedure.CommandType = CommandType.StoredProcedure;
                // Dodajemy parametry procedury
                insertProcedure.Parameters.AddWithValue("@className", className);
                // jeżeli  podaliśmy index nauczyciela to  uwzględnij w dodawaniu
                if (!string.IsNullOrEmpty(data[0]))
                {
                    int teacherId = int.Parse(data[0]);
                    insertProcedure.Parameters.AddWithValue("@teacherId", teacherId);
                }
                // Parametr rozróżniający operację DML 
                insertProcedure.Parameters.AddWithValue("@ACTION", "INSERT");
                // Wykonaj zapytanie 
                insertProcedure.ExecuteNonQuery();
            }
            // Zabij połączenie 
            _connection.Close();
        }

        public override DataTable ReadData()
        {
            _connection.Open();
            string readQuery = "SELECT * FROM DisplayAllClasses";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }


        public override void UpdateData(string[] data, int index)
        {
            string className = data[1];
            _connection.Open();
            using (SqlCommand updateProcedure = new SqlCommand("SP_DML_CLASS", _connection))
            {
                // Ustalamy SqlCommand aby wiedział, że korzystamy z procedury składowanej
                updateProcedure.CommandType = CommandType.StoredProcedure;
                // Dodajemy parametry procedury
                updateProcedure.Parameters.AddWithValue("@classId", index);
                updateProcedure.Parameters.AddWithValue("@className", className);
                // jeżeli  podaliśmy index nauczyciela to  uwzględnij w dodawaniu
                if (!string.IsNullOrEmpty(data[0]))
                {
                    int teacherId = int.Parse(data[0]);
                    updateProcedure.Parameters.AddWithValue("@teacherId", teacherId);
                }
                // Parametr rozróżniający operację DML 
                updateProcedure.Parameters.AddWithValue("@ACTION", "UPDATE");
                updateProcedure.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public DataTable FillComboBox()
        {
            _connection.Open();
            string readQuery = "SELECT ClassId, ClassName FROM Classes";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }
    }
}
