using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using Database.Enums;
namespace Database
{
    /// <summary>
    /// Interfejs zawierający przestrzeń nazw operacji manipulacji danych DML.
    /// </summary>
    public abstract class IDAO
    {
        // connector do bazy danych 
        protected static readonly SqlConnection _connection = new SqlConnection(DamianRaczkowskiLab2PracDom.Properties.Resources.ConnectionString);
        /// <summary>
        /// Metoda Wrzucająca nowy rekord do bazy danych
        /// </summary>
        /// <param name="data"></param>
        public abstract void InsertData(string[] data);
        /// <summary>
        /// Metoda Usuwająca dany rekord z bazy
        /// </summary>
        /// <param name="index"></param>
        public abstract void DeleteData(int index);
        /// <summary>
        /// Metoda modyfikująca istniejący rekord w bazie 
        /// </summary>
        /// <param name="data"></param>
        public abstract void UpdateData(string[] data, int index);
        /// <summary>
        /// Metoda Pobierająca wszystkie dane z tabelki
        /// </summary>
        /// <returns></returns>
        public abstract DataTable ReadData();

        /// <summary>
        /// Metoda zwracająca jakim datatypem jest 
        /// </summary>
        /// <returns></returns>
        public abstract DataType GetDataType();
    }
}
