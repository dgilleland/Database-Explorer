using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExplorer.Entities
{
    /// <summary>
    /// Represents the constraint details for an individual column in a given table.
    /// </summary>
    public class ConstraintInfo
    {
        public const string Query = "SELECT TOP 1000 CCU.TABLE_NAME AS 'TableName', CCU.COLUMN_NAME AS 'ColumnName', CC.[CONSTRAINT_NAME] AS 'ConstraintName', [CHECK_CLAUSE] AS 'CheckClause' FROM [INFORMATION_SCHEMA].[CHECK_CONSTRAINTS] CC LEFT OUTER JOIN [INFORMATION_SCHEMA].[CONSTRAINT_COLUMN_USAGE] CCU ON CC.CONSTRAINT_NAME = CCU.CONSTRAINT_NAME WHERE CCU.TABLE_NAME = @TableName AND CCU.COLUMN_NAME = @ColumnName ORDER BY CC.CONSTRAINT_NAME;";
        public const string QueryTableParameterName = "@TableName";
        public const string QueryColumnParameterName = "@ColumnName";

        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ConstraintName { get; set; }
        public string CheckClause { get; set; }
    }
}
