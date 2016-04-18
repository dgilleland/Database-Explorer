using DbExplorer.DAL;
using DbExplorer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExplorer.BLL
{
    [DataObject]
    public class Controller
    {
        private readonly string ConnStrName;
        public Controller(string configConnectionStringName)
        {
            ConnStrName = configConnectionStringName;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<DatabaseInfo> ListDatabases()
        {
            using (var context = new MasterContext(ConnStrName))
            {
                return context.Database.SqlQuery<DatabaseInfo>(DatabaseInfo.Query).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<TableInfo> ListTables()
        {
            using (var context = new MasterContext(ConnStrName))
            {
                return context.ListTables();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<TableInfo> ListTables(string sortExpression)
        {
            switch (sortExpression)
            {
                case "TableName":
                    return ListTables().OrderBy(x => x.TableName).ToList();
                case "SchemaName":
                    return ListTables().OrderBy(x => x.SchemaName).ToList();
                case "FullyQualifiedTableName":
                    return ListTables().OrderBy(x => x.FullyQualifiedTableName).ToList();
                default:
                    return ListTables();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ColumnInfo> ListColumns(string tableName)
        {
            using (var context = new MasterContext(ConnStrName))
            {
                return context.ListColumns(tableName);
            }
        }
    }
}
