using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DbExplorer.Entities
{
    /// <summary>
    /// Represents a given table's information.
    /// </summary>
    public class TableInfo
    {
        public const string QuerySingle = "SELECT TABLE_CATALOG AS 'DatabaseName', TABLE_SCHEMA AS 'SchemaName', TABLE_NAME AS 'TableName', TABLE_TYPE AS 'TableType', S.value AS 'Description' FROM INFORMATION_SCHEMA.TABLES C LEFT OUTER JOIN sys.extended_properties S ON  S.major_id = OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME) AND S.minor_id = 0 AND S.name = 'MS_Description' WHERE TABLE_NAME = @TableName ORDER BY TABLE_SCHEMA, TABLE_NAME";
        public const string QuerySingleParameterName = "@TableName";
        public const string QueryAll = "SELECT TABLE_CATALOG AS 'DatabaseName', TABLE_SCHEMA AS 'SchemaName', TABLE_NAME AS 'TableName', TABLE_TYPE AS 'TableType', S.value AS 'Description' FROM INFORMATION_SCHEMA.TABLES C LEFT OUTER JOIN sys.extended_properties S ON  S.major_id = OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME) AND S.minor_id = 0 AND S.name = 'MS_Description' ORDER BY TABLE_SCHEMA, TABLE_NAME";

        /// <summary>'TABLE_CATALOG'</summary>
        public string DatabaseName { get; set; }
        /// <summary>'TABLE_SCHEMA'</summary>
        public string SchemaName { get; set; }
        /// <summary>'TABLE_NAME'</summary>
        public string TableName { get; set; }
        /// <summary>'TABLE_TYPE'</summary>
        public string TableType { get; set; }
        /// <summary>'Description'</summary>
        public string Description { get; set; }

        /// <summary>The FullyQualifiedTableName is in the format SchemaName.TableName</summary>
        [NotMapped]
        public string FullyQualifiedTableName
        { get { return SchemaName + "." + TableName; } }
    }
}
