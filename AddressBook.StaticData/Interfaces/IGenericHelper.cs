using Microsoft.Data.SqlClient;

namespace AddressBook.ORM.Interfaces
{
    public interface IGenericHelper
    {
        List<T> FetchData<T>(string query, Func<SqlDataReader, T> mapFunction, params SqlParameter[] parameters);
        void AddRecord(string query, params SqlParameter[] parameters);
        void UpdateRecord(string query, params SqlParameter[] parameters);
        void DeleteRecord(string query, params SqlParameter[] parameters);
    }
}