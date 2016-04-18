using DbExplorer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExplorer.DAL
{
    internal class MasterContext :DbContext
    {
        public MasterContext(string configConnectionStringName) : base(configConnectionStringName)
        {
            Database.SetInitializer<MasterContext>(null);
        }

        public IList<TableInfo> ListTables()
        {
            return Database.SqlQuery<TableInfo>(TableInfo.QueryAll).ToList();
        }

        public IList<ColumnInfo> ListColumns(string tableName)
        {
            return Database.SqlQuery<ColumnInfo>(ColumnInfo.Query, new SqlParameter(ColumnInfo.QueryParameterName, tableName)).ToList();
        }

        public IList<ConstraintInfo> ListColumnConstraints(string tableName, string columnName)
        {
            return Database.SqlQuery<ConstraintInfo>(ConstraintInfo.Query, new SqlParameter(ConstraintInfo.QueryTableParameterName, tableName), new SqlParameter(ConstraintInfo.QueryColumnParameterName, columnName)).ToList();
        }
    }
}
