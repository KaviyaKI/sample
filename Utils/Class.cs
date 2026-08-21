using System.Data;
using System.Data.Common;

namespace learningprojectserver.Utils
{
 public interface IDb : IDisposable
    {
        Task Connect();
        Task BeginTransaction();
      
        Task CommitTransaction();
        Task DeleteTransaction();
        DbCommand GetCommand(string query);

        DbCommand UpdateCommand(string query);
        DbCommand DeleteCommand(string query);

        DbCommand GetCommand();
        //DbParameter AddParameter(DbCommand command, string parameterName, DbTypes.Types type);
        Task<DbDataReader> Execute(DbCommand command);
        Task<int> ExecuteNonQuery(DbCommand command);
        Task<int> BulkInsert<T>(string tableName, IEnumerable<T> items);

    }

}
